using ClassLibrary.DAL.DbContext;
using ClassLibrary.DAL.Entities;
using ClassLibrary.DAL.Repositories.Contracts;

namespace ClassLibrary.DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Orders;
        }
    }
}