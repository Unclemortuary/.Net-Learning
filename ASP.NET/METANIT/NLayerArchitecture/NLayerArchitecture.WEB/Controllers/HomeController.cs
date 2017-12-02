using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerArchitecture.BLL.Interfaces;
using NLayerArchitecture.BLL.DTO;
using NLayerArchitecture.WEB.Models;
using AutoMapper;
using NLayerArchitecture.BLL.Infrastructure;

namespace NLayerArchitecture.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<PhoneDTO> phoneDtos = orderService.GetPhones();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<PhoneDTO, PhoneViewModel>());
            var phones = Mapper.Map<IEnumerable<PhoneDTO>, List<PhoneViewModel>>(phoneDtos);
            return View(phones);
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                PhoneDTO phone = orderService.GetPhone(id);
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<PhoneDTO, OrderViewModel>()
                    .ForMember("PhoneId", opt => opt.MapFrom(src => src.Id)));
                var order = Mapper.Map<PhoneDTO, OrderViewModel>(phone);
                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>());
                var orderDto = Mapper.Map<OrderViewModel, OrderDTO>(order);
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}