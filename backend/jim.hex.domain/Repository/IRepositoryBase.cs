using jim.hex.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.domain.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : AggregateRoot
    {

        /// <summary>
        /// add a entity into a ddbb
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task Add(TEntity entity, CancellationToken cancellationToken = default);
        /// <summary>
        /// delete a entity into a ddbb
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task Delete(TEntity entity);
        /// <summary>
        /// Update a entity into a ddbb
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task Update(TEntity entity);
        /// <summary>
        /// get a list of entity 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Find(CancellationToken cancellationToken = default);
        /// <summary>
        /// get a list of entity passing a filter
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        /// <summary>
        /// get a list of entity passing a filter and its relations required
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Find<TProperty>(Expression<Func<TEntity, bool>> where, IEnumerable<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default);
        /// <summary>
        /// get a list of entity passing  its relations required
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Find<TProperty>(IEnumerable<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default);
        /// <summary>
        /// get a entity by id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> FindById(int id, CancellationToken cancellationToken);
        /// <summary>
        /// get a entity by id and its required relations
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> FindById(int id, List<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default);
        /// <summary>
        /// get a list of entity without cache
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken = default);
        /// <summary>
        /// get a list of entity WITHOUT CACHE with determinate filter
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
        /// <summary>
        /// get a list of entity WITHOUT CACHE with its relations and relations
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> where, IEnumerable<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default);
        /// <summary>
        /// get a list of entity WITHOUT CACHE with its relations
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Get(IEnumerable<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default);
        

        






    }
}
