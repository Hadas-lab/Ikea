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
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
           
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> AddOrder(Order newOrder)
        {
            int sum = 0;
            foreach (OrderItem oi in newOrder.OrderItems)
            {
                Product p = await _productRepository.GetProductById(oi.ProductId);
                sum+=p.Price;
            }
            if (sum != newOrder.Sum)
                throw new Exception("mismatch with order sum");
            return await _orderRepository.AddOrder(newOrder);
        }
        public async Task<List<Order>> GetAllOrders(int page)
        {
            return await _orderRepository.GetAllOrders(page);
        }

    }
}
