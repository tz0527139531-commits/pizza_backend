using PizzaShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopCore.Repositiers
{
    public interface IClientRepositery
    {
        public List<Client> GetAll();
        public Client Get(int id);
        public Task PostAsync(Client client);
        public Task PutAsync(Client client);
        public Task DeleteAsync(int id);
    }
}
