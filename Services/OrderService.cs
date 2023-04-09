using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> AddOrder(Order newOrder)
        {
            return await _orderRepository.AddOrder(newOrder);
        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

    }
}
