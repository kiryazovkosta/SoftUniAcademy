namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinary
    {
        public static void Main(string[] args)
        {
            using FileStream reader = new FileStream("copyMe.png", FileMode.Open, FileAccess.Read);
            using FileStream writer = new FileStream("result.png", FileMode.Create, FileAccess.Write);

            byte[] buffer = new byte[1024];
            int readerBytes;

            while ((readerBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                writer.Write(buffer, 0, readerBytes);
            }
        }
    }
}
