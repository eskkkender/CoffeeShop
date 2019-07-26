using AutoMapper;
using DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class MapperConfigurator
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
           {
               cfg.CreateMap<Product, ProductDTO>();
               cfg.CreateMap<ProductDTO, Product>();
           });
        }
    }
}
