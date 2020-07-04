using System.Collections.Generic;
using ClassLibrary.DAL.Entities;

namespace ClassLibrary.DAL.Repositories.Contracts
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
