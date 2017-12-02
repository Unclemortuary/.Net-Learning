using System;
using NLayerArchitecture.BLL.DTO;
using NLayerArchitecture.DAL.Entities;
using NLayerArchitecture.BLL.BusinessModels;
using NLayerArchitecture.DAL.Interfaces;
using NLayerArchitecture.BLL.Infrastructure;
using NLayerArchitecture.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace NLayerArchitecture.BLL.Services
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
            Phone phone = Database.Phones.Get(orderDto.PhoneId);

            // валидация
            if (phone == null)
                throw new ValidationException("Телефон не найден", "");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                PhoneId = phone.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<PhoneDTO> GetPhones()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Phone, PhoneDTO>());
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Phone, PhoneDTO>());
            return Mapper.Map<IEnumerable<Phone>, List<PhoneDTO>>(Database.Phones.GetAll());
        }

        public PhoneDTO GetPhone(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            var phone = Database.Phones.Get(id.Value);
            if (phone == null)
                throw new ValidationException("Телефон не найден", "");
            // применяем автомаппер для проекции Phone на PhoneDTO
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Phone, PhoneDTO>());
            return Mapper.Map<Phone, PhoneDTO>(phone);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
