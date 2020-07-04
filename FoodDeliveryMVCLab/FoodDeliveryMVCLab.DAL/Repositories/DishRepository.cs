using System.Collections.Generic;
using System.Linq;
using FoodDeliveryMVCLab.DAL.DbContext;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMVCLab.DAL.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Dishes;
        }

        public IEnumerable<Dish> GetAllByPrice(decimal priceFrom, decimal priceTo)
        {
            return GetAllDishes()
                .Where(p => p.Price >= priceFrom && p.Price <= priceTo)
                .ToList();
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            return entities
                .Include(e => e.Restaurant).ToList();
        }

        public Dish GetByIdWithRestaurant(int id)
        {
            return GetAllDishes().FirstOrDefault(p => p.Id == id);
        }
    }
}
