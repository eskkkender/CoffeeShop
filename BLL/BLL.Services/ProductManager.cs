﻿using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using DTO;
using DAL.Abstraction;
using DAL.Entities;
using AutoMapper;
using System;

namespace BLL.Services
{
    public class ProductManager : Manager, IProductManager
    {

        public ProductManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {         
        }

        /// <summary>
        /// Получить товар по ИД
        /// </summary>
        /// <param name="id">ИД товара</param>
        /// <returns></returns>
        public ProductDTO GetProductId(int id)
        {
            var dss = _unitOfWork.Repository<IProductRepository>().Get(id);
            _unitOfWork.SaveChanges();
            return Mapper.Map<Product, ProductDTO>(dss);
        }

        public void AddProduct(ProductDTO product)
        {
            var products = Mapper.Map<ProductDTO, Product>(product);
            _unitOfWork.Repository<IProductRepository>().Create(products);
            _unitOfWork.SaveChanges();            
        }

        public void EditProduct(ProductDTO product)
        {
            var repository = _unitOfWork.Repository<IProductRepository>();
            var products = repository.Get(product.Id);
            products.Price = product.Price;
            products.Name = product.Name;
            products.Description = product.Description;
            products.FileUrl = product.FileUrl;
            _unitOfWork.Repository<IProductRepository>().Update(products);
            _unitOfWork.SaveChanges();
        }

        public List<ProductDTO> GetAllProducts()
        {
            var product = _unitOfWork.Repository<IProductRepository>().GetAll();
            return Mapper.Map<IQueryable<Product>, List<ProductDTO>>(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.Repository<IProductRepository>().Get(id);
            _unitOfWork.Repository<IProductRepository>().Delete(product);
            _unitOfWork.SaveChanges();
        }
    } 
}