using System.Collections.Generic;
using System.Linq;
using FoodDeliveryMVCLab.DAL.DbContext;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMVCLab.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private ApplicationDbContext _context;
        protected DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            var entityEntry = entities.Add(entity);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public T GetById(int id)
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return entities;
        }

        public T Update(T entity)
        {
            var entityEntry = _context.Update(entity);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }

    }
}