using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopCore.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public Pizza() { }
        
        public Pizza(int Id, string Type, int Price)
        {
            this.Type = Type;
            this.Price = Price;
            this.Id = Id;
           
        }



    }
}
