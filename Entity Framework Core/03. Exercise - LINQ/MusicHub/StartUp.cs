namespace MusicHub
{
    using System;
    using System.Diagnostics.Metrics;
    using System.Reflection;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context
                .Producers.First(p => p.Id == producerId)
                .Albums.Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                            .Select(s => new
                            {
                                SongName = s.Name,
                                SongPrice = s.Price,
                                SongWriterName = s.Writer.Name
                            })
                            .OrderByDescending(s => s.SongName)
                            .ThenBy(s => s.SongWriterName),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int counter = 1;

                if (album.Songs.Any())
                {
                    foreach (var song in album.Songs)
                    {
                        sb.AppendLine($"---#{counter}");
                        sb.AppendLine($"---SongName: {song.SongName}");
                        sb.AppendLine($"---Price: {song.SongPrice:f2}");
                        sb.AppendLine($"---Writer: {song.SongWriterName}");

                        counter++;
                    }

                    sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsInfo = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    SongWriter = s.Writer.Name,
                    Performers = s.SongPerformers
                        .Select(s => new
                        {
                            PerformerFirstName = s.Performer.FirstName,
                            PerformerLastName = s.Performer.LastName
                        })
                        .OrderBy(s => s.PerformerFirstName)
                        .ToList(),
                    AlbumProducer = s.Album.Producer.Name,
                    SongDuration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.SongWriter)
                .ToList();

            StringBuilder sb = new StringBuilder();

            int counter = 1;

            foreach (var song in songsInfo)
            {
                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.SongWriter}");

                if (song.Performers.Any())
                {
                    foreach (var performer in song.Performers)
                    {
                        sb.AppendLine($"---Performer: {performer.PerformerFirstName} {performer.PerformerLastName}");
                    }
                }
                
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.SongDuration}");

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
