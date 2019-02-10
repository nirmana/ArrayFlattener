using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArrayFlattener
{
    /// <summary>
    /// Flattener processor class. This will hold logices of array flattning    
    /// </summary>
    public static class Flattener
    {
        /// <summary>
        /// this method will iterate through arrays and return flatten array using recursion
        /// this works not only with integers but also strings
        /// </summary>
        /// <param name="ArrayOfArrays"></param>
        /// <returns>Flattend Ienumarable object</returns>
        public static IEnumerable<object> Flatten(IEnumerable<object> ArrayOfArrays)
        {
            Func<IEnumerable<object>, IEnumerable<object>> flatten = null;
            flatten = s => s.SelectMany(x => x is Array ? flatten(((IEnumerable)x).Cast<object>()) :
            Enumerable.Repeat(x, 1));

            return flatten(ArrayOfArrays);
        }



    }
}
