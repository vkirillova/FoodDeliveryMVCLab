using FoodDeliveryMVCLab.DAL.DbContext;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.DAL.Repositories.Contracts;

namespace FoodDeliveryMVCLab.DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Orders;
        }
    }
}