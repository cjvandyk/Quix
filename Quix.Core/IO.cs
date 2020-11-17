using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quix.Core
{
    public static class IO
    {
        public enum IOType
        {
            Binary, JSON, Text, XML
        }

        [Serializable]
        public class Container
        {
            public DateTime exp;
            public object obj;
        }

        public static bool Save<T>(T objectToSave, string filePath = "Data.bin", IOType fileType = IOType.Binary)
        {
            return Save(objectToSave, DateTime.UtcNow.AddYears(1), filePath, fileType);
        }

        public static bool Save<T>(T objectToSave, DateTime expiration, string filePath = "Data.bin", IOType fileType = IOType.Binary, bool append = false)
        {
            Container container = new Container();
            container.exp = expiration;
            container.obj = objectToSave;
            return Save(container, true, filePath, fileType, append);
        }

        public static bool Save(object objectToSave, bool forceThisMethod, string filePath = "Data.bin", IOType fileType = IOType.Binary, bool append = false)
        {
            try
            {
                using (System.IO.Stream stream = System.IO.File.Open(filePath, append ? System.IO.FileMode.Append : System.IO.FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, objectToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Logging.Err(ex.ToString(), 0);
                return false;
            }
        }
    }
}
