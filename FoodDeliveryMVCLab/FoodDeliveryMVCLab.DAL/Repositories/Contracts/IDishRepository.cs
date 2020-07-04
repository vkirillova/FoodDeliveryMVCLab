using System.Collections.Generic;
using ClassLibrary.DAL.Entities;

namespace ClassLibrary.DAL.Repositories.Contracts
{
    public interface IDishRepository: IRepository<Dish>
    {
        IEnumerable<Dish> GetAllByPrice(decimal priceFrom, decimal priceTo);
        IEnumerable<Dish> GetAllDishes();
        Dish GetByIdWithRestaurant(int id);
    }
}
