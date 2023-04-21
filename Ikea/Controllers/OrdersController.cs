using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Ikea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get([FromQuery] int page)
        {
            List<Order> products = await _orderService.GetAllOrders(page);
            return products == null ? NoContent() :Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order newOrder)
        {
            return await _orderService.AddOrder(newOrder);
        }
    }
}
