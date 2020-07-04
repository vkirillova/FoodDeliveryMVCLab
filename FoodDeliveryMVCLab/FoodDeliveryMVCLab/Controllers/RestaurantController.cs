using System;
using FoodDeliveryMVCLab.Services.Dish;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryMVCLab.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IDishService _dishService;

        public RestaurantController(IDishService dishService)
        {
            _dishService = dishService;
            if (dishService == null)
                throw new ArgumentNullException(nameof(dishService));
            _dishService = dishService;
        }
        public IActionResult Index(int restaurantId)
        {
            var models = _dishService.GetAllRestaurantDishes(restaurantId);
            return View(models);
        }

    }
}