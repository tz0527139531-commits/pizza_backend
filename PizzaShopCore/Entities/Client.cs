using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopCore.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public Client() { }
        public Client(int Id, string ClientName)
        {
           
            this.Id = Id;
            this.ClientName = ClientName;
         
        }
    }
}
