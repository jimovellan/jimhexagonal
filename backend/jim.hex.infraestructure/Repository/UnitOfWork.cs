using jim.hex.common.Audit;
using jim.hex.common.Extensions;
using jim.hex.domain.Models;
using jim.hex.domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.infraestructure.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IAuditContext<AuditUser> _auditContext;

        public UnitOfWork(DbContext context, IAuditContext<AuditUser> auditContext)
        {
            _context = context;
            _auditContext = auditContext;
        }

        /// <summary>
        /// Save all entitie's changes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            if (!_context.ChangeTracker.HasChanges()) return;

            var entities = _context.ChangeTracker.Entries().Where(w => w.State != EntityState.Unchanged);

            CheckStatusOfEntitiesWithChanges(entities);

            CheckExistEventsGeneratedByDomain(entities);
        }

        private static void CheckExistEventsGeneratedByDomain(IEnumerable<EntityEntry> entities)
        {
            var events = entities
                         .Where(w => w.Entity is AggregateRoot ar && ar.Events.HasContent())
                         .SelectMany(s => ((AggregateRoot)s.Entity).Events);
        }

        /// <summary>
        /// Check the entitie's status to execute actions relations by 
        /// </summary>
        /// <param name="entities"></param>
        private void CheckStatusOfEntitiesWithChanges(IEnumerable<EntityEntry> entities)
        {
            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        SoftDelete(entity);
                        break;
                    case EntityState.Modified:
                    case EntityState.Added:
                        AuditEntity(entity);
                        break;

                }
            }
        }

        private void AuditEntity(EntityEntry entity)
        {
            if(entity.Entity is IAuditEntity  entityAudited)
            {
                if(entity.State == EntityState.Added)
                {
                    entityAudited.CreatedAt = DateTime.UtcNow;
                    entityAudited.CreatedUser = _auditContext.GetUser().UserName;
                }
                else
                {
                    entityAudited.ModifiedAt = DateTime.UtcNow;
                    entityAudited.ModifiedUser = _auditContext.GetUser().UserName;
                }
            }
        }

        private void SoftDelete(EntityEntry entity)
        {
            if (entity.Entity is ISoftDelete entitySoftDelete)
            {
                entitySoftDelete.DeletedAt = DateTime.Now;
                entitySoftDelete.DeletedUser = _auditContext.GetUser().UserName;
            }
        }
    }
}
