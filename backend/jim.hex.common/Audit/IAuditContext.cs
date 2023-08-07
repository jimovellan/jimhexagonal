using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.common.Audit
{
    public interface IAuditContext<T> where T: AuditUser
    {
        T GetUser();
        bool IsAutenticate();
        bool IsInRole(string roleName);
    }
}
