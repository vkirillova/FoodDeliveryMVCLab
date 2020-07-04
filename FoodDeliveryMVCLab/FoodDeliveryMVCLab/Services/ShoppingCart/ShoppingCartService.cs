using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryMVCLab.DAL.DbContext;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.Models.ShoppingCart;
using FoodDeliveryMVCLab.Services.Dish;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace FoodDeliveryMVCLab.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly UserManager<User> _userManager;
        private readonly IDishService _dishService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ShoppingCartService(UserManager<User> userManager, IDishService dishService, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userManager = userManager;
            _dishService = dishService;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task AddToShoppingCartAsync(int dishId, User user)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var dish = unitOfWork.Dishes.GetById(dishId);
                if (dish == null)
                    throw new ArgumentOutOfRangeException(nameof(dishId), $"No dish with id {dishId}");
                var bucketItems = string.IsNullOrWhiteSpace(user.ShoppingCart) ?
                    CreateShoppingCart(dishId) :
                    UpdateShoppingCart(dishId, user.ShoppingCart);
                user.ShoppingCart = JsonConvert.SerializeObject(bucketItems);
                await _userManager.UpdateAsync(user);
            }
        }

        public List<ShoppingCartViewModel> CreateShoppingCart(int dishId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var dish = unitOfWork.Dishes.GetById(dishId);
                return new List<ShoppingCartViewModel>()
                {
                    new ShoppingCartViewModel()
                    {
                        DishId = dishId,
                        DishName = dish.Name,
                        Quantity = 1,
                        TotalPrice = dish.Price
                    }
                };
            }
        }

        public List<ShoppingCartViewModel> UpdateShoppingCart(int dishId, string currentBucket)
        {
            try
            {
                var currentItems = JsonConvert.DeserializeObject<List<ShoppingCartViewModel>>(currentBucket);
                var existingItem = currentItems.FirstOrDefault(c => c.DishId == dishId);

                var dish = _unitOfWorkFactory.Create().Dishes.GetById(dishId);
                if (existingItem != null)
                {
                    existingItem.DishName = dish.Name;
                    existingItem.Quantity++;
                    existingItem.TotalPrice = existingItem.Quantity++ * dish.Price;
                }
                else
                {
                    currentItems.Add(
                        new ShoppingCartViewModel()
                        {
                            DishId = dishId,
                            DishName = dish.Name,
                            Quantity = 1,
                            TotalPrice = dish.Price
                        }
                    );
                }

                return currentItems;
            }
            catch
            {
                return CreateShoppingCart(dishId);
            }
        }

        public List<ShoppingCartViewModel> GetShoppingCart(string currentCart)
        {
            var currentItems = JsonConvert.DeserializeObject<List<ShoppingCartViewModel>>(currentCart);

            return currentItems;

        }
    }
}