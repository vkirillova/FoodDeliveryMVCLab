using System;
using ClassLibrary.DAL.Repositories;
using ClassLibrary.DAL.Repositories.Contracts;

namespace ClassLibrary.DAL.DbContext
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public IDishRepository Dishes { get; }
        public IRestaurantRepository Restaurants { get; }
        public IOrderRepository Orders { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Dishes = new DishRepository(context);
            Restaurants = new RestaurantRepository(context);
            Orders = new OrderRepository(context);
        }

        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(_disposed)
                return;

            if(disposing)
                _context.Dispose();

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
