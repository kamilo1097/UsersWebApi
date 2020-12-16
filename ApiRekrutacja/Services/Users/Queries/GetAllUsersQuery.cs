using MediatR;
using Services.Data;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Services.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>> { }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllUsersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users;
            return users;
        }
    }
    
}
