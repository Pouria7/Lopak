using AutoMapper;
using Lopak.Application.Actions.Cities;
using Lopak.Application.Infrastructure;
using Lopak.Application.Infrastructure.AutoMapper;
using Lopak.Application.Interfaces;
using Lopak.Application.Services;
using Lopak.Common;
using Lopak.Infrastructure;
using Lopak.Persistence;
using Lopak.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lopak.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Jww BearerTokens
            services.Configure<BearerTokensOptions>(options => Configuration.GetSection("BearerTokens").Bind(options));

            services
                .AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                   // cfg.Challenge = 
                  
                 
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["BearerTokens:Issuer"], // site that makes the token
                        ValidateIssuer = false, // TODO: change this to avoid forwarding attacks
                        ValidAudience = Configuration["BearerTokens:Audience"], // site that consumes the token
                        ValidateAudience = false, // TODO: change this to avoid forwarding attacks
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["BearerTokens:Key"])),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                    cfg.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                            logger.LogError("Authentication failed.", context.Exception);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                       {
                           var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
                           return tokenValidatorService.ValidateAsync(context);
                       },
                        OnMessageReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                            logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);
                            return Task.CompletedTask;
                        }
                    };
                });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder
            //            .WithOrigins("http://localhost:4200") //Note:  The URL must be specified without a trailing slash (/).
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials());
            //});


            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserDataBox, UserDataBox>();

            // Add MediatR
            services.AddMediatR(typeof(CreateCityCommand).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Add DbContext using SQL Server Provider
            services.AddDbContext<ILopakDbContext, LopakDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LopakDatabase"), DbContextOptionsBuilder =>
                {
                  
                    DbContextOptionsBuilder.UseNetTopologySuite();
                    //var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                    //DbContextOptionsBuilder.CommandTimeout(minutes);
                    //DbContextOptionsBuilder.EnableRetryOnFailure();
                }       
                ));


            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
              

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            //Temp swagger Doc
            services.AddSwaggerDocument(document =>
            {
                document.AddSecurity("Bearer",
              new[] { "Bearer" },
              new NSwag.SwaggerSecurityScheme()
              {
                  In = NSwag.SwaggerSecurityApiKeyLocation.Header,
                  Description = "Please insert JWT with Bearer into field",
                  Name = "Authorization",
                  Type = NSwag.SwaggerSecuritySchemeType.ApiKey
              }
              );

            });

   

           // services.AddSwagger


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSwaggerUi3(settings =>
            {
              
              //  settings.GeneratorSettings.AddSecurity("Bearer",
              //new[] { "Bearer" },
              //new NSwag.SwaggerSecurityScheme()
              //{
              //    In = NSwag.SwaggerSecurityApiKeyLocation.Header,
              //    Description = "Please insert JWT with Bearer into field",
              //    Name = "Authorization",
              //    Type = NSwag.SwaggerSecuritySchemeType.ApiKey
              //}
              //);

                settings.Path = "/wapi";
                settings.DocumentPath = "/api/ApiDocDetails.json";          

            });


            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });


    
        }
    }
}
