using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс хелперов и экстеншенов 
    /// </summary>
    internal static class HelpsAndExtensions
    {
        /// <summary>
        /// Выбирает минимальное значение из последовательности или возвращает дефолтное
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static T MinOrDefault<T>(this IEnumerable<T> sequence)
        {
            if (sequence.Any())
            {
                return sequence.Min();
            }
            else
            {
                return default(T);
            }
        }   
    }
}
