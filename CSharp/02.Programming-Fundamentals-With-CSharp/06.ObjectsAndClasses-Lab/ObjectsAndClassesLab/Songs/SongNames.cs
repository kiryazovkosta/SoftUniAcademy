// ------------------------------------------------------------------------------------------------
//  <copyright file="SongNames.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace Songs
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class SongNames
    {
        private static void Main(string[] args)
        {
            int songsNumber = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(songsNumber)));
            var songs = new List<Song>();
            for (var i = 0; i < songsNumber; i++)
            {
                var song = Console.ReadLine().Split("_", StringSplitOptions.RemoveEmptyEntries);
                songs.Add(new Song {TypeList = song[0], Name = song[1], Time = song[2]});
            }

            var type = Console.ReadLine();
            var result = songs.Select(s => s.TypeList).ToList();
            if (type == "all")
            {
                var names = songs.Select(s => s.Name).ToList();
                Console.WriteLine(string.Join(Environment.NewLine, names));
            }
            else
            {
                var names = songs.Where(s => s.TypeList == type).Select(s => s.Name);
                Console.WriteLine(string.Join(Environment.NewLine, names));
            }
        }
    }

    public class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}