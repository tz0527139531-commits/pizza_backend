using PizzaShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopCore.Repositiers
{
    public interface IOrderRepositiers
    {
        public List<Order> GetAll();
        public Order Get(int id);
        public Task PostAsync(Order Order);
        public Task PutAsync(Order Order);
        public Task DeleteAsync(int id);
    }
}
