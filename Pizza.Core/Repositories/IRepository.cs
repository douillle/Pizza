using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        ValueTask<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        ValueTask<TEntity> GetByString(string text);
    }
}
