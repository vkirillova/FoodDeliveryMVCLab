using System;
using System.Linq;
using FoodDeliveryMVCLab.Services.Dish;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryMVCLab.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            if (dishService == null)
                throw new ArgumentNullException(nameof(dishService));
            _dishService = dishService;
        }

        public IActionResult Index(int restId)
        {
            var models = _dishService.GetAllRestaurantDishesById(restId).ToList();
            return View(models);
        }
    }
}
