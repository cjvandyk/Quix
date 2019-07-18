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
        public static object Get(string key, 
            Dictionary<string, object> dictionary, int timeout = 60000)
        {
            //Setup the Read lock with the given timeout.
            //The Read lock will allow other concurrent reads to take place.
            readerWriterLockSlim.TryEnterReadLock(timeout);
            //Setup try/finally block so the lock is always released.
            try
            {
                //Attempt to access and return the value from the dictionary.
                return dictionary[key];
            }
            //Code that always execute no matter what.
            finally
            {
                //Release the lock.
                readerWriterLockSlim.ExitReadLock();
            }
        }

        /// <summary>
        /// Set method to update an object in the given Dictionary.
        /// </summary>
        /// <param name="value">The value that will be replacing the existing
        /// object in the Dictionary.</param>
        /// <param name="key">The key value to be used for Dictionary 
        /// targeting of the update.</param>
        /// <param name="dictionary">The Dictionary to be updated.</param>
        /// <param name="timout">The timeout value in milliseconds while 
        /// waiting to obtain the lock.  This prevents the thread from heading
        /// off to lala land and never returning.  It defaults to 60 seconds,
        /// but it should be noted that the TryEntryWriteLock() that consumes
        /// this value is of type "int" so the maximum value that can be passed
        /// is 65535.</param>
        /// <returns>"true" if successful, otherwise the exception.</returns>
        public static string Set(object value, string key, 
            Dictionary<string, object> dictionary, int timeout = 60000)
        {
            //Setup the Write lock with the given timeout.
            //The Write lock will take an exclusive lock after all current
            //read and write operations complete.
            readerWriterLockSlim.TryEnterWriteLock(timeout);
            //Setup try/catch/finally block so the lock is always released.
            try
            {
                //Attempt to update the value at the key index.
                dictionary[key] = value;
            }
            //Something went wrong, catch the exception.
            catch (Exception ex)
            {
                //Return the exception string for caller inspection.
                return ex.ToString();
            }
            finally
            {
                //Release the lock.
                readerWriterLockSlim.ExitWriteLock();
            }
            //Update was successful.  Return "true".
            return "true";
        }
    }
}
