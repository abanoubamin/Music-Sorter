using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSorterApp
{
    public class sort_by_Title : IComparer<MP3Tag_and_nameOf_MP3>
    {
        public int Compare(MP3Tag_and_nameOf_MP3 m1, MP3Tag_and_nameOf_MP3 m2)
        {
            return (m1.Title.CompareTo(m2.Title));
        }
    }
    public class sort_by_Artist : IComparer<MP3Tag_and_nameOf_MP3>
    {
        public int Compare(MP3Tag_and_nameOf_MP3 m1, MP3Tag_and_nameOf_MP3 m2)
        {
            return (m1.Artist.CompareTo(m2.Artist));
        }
    }
    public class sort_by_Album : IComparer<MP3Tag_and_nameOf_MP3>
    {
        public int Compare(MP3Tag_and_nameOf_MP3 m1, MP3Tag_and_nameOf_MP3 m2)
        {
            return (m1.Album.CompareTo(m2.Album));
        }
    }
    public class sort_by_Year : IComparer<MP3Tag_and_nameOf_MP3>
    {
        public int Compare(MP3Tag_and_nameOf_MP3 m1, MP3Tag_and_nameOf_MP3 m2)
        {
            return (m1.Year.CompareTo(m2.Year));
        }
    }

    public class sort_by_Genere : IComparer<MP3Tag_and_nameOf_MP3>
    {
        public int Compare(MP3Tag_and_nameOf_MP3 m1, MP3Tag_and_nameOf_MP3 m2)
        {
            return (m1.Genere.CompareTo(m2.Genere));
        }
    }
    public class sort_by_Durat : IComparer<MP3Tag_and_nameOf_MP3>
    {
        public int Compare(MP3Tag_and_nameOf_MP3 m1, MP3Tag_and_nameOf_MP3 m2)
        {
            return (m1.Duration.CompareTo(m2.Duration));
        }
    }
    public class paths
    {
        private static string[] _files;
        private static string from_path;
        public void set_files(string[] files)
        {
            _files = files;
        }
        public string[] get_files()
        {
            return _files;
        }

        public void set_from_path(string f_path)
        {
            from_path = f_path;
        }
        public string get_from_path()
        {
            return from_path;
        }
    }
}
