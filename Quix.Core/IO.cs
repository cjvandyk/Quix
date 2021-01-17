#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060, IDE0079 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args, Remove unnecessary suppression)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;

/// <summary>
/// Core utilities for the Quix project.
/// </summary>
namespace Quix.Core
{
    /// <summary>
    /// The IO class provides the ability to serialize ANY object.
    /// </summary>
    public static class IO
    {
        /// <summary>
        /// Enum used to differentiate file types.
        /// </summary>
        public enum IOType
        {
            Binary//, JSON, Text, XML  //Not implemented yet.
        }

        /// <summary>
        /// The Container class is used to serialize any given object.
        /// </summary>
        [Serializable]
        public class Container
        {
            public DateTime exp;  //Expiration date/time stamp.
            public object obj;    //The object being serialized.
        }

        /// <summary>
        /// Overloaded method used to serialize any object to disk.
        /// </summary>
        /// <typeparam name="T">Generic type of object.</typeparam>
        /// <param name="objectToSave">The target object to serialize.</param>
        /// <param name="filePath">The path to save the object on disk.</param>
        /// <param name="fileType">The type of object being serialized.</param>
        /// <returns>Bool indicating success.</returns>
        public static bool Save<T>(T objectToSave, 
                                   string filePath = "Data.bin", 
                                   IOType fileType = IOType.Binary)
        {
            //By default expiration is set to one year.
            return Save(objectToSave, 
                        DateTime.UtcNow.AddYears(1), 
                        filePath, 
                        fileType);
        }

        /// <summary>
        /// Overloaded method used to serialize any object to disk.
        /// </summary>
        /// <typeparam name="T">Generic type of object.</typeparam>
        /// <param name="objectToSave">The target object to serialize.</param>
        /// <param name="expiration">The expiration date/time.</param>
        /// <param name="filePath">The path to save the object on disk.</param>
        /// <param name="fileType">The type of object being serialized.</param>
        /// <param name="append">Append to existing file?</param>
        /// <returns>Bool indicating success.</returns>
        public static bool Save<T>(T objectToSave, 
                                   DateTime expiration, 
                                   string filePath = "Data.bin", 
                                   IOType fileType = IOType.Binary, 
                                   bool append = false)
        {
            Container container = new Container();
            container.exp = expiration;
            container.obj = objectToSave;
            return Save(container, true, filePath, fileType, append);
        }

        /// <summary>
        /// Overloaded method used to serialize any object to disk.
        /// </summary>
        /// <param name="objectToSave">The target object to serialize.</param>
        /// <param name="forceThisMethod">Future expansion.</param>
        /// <param name="filePath">The path to save the object on disk.</param>
        /// <param name="fileType">The type of object being serialized.</param>
        /// <param name="append">Append to existing file?</param>
        /// <returns>Bool indicating success.</returns>
        public static bool Save(object objectToSave, 
                                bool forceThisMethod, 
                                string filePath = "Data.bin", 
                                IOType fileType = IOType.Binary, 
                                bool append = false)
        {
            try
            {
                //Create a stream to the file.
                using (System.IO.Stream stream = System.IO.File.Open(filePath, append ? System.IO.FileMode.Append : System.IO.FileMode.Create))
                {
                    //Use a BinaryFormatter to serialize.
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, objectToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Dump error.
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = currentColor;
                return false;
            }
        }


    }
}
