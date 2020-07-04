using System;
using System.Threading.Tasks;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.Services.Dish;
using FoodDeliveryMVCLab.Services.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryMVCLab.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IDishService _dishService;

        public ShoppingCartController(UserManager<User> userManager, IShoppingCartService shoppingCartService, IDishService dishService)
        {
            _userManager = userManager;
            _shoppingCartService = shoppingCartService;
            _dishService = dishService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(int? dishId)
        {
            if (!dishId.HasValue)
            {
                ViewBag.BadRequestMessage = "Your cart is empty";
                return View("BadRequest");
            }
            try
            {
                User currentUser = await _userManager.GetUserAsync(User);
                await _shoppingCartService.AddToShoppingCartAsync(dishId.Value, currentUser);
                return RedirectToAction("Index", "Dish", 3);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await _userManager.GetUserAsync(User);
            if (currentUser.ShoppingCart == null)
            {
                ViewBag.BadRequestMessage = "Your cart is empty";
                return View("BadRequest");
            }
            var model = _shoppingCartService.GetShoppingCart(currentUser.ShoppingCart);
            return View(model);
        }
    }
}