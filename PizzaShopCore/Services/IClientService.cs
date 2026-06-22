using PizzaShopCore.Entities;
using PizzaShopCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopCore.Services
{
    public interface IClientService
    {
        public IEnumerable<ClientDTO>GetList();
        public ClientDTO GetById(int id);
        public  Task PostClientAsync(ClientRegisterDTO client);
        public Task UpdateClientAsync(ClientDTO client);
        public Task DeleteClientAsync(int id);
    }
}
