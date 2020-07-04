
using ClassLibrary.DAL.Entities;

namespace ClassLibrary.DAL.EntityConfigurations.Contracts
{
    public interface IEntityConfigurationsContainer
    {
        IEntityConfiguration<Dish> DishConfiguration { get; }
        IEntityConfiguration<Restaurant> RestaurantConfiguration { get; }
        IEntityConfiguration<Order> OrderConfiguration { get; }
    }
}
