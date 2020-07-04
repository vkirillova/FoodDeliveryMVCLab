using ClassLibrary.DAL.Entities;
using ClassLibrary.DAL.EntityConfigurations.Contracts;

namespace ClassLibrary.DAL.EntityConfigurations
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