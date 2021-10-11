using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Services
{
   public interface ICrud<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> All();
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(string id);
        Task Update(TEntity entity);

        Task<TEntity> GetById(int Id);
        Task<TEntity> GetById(string Id);
    }
}
