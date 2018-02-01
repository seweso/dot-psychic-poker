using System;
using System.Collections.Generic;
using System.Linq;

namespace dot_psychic_poker_console
{
    public static class EnumUtil
    {
        /// <summary>
        ///     Read values from enum and cast to correct type 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
