using AutoMapper;

namespace FoodDeliveryMVCLab
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateUniversalMap<Restaurant, RestaurantViewModel>();
            //CreateUniversalMap<Dish, DishViewModel>();
            //CreateUniversalMap<Dish, DishRestModel>();
            //CreateUniversalMap<Dish, ShoppingCartViewModel>();
            //CreateUniversalMap<DishViewModel, ShoppingCartViewModel>();
        }

        private void CreateUniversalMap<From, To>()
        {
            CreateMap<From, To>();
            CreateMap<To, From>();
        }
    }
}