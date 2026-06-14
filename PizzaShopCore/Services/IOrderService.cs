using PizzaShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShopCore.DTOs;

namespace PizzaShopCore.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderDTO> GetList();
        public OrderDTO GetById(int id);
        public Task PostOrderAsync(OrderDTO Order);
        public Task UpdateOrderAsync(OrderDTO Order);
        public Task DeleteOrderAsync(int id);
    }
}
