using jim.hex.common.Audit;
using jim.hex.common.Extensions;
using jim.hex.domain.Models;
using jim.hex.domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace jim.hex.infraestructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : AggregateRoot
    {
        private readonly DbContext _context;
        private readonly IAuditContext<AuditUser> _auditContext;
        private DbSet<TEntity> _dbSet;

        public RepositoryBase(DbContext context, IAuditContext<AuditUser> auditContext)
        {
            _context = context;
            _auditContext = auditContext;
            _dbSet = context.Set<TEntity>();
        }

        #region Crud
        
        public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException($"entity {typeof(TEntity).Name} cannot be null");

            await _dbSet.AddAsync(entity, cancellationToken);

        }
        
        public async Task Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException($"entity {typeof(TEntity).Name} cannot be null");
            _dbSet.Update(entity);
        }
        
        public async Task Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException($"entity {typeof(TEntity).Name} cannot be null");
            _dbSet.Remove(entity);
        }
        #endregion

        #region Search for without cache
       
        public async Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }
       
        public async Task<IEnumerable<TEntity>> Get(IEnumerable<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();
            query = Includes(query, includes);
            return await query.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {
            return await Where(where)
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);

        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> where, IEnumerable<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default)
        {
            var query = Where(where);
            query = Includes(query, includes);
            return await query
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
        }
        #endregion
        public async Task<IEnumerable<TEntity>> Find(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }


        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {

            return await Where(where)
                   .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> Find<TProperty>(IEnumerable<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default)
        {
            return await Includes(_dbSet.AsQueryable(), includes)
                   .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> Find<TProperty>(Expression<Func<TEntity, bool>> where, IEnumerable<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default)
        {
            var query = Where(where);
            query = Includes(query, includes);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<TEntity> FindById(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<TEntity> FindById(int id, List<Expression<Func<TEntity, object>>> includes, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();
            query = Includes(query, includes);
            return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }


       


        private IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            if (where != null)
            {
                return _dbSet.Where(where);
            }
            return _dbSet.AsQueryable();
        }

        private IQueryable<TEntity> Includes(IQueryable<TEntity> query, IEnumerable<Expression<Func<TEntity, object>>> includes)
        {


            if (includes.HasContent())
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }


    }
}
