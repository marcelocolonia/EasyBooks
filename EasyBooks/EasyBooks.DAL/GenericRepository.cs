using EasyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBooks.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public void Create(T entity)
        {
            var data = JsonHelper.FetchDataFromJson<T>();

            entity.ID = DateTime.Now.ToBinary();
            data.Add(entity);

            JsonHelper.CreateJson<T>(data);
        }

        public void Delete(long id)
        {
            var data = JsonHelper.FetchDataFromJson<T>();

            data.RemoveAt(data.FindIndex(x => x.ID.Equals(id)));

            JsonHelper.CreateJson<T>(data);
        }

        public T Find(long id)
        {
            return GetAll(x => x.ID.Equals(id)).First();
        }

        public IList<T> GetAll(Func<T, bool> filter)
        {
            return JsonHelper.FetchDataFromJson<T>().Where(filter).ToList();
        }

        public void Save(long id, T entity)
        {
            var data = JsonHelper.FetchDataFromJson<T>();

            data[data.FindIndex(x => x.ID.Equals(id))] = entity;

            JsonHelper.CreateJson<T>(data);
        }
    }
}
