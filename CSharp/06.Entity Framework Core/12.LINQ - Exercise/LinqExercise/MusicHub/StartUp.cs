using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.Initializer;
using System;
using System.Linq;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();
            DbInitializer.ResetDatabase(context);
            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        /// <summary>
        /// Export all albums which are produced by the provided Producer Id. 
        /// For each Album, get the Name, Release date in format the "MM/dd/yyyy", Producer Name, 
        /// the Album Songs with each Song Name, Price (formatted to the second digit) and the Song Writer Name. 
        /// Sort the Songs by Song Name (descending) and by Writer (ascending). 
        /// At the end export the Total Album Price with exactly two digits after the decimal place. 
        /// Sort the Albums by their Total Price (descending).
        /// </summary>
        /// <param name="context"></param>
        /// <param name="producerId"></param>
        /// <returns></returns>
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    Name = a.Name,
                    ReleaseDate = $"{a.ReleaseDate:MM/dd/yyyy}",
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = $"{s.Price:F2}",
                            Writer = s.Writer.Name
                        }),
                    TotalPrice = a.Price
                })
                .ToList();


            foreach (var album in albums.OrderByDescending(a => a.TotalPrice))
            {
                int counter = 1;
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:F2}");
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Export the songs which are above the given duration. 
        /// For each Song, export its Name, Performer Full Name, Writer Name, Album Producer and Duration (in format("c")). 
        /// Sort the Songs by their Name (ascending), by Writer (ascending) and by Performer (ascending)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context.Songs
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerName = s.SongPerformers.FirstOrDefault() != null ? s.SongPerformers.FirstOrDefault().Performer.FirstName + " " + s.SongPerformers.FirstOrDefault().Performer.LastName : string.Empty,
                    WriterName = s.Writer.Name,
                    ProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerName)
                .ToList();

            for (int i = 0; i < songs.Count; i++)
            {
                var song = songs[i];
                sb.AppendLine($"-Song #{i + 1}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerName}");
                sb.AppendLine($"---AlbumProducer: {song.ProducerName}");
                sb.AppendLine($"---Duration: {song.Duration}");

            }

            return sb.ToString().Trim();
        }
    }
}
