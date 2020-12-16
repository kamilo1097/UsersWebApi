using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Addresses.Commands;
using Services.Addresses.Queries;


namespace ApiRekrutacja.Controllers
{
    [ApiController]
    [Route("addresses")]
    public class AddressController : Controller
    {
        private readonly IMediator mediator;
        public AddressController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<Address>> Index()
        {
            return mediator.Send(new GetAllAddressesQuery());
        }
        [HttpGet("{id}")]
        public Task<Address> GetAddress(int id)
        {
            return mediator.Send(new GetAddressQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<Address>> Create(CreateAddressCommand command)
        {
            return await mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public Task<Address> DeleteAddress(int id)
        {
            return mediator.Send(new DeleteAddressCommand(id));
        }
    }
}