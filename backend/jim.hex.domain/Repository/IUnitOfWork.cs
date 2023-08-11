using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.domain.Repository
{
    public interface IUnitOfWork
    {
        public Task SaveChanges(CancellationToken cancellationToken = default);
    }
}
