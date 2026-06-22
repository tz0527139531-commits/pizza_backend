using PizzaShopCore.Entities;
using PizzaShopCore.Repositiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopData.Repositories
{
    public class OrderRepository:IOrderRepositiers
    {

        private readonly DataContext _context;
      
        public OrderRepository(DataContext context)
        {
            this._context = context;
        }

        public List<Order> GetAll()
        {
            return _context.orders.ToList();
        }
        public Order Get(int id)
        {
            var p = _context.orders.ToList().Find(Y => Y.OrderId == id);
            return p;
        }
        public async Task PostAsync(Order order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();
        }
        public async Task PutAsync(Order order)
        {
            var p = _context.orders.ToList().Find(u => u.OrderId == order.OrderId);
            if (p != null)
            {
                
                p.date=order.date;
                p.client=order.client;
                p.ClientId=order.ClientId;
                p.list=order.list;
                
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var p = _context.orders.ToList().Find(u => u.OrderId == id);
            _context.orders.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}
