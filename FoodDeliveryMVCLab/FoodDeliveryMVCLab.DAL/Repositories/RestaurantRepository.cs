using ClassLibrary.DAL.DbContext;
using ClassLibrary.DAL.Entities;
using ClassLibrary.DAL.Repositories.Contracts;

namespace ClassLibrary.DAL.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Restaurants;
        }

    }
}