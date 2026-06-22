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
            //CreateMap<Pizza, PizzaDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Client, ClientRegisterDTO>().ReverseMap();


            CreateMap<OrderDTO, Order>().ReverseMap();

            //CreateMap<OrderDTO, Order>()
            //.ForMember(dest => dest.OrderId, opt => opt.Ignore());
            // או dest.Id - תלוי איך קראת לזה במחלקת ההזמנה האמיתית


           
          

        }

    }
}
