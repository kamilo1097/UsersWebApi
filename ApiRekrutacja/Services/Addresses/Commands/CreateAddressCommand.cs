using MediatR;
using Services.Data;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<Address> { 
        public string AddressName { get; set; }
        public int UserId { get; set; }
    }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Address>
    {
        private readonly ApplicationDbContext _context;
        public CreateAddressCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Address> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address
            {
                AddressName = request.AddressName,
                UserId = request.UserId
            };
            _context.Adresses.Add(address);
            var success = await _context.SaveChangesAsync() > 0;
            if (success)
            {
                return address;
            }
            else
            {
                throw new Exception("fail to add new address");
            }
        }
    }


}
