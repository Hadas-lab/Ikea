using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order newOrder);
        Task<List<Order>> GetAllOrders();
    }
}