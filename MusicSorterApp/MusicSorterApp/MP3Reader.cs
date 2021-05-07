using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;

namespace MusicSorterApp
{
    class MP3Reader
    {
        string fileName;
        FileStream stream;
        const int SIZE = 128;
        byte[] tagData;
        string name_of_path;
        public MP3Reader(string path)
        {
            name_of_path = Path.GetFileName(path);
            tagData = new byte[SIZE];
            this.fileName = path;
            this.stream = new FileStream(this.fileName, FileMode.Open);
        }

        public MP3Tag_and_nameOf_MP3 getTag()
        {
            string title, artist, album, year, comment, genere;
            title = artist = album = year = comment = genere = "";

            stream.Seek(stream.Length - 128, SeekOrigin.Begin);
            stream.Read(tagData, 0, SIZE);
            stream.Close();

            byte b1 = tagData[0];
            byte b2 = tagData[1];
            byte b3 = tagData[2];

            if ((char)b1 != 'T' || (char)b2 != 'A' || (char)b3 != 'G')
            {
                throw new Exception("Not an MP3 Format File");
            }

            for (int i = 3; i < 33; i++)
            {
                if (tagData[i] != 0)
                    title += (char)tagData[i];

            }
            for (int i = 33; i < 63; i++)
            {
                if (tagData[i] != 0)
                    artist += (char)tagData[i];
            }
            for (int i = 63; i < 93; i++)
            {
                if (tagData[i] != 0)
                    album += (char)tagData[i];
            }
            for (int i = 93; i < 97; i++)
            {
                if (tagData[i] != 0)
                    year += (char)tagData[i];
            }
            comment = tagData[97].ToString();
            genere = tagData[127].ToString();

            MP3Tag_and_nameOf_MP3 tag = new MP3Tag_and_nameOf_MP3(title, artist, album, year, comment, genere, name_of_path);

            return tag;
        }
    }
}
