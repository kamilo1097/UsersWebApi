using MediatR;
using Services.Data;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users.Commands
{
    public class DeleteUserCommand : IRequest<User>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly ApplicationDbContext _context;
        public DeleteUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if(user == null)
            {
                throw new Exception("Can't find user with ID");
            }
            _context.Remove(user);
            var success = await _context.SaveChangesAsync() > 0;
            if (success)
            {
                return null;
            }
            throw new Exception("Can't delete user due to some problem");
        }
    }


}
