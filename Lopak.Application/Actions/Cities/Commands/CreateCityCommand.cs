using Lopak.Application.Interfaces;
using Lopak.Domain.Entities.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lopak.Application.Actions.Cities
{
   public class CreateCityCommand : IRequest<int>
    {
        public string TitleFa { get; set; }

        public class Handler : IRequestHandler<CreateCityCommand, int>
        {
            private readonly ILopakDbContext _context;

            public Handler(ILopakDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var entity = new City()
                {
                    TitleFa = request.TitleFa,
                };

                await  _context.Cities.AddAsync(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.CityId;

            }
        }
    }
}
