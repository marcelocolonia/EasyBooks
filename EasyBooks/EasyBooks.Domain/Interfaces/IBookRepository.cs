using System;
using System.Collections.Generic;

namespace EasyBooks.Domain
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IList<T> GetAll(Func<T, bool> filter);
        T Find(long id);
        void Save(long id, T entity);
        void Create(T entity);
        void Delete(long id);
    }
}
