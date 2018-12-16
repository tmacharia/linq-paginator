using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class MathExts
    {
        
        /// <summary>
        /// Validates if an <see cref="int"/> has a value greater than 0.
        /// </summary>
        /// <param name="i">Value to check.</param>
        /// <returns>true or false</returns>
        public static bool IsPositive(this int i) => i > -1;
    }
}
