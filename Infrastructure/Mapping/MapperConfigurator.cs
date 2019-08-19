using AutoMapper;
using DTO;
using DAL.Entities;
using WebUI.Models;

namespace Mapping
{
    public static class MapperConfigurator
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
           {
               cfg.CreateMap<Product, ProductDTO>();
               cfg.CreateMap<ProductDTO, Product>();
               cfg.CreateMap<ProductDTO, ProductViewModel>();
               cfg.CreateMap<ProductViewModel, ProductDTO>();
           });
        }
    }
}
