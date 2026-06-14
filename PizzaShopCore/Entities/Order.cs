using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopCore.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public Client client { get; set; }
        public int ClientId { get; set; }
        public List<Pizza> list { get; set; } = new List<Pizza>();
   
        public Order() { }
        public Order(int OrderId, Client client)
        {
            this.OrderId = OrderId;
            this.client = client;
        
        }
    }
}
