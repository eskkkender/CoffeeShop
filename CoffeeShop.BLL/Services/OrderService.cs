using System;
using CoffeeShop.BLL.DTO;
using CoffeeShop.DAL.Entities;
using CoffeeShop.BLL.BusinessModels;
using CoffeeShop.DAL.Interfaces;
using CoffeeShop.BLL.Infrastructure;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.DAL;
using System.Collections.Generic;
using AutoMapper;

namespace CoffeeShop.BLL.Services
{
    public class OrderService : IOrderService
    {

        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeOrder(OrderDTO orderDto)
        {
            Coffee coffee = Database.Coffee.Get(orderDto.CoffeeId);

            // валидация
            if (coffee == null)
                throw new ValidationException("Товар не найден", "");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(coffee.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Adress = orderDto.Adress,
                CoffeeId = orderDto.Id,
                Sum = sum,
                Phone = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<CoffeeDTO> GetCoffees()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Coffee, CoffeeDTO>()).CreateMapper();                   
            return mapper.Map<IEnumerable<Coffee>, List<CoffeeDTO>>(Database.Coffee.GetAll());
        }

        public CoffeeDTO GetCoffee(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            var coffee = Database.Coffee.Get(id.Value);
            if (coffee == null)
                throw new ValidationException("Телефон не найден", "");

            return new CoffeeDTO {  Id = coffee.CoffeeId, Name = coffee.Name, Price = coffee.Price };
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
