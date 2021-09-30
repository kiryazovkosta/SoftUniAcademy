namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class Program
    {
        public static void Main(string[] args)
        {
            string file = "copyMe.png";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string archiveFile = Path.Combine(path, "archive.zip");

            if (File.Exists(archiveFile))
            {
                File.Delete(archiveFile);
            }

            using (var archiver = ZipFile.Open(archiveFile, ZipArchiveMode.Create))
            {
                archiver.CreateEntryFromFile(file, Path.GetFileName(file));
            }

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            using (var archiver = ZipFile.Open(archiveFile, ZipArchiveMode.Read))
            {
                archiver.ExtractToDirectory(Directory.GetCurrentDirectory());
            }
        }
    }
}
