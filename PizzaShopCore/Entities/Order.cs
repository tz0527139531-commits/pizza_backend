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
        //יש כאן כפילות מסוימת השאלה אם צריך את קוד הלקוח כשיש לקוח
        public int ClientId { get; set; }
        public DateTime date { get; set; }
        public List<Pizza> list { get; set; } = new List<Pizza>();
        public double TotalPrice { get; set; } = 0;

        public Order() { }
        public Order(int OrderId,Client client,int ClientId,DateTime date)
        {
            this.OrderId = OrderId;
            this.client = client;
            this.ClientId = ClientId;
            this.date = date;

        }
    }
}
