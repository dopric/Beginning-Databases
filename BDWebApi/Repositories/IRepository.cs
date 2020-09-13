using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDWebApi.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}
