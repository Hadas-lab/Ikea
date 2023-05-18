using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using AutoMapper;
using System.Collections.Generic;

namespace Ikea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> Get([FromQuery] int page)
        {
            List<Order> products = await _orderService.GetAllOrders(page);
            List<OrderDto> productsDto = _mapper.Map<List<Order>, List<OrderDto>>(products);
            return products == null ? NoContent() :Ok(productsDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto newOrderDto)
        {
            Order newOrder = _mapper.Map<OrderDto, Order>(newOrderDto);
            Order order = await _orderService.AddOrder(newOrder);
            return order == null? StatusCode(400) : _mapper.Map<Order, OrderDto>(order);
        }
    }
}
