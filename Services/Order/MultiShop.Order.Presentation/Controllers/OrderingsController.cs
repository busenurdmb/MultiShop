using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Create;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Delete;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Update;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetById;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetList;

namespace MultiShop.Order.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetListOrderingQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdering(int id)
        {
            //GetByIdOrderingQuery getByIdOrdering = new() { Id = id };->
            //GetByIdOrderingQuery bu sınıfta ıd yı ctor yapmassam bunu kullanıyorum.

            var value = await _mediator.Send(new GetByIdOrderingQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderingCommand createdOrderingCommand)
        {
            CreateOrderingResponse response = await _mediator.Send(createdOrderingCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderingCommand updateOrderingCommand)
        {
            UpdateOrderingResponse response = await _mediator.Send(updateOrderingCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteOrderingResponse response = await _mediator.Send(new DeleteOrderingCommand(id));

            return Ok(response);
        }
    }
}
