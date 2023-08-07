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
        /// return a list of entities trackeada
        /// </summary>
        /// <returns></returns>
        IQueryable<List<TEntity>> GetAll();
        /// <summary>
        /// return a list of entities trackeada
        /// </summary>
        /// <returns></returns>
        IQueryable<List<TEntity>> GetAll(List<Expression<Func<TEntity>>> includes);
        IQueryable<List<TEntity>> GetAll(CancellationToken cancellationToken);

        TEntity GetById(int id);

        TEntity GetById(int id, List<Expression<Func<TEntity,bool>>> include);
        TEntity GetById(int id, List<Expression<Func<TEntity, bool>>> include,CancellationToken cancellationToken);


    }
}
