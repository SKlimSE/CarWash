using CarWashAPI.Models;
using CarWashAPI.DAL;
using Microsoft.EntityFrameworkCore;

namespace CarWashAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CWDataContext _db;

        public OrderRepository(CWDataContext db)
        {
            _db = db;
        }
        
        public List<Order> GetAllOrders()
        {
            return _db.Orders.AsNoTracking().ToList();
        }        

        public Order CreateOrder(Order order)
        {
            order.DateOfServiceProvision = DateTime.Now;

            _db.Orders.Add(order);
            _db.SaveChanges();
            return order;
        }

        public void DeleteOrder(long id)
        {
            Order order = GetOrder(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
                _db.SaveChanges();
            }
        }


        public Order GetOrder(long id)
        {
            return _db.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void UpdateOrder(long id, Order updatedOrder)
        {
            Order order = GetOrder(id);
            if (order == null)
            {
                throw new EntityNotFoundException<Order>(id);
            }

            order.NameService = updatedOrder.NameService;
            order.Amount = updatedOrder.Amount;
            order.Price = updatedOrder.Price;
            _db.SaveChanges();
        }

        private bool OrderExists(long orderId)
        {
            return _db.Orders.Any(o => o.Id == orderId);
        }
    }
}
