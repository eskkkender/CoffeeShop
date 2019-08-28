using AutoMapper;
using DTO;
using DAL.Entities;

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
