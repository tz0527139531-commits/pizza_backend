using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PizzaShopCore.DTOs;
using PizzaShopCore.Entities;
using PizzaShopCore.Repositiers;
using PizzaShopCore.Services;

namespace PizzaShopService
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepositery _pizzaRepositery;
        private readonly IMapper _mapper;
        public PizzaService(IPizzaRepositery r, IMapper mapper)
        {
            _pizzaRepositery = r;
            _mapper = mapper;
        }

        public IEnumerable<PizzaDTO> GetList()
        {
            //TODO 
            var l=_pizzaRepositery.GetAll();
            return _mapper.Map<IEnumerable<PizzaDTO>>(l);
        }

        public PizzaDTO GetById(int id)
        {
            var t=_pizzaRepositery.Get(id);
            return _mapper.Map<PizzaDTO>(t);
        }
        public async Task PostPizzaAsync(PizzaDTO pizza)
        {
            var f = _mapper.Map<Pizza>(pizza);
            await _pizzaRepositery.PostAsync(f);
        }
        public async Task UpdatePizzaAsync(PizzaDTO pizza)
        {
            var t = _mapper.Map<Pizza>(pizza);
           await _pizzaRepositery.PutAsync(t);
        }
        public async Task DeletePizzaAsync(int id)
        {
            await _pizzaRepositery.DeleteAsync(id);
        }

    }
}
