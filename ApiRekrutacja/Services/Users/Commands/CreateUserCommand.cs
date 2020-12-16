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
    public class CreateUserCommand : IRequest<User> { 
    
        public string Name { get; set; }
        public string SurName { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly ApplicationDbContext _context;
        public CreateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Surname = request.SurName
            };
            _context.Users.Add(user);
            var success = await _context.SaveChangesAsync() > 0;
            if(success)
            {
                return user;
            }
            else
            {
                throw new Exception("fail to add new user");
            }

        }
    }
}
