using System;
using System.Diagnostics;
using System.Linq;
using FoodDeliveryMVCLab.Models;
using FoodDeliveryMVCLab.Services.Restaurants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoodDeliveryMVCLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestaurantService _restaurantService;

        public HomeController(ILogger<HomeController> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            if (restaurantService == null)
                throw new ArgumentNullException(nameof(restaurantService));
            _restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            var models = _restaurantService.GetAllRestaurants();
            return View(models.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
