using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShopCore.Entities;
using PizzaShopCore.Repositiers;


namespace PizzaShopData.Repositories
{
    public class PizzaRepository:IPizzaRepositery
    {
        private readonly DataContext _context;

        public PizzaRepository(DataContext context)
        {
            this._context = context;
        }

        public List<Pizza>GetAll()
        {
            return _context.pizzas.ToList();
        }
        public Pizza Get(int id)
        {
            var p=_context.pizzas.ToList().Find(Y=>Y.Id==id);
            return p;
        }
        public async Task PostAsync(Pizza Pizza)
        {
            _context.pizzas.Add(Pizza);
           await _context.SaveChangesAsync();
        }
        public async Task PutAsync(Pizza Pizza)
        {
            var p=_context.pizzas.ToList().Find(u=>u.Id==Pizza.Id);
            if(p!=null) 
            {
             p.Type = Pizza.Type;
             p.Price = Pizza.Price;
             await _context.SaveChangesAsync();
            }
           
        }
        public async Task DeleteAsync(int id)
        {
            var p = _context.pizzas.ToList().Find(u => u.Id == id);
            _context.pizzas.Remove(p);  
            await _context.SaveChangesAsync();
        }
    }
}
