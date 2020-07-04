using System;
using System.Collections.Generic;
using AutoMapper;
using FoodDeliveryMVCLab.DAL.DbContext;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.Models.Dishes;
using FoodDeliveryMVCLab.Models.Restaurants;

namespace FoodDeliveryMVCLab.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public RestaurantService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public DishViewModel GetAllRestaurantDishes(int restaurantId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var dish = unitOfWork.Dishes.GetById(restaurantId);
                var model = Mapper.Map<DishViewModel>(dish);

                return model;
            }
        }

        public IEnumerable<RestaurantViewModel> GetAllRestaurants()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                IEnumerable<Restaurant> restaurants = unitOfWork.Restaurants.GetAll();
                List<RestaurantViewModel> restaurantViewModels = Mapper.Map<List<RestaurantViewModel>>(restaurants);

                return restaurantViewModels;
            }
        }
    }
}