using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.domain.Models
{
    public interface ISoftDelete
    {
        public DateTime? DeletedAt { get; set; }
        public string? DeletedUser { get; set; }
    }
}
