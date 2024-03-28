using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Create;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Delete;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Update;
using MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetById;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Create.CreateOrderDetailCommand;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Delete.DeleteOrderDetailCommand;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Commands.Update.UpdateOrderDetailCommand;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetById.GetByIdOrderDetailQuery;
using static MultiShop.Order.Application.Features.CQRS.OrderDetails.Queries.GetList.GetListOrderDetailQuery;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetListOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetByIdOrderDetailQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetListOrderDetailQueryHandler getOrderDetailQueryHandler, GetByIdOrderDetailQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, DeleteOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handle(new GetByIdOrderDetailQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            var values = await _createOrderDetailCommandHandler.Handle(command);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            var values = await _updateOrderDetailCommandHandler.Handle(command);
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var values = await _removeOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));
            return Ok(values);
        }
    }
}
