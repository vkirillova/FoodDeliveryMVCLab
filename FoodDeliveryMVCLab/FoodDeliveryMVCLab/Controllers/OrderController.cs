using System;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.Models.Orders;
using FoodDeliveryMVCLab.Services.Dish;
using FoodDeliveryMVCLab.Services.Orders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryMVCLab.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderService _orderService;
        private readonly IDishService _dishService;

        public OrderController(UserManager<User> userManager, IOrderService orderService, IDishService dishService)
        {
            _userManager = userManager;
            _orderService = orderService;
            _dishService = dishService;
        }

        [HttpGet("Order/{dishId?}")]
        public IActionResult Create(int? dishId)
        {
            if (!dishId.HasValue)
                throw new ArgumentOutOfRangeException(nameof(dishId));

            var model = _orderService.GetOrderCreateModel(dishId.Value);

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderCreateModel model)
        {
            _orderService.CreateOrder(model);

            return RedirectToAction("Index", "Dish");
        }

        [HttpGet("Orders")]
        public IActionResult Index(int dishId, User user)
        {
            var orders = _orderService.GetOrdersList();
            return View(orders);
        }
    }
}