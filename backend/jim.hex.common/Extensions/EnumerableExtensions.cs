using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jim.hex.common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool HasContent<T>(this IEnumerable<T> list )
        {
            return list != null && list.Any();
        }

        public static bool NotHasContent<T>(this IEnumerable<T> list )
        {
            return !list.HasContent();
        }
    }
}
