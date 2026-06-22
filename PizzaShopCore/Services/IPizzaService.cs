using PizzaShopCore.DTOs;
using PizzaShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzaShopCore.Services
{
    public interface IPizzaService
    {
        public IEnumerable<Pizza> GetList();
        public Pizza GetById(int id);
        public Task PostPizzaAsync(Pizza pizza);
        public Task UpdatePizzaAsync(Pizza pizza);
        public Task DeletePizzaAsync(int id);
        
    }
}
