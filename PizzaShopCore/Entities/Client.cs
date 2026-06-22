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
        //public string Identity { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }

        public string Password { get; set; }
        //אולי צריך לשנות את הקשרי גומלין כאן ולעשות את ה-ORDERS בתוך הקונסטרקטור
        //public ICollection<Order> Orders { get; set; } = new List<Order>();

        public Client() { }
        public Client(int Id, string ClientName,string Address,string Pass)
        {
            this.Address = Address;
            this.Id = Id;
            this.ClientName = ClientName;
            this.Password = Pass;


        }
    }
}
