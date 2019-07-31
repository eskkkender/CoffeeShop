using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using DTO;
using DAL.Abstraction;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services
{
    public class ProductManager :  Manager, IProductManager
    {
        public ProductManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ProductDTO GetProductId(int id)
        {
            var product = UnitOfWork.Repository<Product>().Get(id);
            return Mapper.Map<Product, ProductDTO>(product);
        }

        public void AddProduct(ProductDTO product)
        {
            var products = Mapper.Map<ProductDTO, Product>(product);
            UnitOfWork.Repository<Product>().Create(products);
            UnitOfWork.SaveChanges();            
        }

        public List<ProductDTO> GetAllProducts()
        {
            var product = UnitOfWork.Repository<Product>().GetAll();
            return Mapper.Map<IQueryable<Product>, List<ProductDTO>>(product);
        }


    }
  
}