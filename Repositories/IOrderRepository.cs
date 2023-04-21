using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order newOrder);
        Task<List<Order>> GetAllOrders(int page);
    }
}