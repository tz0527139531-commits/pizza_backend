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
        public IEnumerable<PizzaDTO> GetList();
        public PizzaDTO GetById(int id);
        public Task PostPizzaAsync(PizzaDTO pizza);
        public Task UpdatePizzaAsync(PizzaDTO pizza);
        public Task DeletePizzaAsync(int id);
        
    }
}
