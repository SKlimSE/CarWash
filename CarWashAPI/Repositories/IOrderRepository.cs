using CarWashAPI.Models;

namespace CarWashAPI.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrder(long id);
        Order CreateOrder(Order order);
        void UpdateOrder(long id, Order updatedOrder);
        void DeleteOrder(long id);
    }
}
