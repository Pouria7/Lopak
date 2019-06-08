using Lopak.Domain.Entities.Commercial;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Commercial
{
    public class CustomerConfiguration :  IEntityTypeConfiguration<Customer> 
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.CustomerId)
                  .HasColumnName("CustomerID")
                  .HasMaxLength(20)
                  .ValueGeneratedNever();

           // builder.HasKey(e => e.UserId);

            builder.Property(e => e.ContactTitle).HasMaxLength(50).IsRequired();
            builder.Property(e => e.ContactName).HasMaxLength(50).IsRequired();


            builder.Property(e => e.Phone).HasMaxLength(14);
            builder.Property(e => e.CellPhone).HasMaxLength(14).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(110);
            builder.Property(e => e.Address).HasMaxLength(1000);

            builder.Property(e => e.PostalCode).HasMaxLength(10);
            builder.Property(e => e.Country).HasMaxLength(50);

            builder.Property(e => e.AccountHolderName).HasMaxLength(50);
            builder.Property(e => e.CardNumber).HasMaxLength(16);
            builder.Property(e => e.ShebaNumber).HasMaxLength(26);

            builder.Property(e => e.ConfirmationDate).HasColumnType("datetime");

            //builder Location

            builder.HasOne(d => d.Area)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.AreaId)
                .IsRequired()
                .HasConstraintName("FK_Customers_Area");

             builder.HasOne(d => d.ActivityTime)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ActivityTimeId)
                .HasConstraintName("FK_Customers_ActivityTime");

              builder.HasOne(d => d.ActivityField)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ActivityFieldId)
                .IsRequired()
                .HasConstraintName("FK_Customers_ActivityField");


            builder.Property(x => x.CreatedDate).HasColumnType("datetime");

            //builder trashtype one to many


            Base.RegisterDataConfiguration.Configure(builder);
            builder.ToTable(nameof(Customer), Schema.Commercial);

            
        }
    }
}
