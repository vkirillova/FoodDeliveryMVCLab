using System.Collections.Generic;
using FoodDeliveryMVCLab.Models.Dishes;
using FoodDeliveryMVCLab.Models.Restaurants;

namespace FoodDeliveryMVCLab.Services.Restaurants
{
    public interface IRestaurantService
    {
        DishViewModel GetAllRestaurantDishes(int restaurantId);
        IEnumerable<RestaurantViewModel> GetAllRestaurants();
    }
}
