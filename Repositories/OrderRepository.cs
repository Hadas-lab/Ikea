using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IkeaContext _ikeaContext;

        public OrderRepository(IkeaContext ikeaContext)
        {
            _ikeaContext = ikeaContext;
        }

        public async Task<Order> AddOrder(Order newOrder)
        {
            await _ikeaContext.Orders.AddAsync(newOrder);
            await _ikeaContext.SaveChangesAsync();
            return newOrder;
        }

        public async Task<List<Order>> GetAllOrders(int page)
        {
            return await _ikeaContext.Orders.Include(o => o.User).ToListAsync();
        }
    }
}
