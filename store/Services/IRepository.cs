using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Services
{
   public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable <TEntity> All { get; }
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        void Update(TEntity entity);

        TEntity GetById(int Id);
        TEntity GetById(string Id);
    }
}
