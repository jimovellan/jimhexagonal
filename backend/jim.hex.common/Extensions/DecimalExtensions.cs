using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace jim.hex.common.Extensions
{


    public static class DecimalExtensions
    {
        /// <summary>
        /// Determinate if a decimal contains 
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static bool HasDecimal(this decimal dec)
        {
            return dec % 1 != 0;
        }
    }
}
