/********************************************************************************
 * CSHARP Collections Library - General utility to manipulate collections
 * 
 * LICENSE: Free to use provided details on fixes and/or extensions emailed to 
 *          chris.williams@readwatchcreate.com
 ********************************************************************************/

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CSHARP.Collections
{
    /// <summary>
    /// Assists with manipulation of dictionaries including merging
    /// </summary>
    public static class DictionaryHelper
    {
        /// <summary>
        /// Merges two dictionaries (if exists will overwrite existing item)
        /// </summary>
        /// <typeparam name="T">the dictionary</typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="me"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        /// <remarks>From StackOverflow suggestion https://stackoverflow.com/questions/294138/merging-dictionaries-in-c-sharp
        /// </remarks>
        public static void MergeOverwrite<T1, T2>(this ConcurrentDictionary<T1, T2> dictionary, IDictionary<T1, T2> newElements)
        {
            if (newElements == null || newElements.Count == 0) return;

            foreach (var ne in newElements)
            {
                // if key exists we are replacing
                dictionary.AddOrUpdate(ne.Key, ne.Value, (key, value) => value);
            }
        }

        /// <summary>
        /// Merges two dictionaries (if item exists will keep existing item and skip the one in dictionary passed in)
        /// </summary>
        /// <typeparam name="T">the dictionary</typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="me"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        /// <remarks>From StackOverflow suggestion https://stackoverflow.com/questions/294138/merging-dictionaries-in-c-sharp
        /// </remarks>
        public static void MergeNewOnly<T1, T2>(this ConcurrentDictionary<T1, T2> dictionary, IDictionary<T1, T2> newElements)
        {
            if (newElements == null || newElements.Count == 0) return;

            foreach (var ne in newElements)
            {
                // if key exists we skip adding
                if (dictionary.ContainsKey(ne.Key) == false)
                {
                    dictionary.AddOrUpdate(ne.Key, ne.Value, (key, value) => value);
                }
            }
        }
    }
}
