using PizzaShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopCore.Repositiers
{
    public interface IPizzaRepositery
    {
        public List<Pizza> GetAll();
        public Pizza Get(int id);
        public Task PostAsync(Pizza Pizza);
        public Task PutAsync(Pizza Pizza);
        public Task DeleteAsync(int id);
    }
}
