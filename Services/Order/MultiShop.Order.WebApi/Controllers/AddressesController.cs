using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Create;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Delete;
using MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Update;
using MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetById;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Create.CreateAddressCommand;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Delete.DeleteAddressCommand;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Commands.Update.UpdateAddressCommand;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetById.GetByIdAddressQuery;
using static MultiShop.Order.Application.Features.CQRS.Addresses.Queries.GetList.GetListAddressQuery;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetListAddressQueryHandler _getAddressQueryHandler;
        private readonly GetByIdAddressQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly DeleteAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetListAddressQueryHandler getAddressQueryHandler, GetByIdAddressQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, DeleteAddressCommandHandler removeAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetByIdAddressQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            var values = await _createAddressCommandHandler.Handle(command);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            var values = await _updateAddressCommandHandler.Handle(command);
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var values = await _removeAddressCommandHandler.Handle(new DeleteAddressCommand(id));
            return Ok(values);
        }
    }
}
