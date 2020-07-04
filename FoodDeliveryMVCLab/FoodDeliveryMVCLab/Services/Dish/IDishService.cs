using System.Collections.Generic;
using FoodDeliveryMVCLab.Models.Dishes;

namespace FoodDeliveryMVCLab.Services.Dish
{
    public interface IDishService
    {
        List<DishViewModel> GetAllRestaurantDishes(int restaurantId);
        IEnumerable<DishViewModel> GetAllDishes();
        IEnumerable<DishRestModel> GetAllRestaurantDishesById(int restaurantId);
    }
}
