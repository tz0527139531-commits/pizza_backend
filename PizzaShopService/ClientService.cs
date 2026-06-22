using PizzaShopCore.Entities;
using PizzaShopCore.Mapping;
using PizzaShopCore.DTOs;
using PizzaShopCore.Repositiers;
using PizzaShopCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace PizzaShopService
{
    public class ClientService:IClientService
    {
        private readonly IClientRepositery _client;
        private readonly IMapper _mapping;
        public ClientService(IClientRepositery client, IMapper mapping)
        {
            _client = client;
            _mapping = mapping;
        }
        /*
        public List<Client> GetList()
        {
            //TODO
           
            return _client.GetAll();
        }
        */
        public IEnumerable<ClientDTO> GetList()
        {
            //TODO
            var clients=_client.GetAll();
            return _mapping.Map<IEnumerable<ClientDTO>>(clients);
        }
        public ClientDTO GetById(int id)
        {
            //TODO
            var c = _client.Get(id);
            return _mapping.Map<ClientDTO>(c);
        }
        public async Task PostClientAsync(ClientRegisterDTO client)
        {
            //TODO
            var ClientAdd=_mapping.Map<Client>(client);
            await _client.PostAsync(ClientAdd);
        }
        //public async Task PostClientAsync(ClientDTO client)
        //{
        //    //TODO
        //    var ClientAdd = _mapping.Map<Client>(client);
        //    await _client.PostAsync(ClientAdd);
        //}
        public async Task UpdateClientAsync(ClientDTO client)
        {
            //TODO
            var clientUpdate=_mapping.Map<Client>(client);
            await _client.PutAsync(clientUpdate);
        }
        public async Task DeleteClientAsync(int id)
        {
            //TODO
           await _client.DeleteAsync(id);
        }
    }
}
