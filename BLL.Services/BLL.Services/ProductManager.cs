using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            var product = UnitOfWork.ProductRepository.GetAll().FirstOrDefault(a => a.Id == id);
            return Mapper.Map<Product, ProductDTO>(product);
        }

        public void AddProduct(ProductDTO product)
        {
            var products = Mapper.Map<ProductDTO, Product>(product);
            UnitOfWork.ProductRepository.Create(products);
            UnitOfWork.SaveChanges();            
        }

        public List<ProductDTO> GetAllProducts()
        {
            var product = UnitOfWork.ProductRepository.GetAll();
            return Mapper.Map< IQueryable<Product>, List<ProductDTO>>(product);
        }


    }
  
}