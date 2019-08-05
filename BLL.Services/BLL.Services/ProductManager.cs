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
            var dss = _unitOfWork.Repository<IProductRepository>().GetAll;
            var product = _unitOfWork.Repository<Product>().Get(id);
            return Mapper.Map<Product, ProductDTO>(product);
        }

        public void AddProduct(ProductDTO product)
        {
            var products = Mapper.Map<ProductDTO, Product>(product);
            _unitOfWork.Repository<Product>().Create(products);
            _unitOfWork.SaveChanges();            
        }

        public List<ProductDTO> GetAllProducts()
        {
            var product = _unitOfWork.Repository<Product>().GetAll();
            return Mapper.Map<IQueryable<Product>, List<ProductDTO>>(product);
        }

        public void DeleteProduct(int id)
        {
            var ProductId = GetProductId(id);
            var product = Mapper.Map<ProductDTO, Product>(ProductId);
            _unitOfWork.Repository<Product>().Delete(product);
            _unitOfWork.SaveChanges();
        }
    } 
}