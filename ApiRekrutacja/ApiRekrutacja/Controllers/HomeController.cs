using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Users.Commands;
using Services.Users.Queries;

namespace ApiRekrutacja.Controllers
{
    [ApiController]
    [Route("users")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public Task<IEnumerable<User>> Index()
        {
            return mediator.Send(new GetAllUsersQuery());
        }
        [HttpGet("{id}")]
        public Task<User> GetUser(int id)
        {
            return mediator.Send(new GetUserQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(CreateUserCommand command)
        {
            return await mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public Task<User> DeleteUser(int id)
        {
            return mediator.Send(new DeleteUserCommand(id));
        }
    }
}