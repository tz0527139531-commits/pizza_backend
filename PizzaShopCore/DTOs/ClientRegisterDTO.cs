using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopCore.DTOs
{
    public class ClientRegisterDTO
    {
        public int Id { get; set; }
        //public string Identity { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
