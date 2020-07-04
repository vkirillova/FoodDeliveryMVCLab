using AutoMapper;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.Models.Dishes;
using FoodDeliveryMVCLab.Models.Orders;
using FoodDeliveryMVCLab.Models.Restaurants;
using FoodDeliveryMVCLab.Models.ShoppingCart;

namespace FoodDeliveryMVCLab
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateUniversalMap<Restaurant, RestaurantViewModel>();
            CreateUniversalMap<Dish, DishViewModel>();
            CreateUniversalMap<Dish, DishRestModel>();
            CreateUniversalMap<Dish, ShoppingCartViewModel>();
            CreateUniversalMap<DishViewModel, ShoppingCartViewModel>();
            CreateUniversalMap<Dish, OrderViewModel>();
        }

        private void CreateUniversalMap<From, To>()
        {
            CreateMap<From, To>();
            CreateMap<To, From>();
        }
    }
}