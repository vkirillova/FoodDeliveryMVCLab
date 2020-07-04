using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FoodDeliveryMVCLab.DAL.DbContext;
using FoodDeliveryMVCLab.Models.Dishes;

namespace FoodDeliveryMVCLab.Services.Dish
{
    public class DishService : IDishService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public DishService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public List<DishViewModel> GetAllRestaurantDishes(int restaurantId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var dish = unitOfWork.Dishes.GetById(restaurantId);
                var model = Mapper.Map<List<DishViewModel>>(dish);

                return model;
            }
        }

        public IEnumerable<DishRestModel> GetAllRestaurantDishesById(int restaurantId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                IEnumerable<FoodDeliveryMVCLab.DAL.Entities.Dish> dishes = unitOfWork.Dishes.GetAll().Where(id=>id.RestaurantId.Equals(restaurantId));
                List<DishRestModel> dishRestModels = Mapper.Map<List<DishRestModel>>(dishes);
                return dishRestModels;
            }
        }

        public IEnumerable<DishViewModel> GetAllDishes()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                IEnumerable<FoodDeliveryMVCLab.DAL.Entities.Dish> dishes = unitOfWork.Dishes.GetAll();
                List<DishViewModel> dishViewModels = Mapper.Map<List<DishViewModel>>(dishes);
                return dishViewModels;
            }
        }
    }
}