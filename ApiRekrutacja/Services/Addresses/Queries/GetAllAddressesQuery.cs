using MediatR;
using Services.Data;
using Services.Models;
using Services.Users.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Addresses.Queries
{
    public class GetAllAddressesQuery : IRequest<IEnumerable<Address>> { }
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<Address>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllAddressesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var address = _context.Adresses;
            return address;
        }
    }
}
