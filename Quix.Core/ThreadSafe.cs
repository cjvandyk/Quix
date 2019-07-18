using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Quix.Core
{
    public static class ThreadSafe
    {
        /// <summary>
        /// ReaderWriterLockSlim object used in managing thread safety.
        /// </summary>
        private static ReaderWriterLockSlim readerWriterLockSlim = 
            new System.Threading.ReaderWriterLockSlim();

        /// <summary>
        /// Get method to retrieve an object from the provided Dictionary.
        /// </summary>
        /// <param name="key">The key value to be used for Dictionary 
        /// retrieval.</param>
        /// <param name="dictionary">The Dictionary object.</param>
        /// <param name="timout">The timeout value in milliseconds while 
        /// waiting to obtain the lock.  This prevents the thread from heading
        /// off to lala land and never returning.  It defaults to 60 seconds,
        /// but it should be noted that the TryEntryReadLock() that consumes
        /// this value is of type "int" so the maximum value that can be passed
        /// is 65535.</param>
        /// <returns>The object retrieved from the given Dictionary.</returns>
        public static object Get(string key, Dictionary<string, object> dictionary, int timout = 60000)
        {
            readerWriterLockSlim.TryEnterReadLock(timout);
            try
            {
                return dictionary[key];
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }
    }
}
