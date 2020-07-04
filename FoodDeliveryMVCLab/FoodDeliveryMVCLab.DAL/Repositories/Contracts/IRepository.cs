using System.Collections.Generic;
using FoodDeliveryMVCLab.DAL.Entities;

namespace FoodDeliveryMVCLab.DAL.Repositories.Contracts
{
    public interface IRepository<T> where T: IEntity
    {
        T Create(T entity);

        T GetById(int id);

        IEnumerable<T> GetAll();

        T Update(T entity);

        void Remove(T entity);
    }
}