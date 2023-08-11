using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.domain.Models
{
    public class IAuditEntity
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedUser { get; set; }

    }
}
