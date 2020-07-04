using System.Collections.Generic;
using FoodDeliveryMVCLab.DAL.Entities;

namespace FoodDeliveryMVCLab.DAL.Repositories.Contracts
{
    public interface IDishRepository: IRepository<Dish>
    {
        IEnumerable<Dish> GetAllByPrice(decimal priceFrom, decimal priceTo);
        IEnumerable<Dish> GetAllDishes();
        Dish GetByIdWithRestaurant(int id);
    }
}
