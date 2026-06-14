using AutoMapper;
using PizzaShopCore.DTOs;
using PizzaShopCore.Entities;
using PizzaShopCore.Repositiers;
using PizzaShopCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositiers _order;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepositiers order,IMapper mapper)
        {
           _order = order;
            _mapper = mapper;
        }

        public IEnumerable<OrderDTO> GetList()
        {
            var list = _order.GetAll();
            return _mapper.Map<List<OrderDTO>>(list);
        }
        public OrderDTO GetById(int id)
        {
            var o = _order.Get(id);
            return _mapper.Map<OrderDTO>(o);
        }
        public async Task PostOrderAsync(OrderDTO order)
        {
            var o = _mapper.Map<Order>(order);
           await _order.PostAsync(o);
        }
        public async Task UpdateOrderAsync(OrderDTO order)
        {
            var o = _mapper.Map<Order>(order);
            await _order.PutAsync(o);
        }
        public async Task DeleteOrderAsync(int id)
        {
           await _order.DeleteAsync(id);
        }
    }
}
