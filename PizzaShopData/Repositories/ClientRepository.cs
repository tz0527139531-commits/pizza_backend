using PizzaShopCore.Entities;
using PizzaShopCore.Repositiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShopData.Repositories
{
    public class ClientRepository:IClientRepositery
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            this._context = context;
        }
        public List<Client> GetAll()
        {
            return _context.clients.ToList();
        }
        public Client Get(int id)
        {
            var client = _context.clients.ToList().Find(y=>y.Id==id);
            return client;
        }
        public async Task PostAsync(Client client)
        {
            _context.clients.Add(client);
            await _context.SaveChangesAsync();
        }
        public async Task PutAsync(Client client)
        {
            var c = _context.clients.ToList().Find(y => y.Id == client.Id);
            if (c != null)
            {
               // c.ClientAddres=client.ClientAddres;
                c.ClientName = client.ClientName;
               await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            var client = _context.clients.ToList().Find(y => y.Id == id);
            _context.clients.Remove(client);  
           await _context.SaveChangesAsync(); 
        }
    }
}
