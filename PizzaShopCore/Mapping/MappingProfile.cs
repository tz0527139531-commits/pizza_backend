using AutoMapper;
using PizzaShopCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShopCore.Entities;


namespace PizzaShopCore.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<Client, ClientDTO>().ReverseMap();
          
            //            CreateMap<OrderDTO, Order>().ReverseMap();

            CreateMap<OrderDTO, Order>()
            .ForMember(dest => dest.OrderId, opt => opt.Ignore());
            // או dest.Id - תלוי איך קראת לזה במחלקת ההזמנה האמיתית

            CreateMap<Pizza, PizzaDTO>().ReverseMap();
          

        }

    }
}
