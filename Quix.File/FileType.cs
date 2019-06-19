#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk  
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// Source code has been held to 80 character width for printing and porting
/// reasons.
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;

namespace Quix.File
{
    public class FileType
    {
        public enum Content 
        {
            Binary = 0x0000,
            Text = 0x0001,
            Lock = 0x0002,
            Unknown = 0x0003
        }

        public Quix.File.FileType.Content ContentType { get; set; }

        public FileType(string fileUri)
        {
            int byteRead;
            using (System.IO.Stream targetFile = new System.IO.FileStream(fileUri, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                ContentType = Content.Text;
                for (int i = 0; i < targetFile.Length; i++)
                {
                    byteRead = targetFile.ReadByte();
                    if (byteRead == 0)
                    {
                        ContentType = Quix.File.FileType.Content.Binary;
                        break;
                    }

                }
            }
        }

        public static Quix.File.FileType.Content getFileType(string fileUri)
        {
            int byteRead;
            try
            {
                using (System.IO.Stream targetFile = new System.IO.FileStream(fileUri, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    for (int i = 0; i < targetFile.Length; i++)
                    {
                        byteRead = targetFile.ReadByte();
                        if (byteRead == 0)
                        {
                            return Quix.File.FileType.Content.Binary;
                            break;
                        }
                    }
                }
                return Quix.File.FileType.Content.Text;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("because it is being used by another process"))
                {
                    return Quix.File.FileType.Content.Lock;
                }
                return Quix.File.FileType.Content.Unknown;
            }
        }

    }
}
