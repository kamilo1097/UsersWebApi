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
    public class GetUserQuery : IRequest<User>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly ApplicationDbContext _context;
        public GetUserQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            return user;
        }
    }

}
