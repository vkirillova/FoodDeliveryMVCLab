using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.DAL.EntityConfigurations.Contracts;

namespace FoodDeliveryMVCLab.DAL.EntityConfigurations
{
    public class EntityConfigurationsContainer : IEntityConfigurationsContainer
    {
        public IEntityConfiguration<Dish> DishConfiguration { get; }
        public IEntityConfiguration<Restaurant> RestaurantConfiguration { get; }
        public IEntityConfiguration<Order> OrderConfiguration { get; }

        public EntityConfigurationsContainer()
        {
            DishConfiguration = new DishConfiguration();
            RestaurantConfiguration = new RestaurantConfiguration();
            OrderConfiguration = new OrderConfiguration();
        }
    }
}