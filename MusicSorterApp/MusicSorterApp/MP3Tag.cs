using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSorterApp
{

    [Serializable]
    public class MP3Tag_and_nameOf_MP3
    {
        public string Mp3_Name { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string Comment { get; set; }
        public string Genere { get; set; }
        public TimeSpan Duration { get; set; }
        public MP3Tag_and_nameOf_MP3()
        {
            this.Title = "";
            this.Artist = "";
            this.Album = "";
            this.Year = "";
            this.Comment = "";
            this.Genere = "";
            this.Mp3_Name = "";

        }
        public MP3Tag_and_nameOf_MP3(string title, string artist, string album, string year, string comment, string genre, string mp3_Name)
        {
            this.Title = title;
            this.Artist = artist;
            this.Album = album;
            this.Year = year;
            this.Comment = comment;
            this.Genere = genre;
            this.Mp3_Name = mp3_Name;
        }

    }
}
