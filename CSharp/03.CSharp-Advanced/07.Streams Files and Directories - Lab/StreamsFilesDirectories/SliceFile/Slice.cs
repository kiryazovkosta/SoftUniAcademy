namespace SliceFile
{
    using System;
    using System.IO;

    public class Slice
    {
        public static void Main(string[] args)
        {
            using FileStream reader = new FileStream("sliceMe.txt", FileMode.Open, FileAccess.Read, FileShare.None);

            long fileLength = reader.Length;
            int parts = 4;
            long singleLength = (long)Math.Ceiling(fileLength / (parts * 1.0));
            for (int i = 1; i <= parts; i++)
            {
                byte[] buffer = new byte[singleLength];
                reader.Read(buffer);

                using FileStream writer = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer.Write(buffer);
            }
        }
    }
}
