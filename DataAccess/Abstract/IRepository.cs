using MyAxiaMarket1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyAxiaMarket1.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        public IQueryable<TEntity> FindAll();
        Task<GetManyResult<TEntity>> GetAllAsync();
        Task<GetManyResult<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);

        Task<GetOneResult<TEntity>> GetByIdAsync(int id);
        Task<GetOneResult<TEntity>> InsertOneAsync(TEntity entity);

        Task<GetManyResult<TEntity>> InsertManyAsync(ICollection<TEntity> entities);

        Task<GetOneResult<TEntity>> ReplaceOneAsync(TEntity entity, int id);
        Task<GetOneResult<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter);

        Task<GetOneResult<TEntity>> DeleteByIdAsync(int id);
    }
}
