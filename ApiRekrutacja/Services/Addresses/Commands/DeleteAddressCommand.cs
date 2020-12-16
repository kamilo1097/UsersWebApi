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
    public class DeleteAddressCommand : IRequest<Address>
    {
        public DeleteAddressCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Address>
    {
        private readonly ApplicationDbContext _context;

        public DeleteAddressCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Address> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _context.Adresses.FindAsync(request.Id);
            if (address == null)
            {
                throw new Exception("Can't find address with this ID");
            }
            _context.Remove(address);
            var success = await _context.SaveChangesAsync() > 0;
            if (success)
            {
                return null;
            }
            throw new Exception("Can't delete address due to some problem");
        }
    }

}
