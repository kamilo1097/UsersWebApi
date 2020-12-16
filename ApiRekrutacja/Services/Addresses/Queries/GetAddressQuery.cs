using MediatR;
using Services.Data;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Addresses.Queries
{
    public class GetAddressQuery : IRequest<Address>
    {
        public GetAddressQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Address>
    {
        private readonly ApplicationDbContext _context;
        public GetAddressQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Address> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await _context.Adresses.FindAsync(request.Id);
            return address;
        }
    }
}
