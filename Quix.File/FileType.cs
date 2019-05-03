#pragma warning disable IDE1006 // Naming Styles

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
            int byteRead = 0;
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
            int byteRead = 0;
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
