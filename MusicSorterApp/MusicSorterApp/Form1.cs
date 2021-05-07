using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NAudio;
using NAudio.Wave;

namespace MusicSorterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileStream fs=new FileStream("mp3.txt",FileMode.Truncate);
            fs.Close();
            metroExpander1.State = 0;
            ArtistComboBox();
            TitleComboBox();
            GenreComboBox();
            AlbumComboBox();
            YearComboBox();
        }
        //Fills the artist combobox
        public void ArtistComboBox()
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<string> list = new List<string>();

            int count = 0;

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);

                if (list.Count == 0)
                {
                    metroComboBox2.Items.Add(Tag.Artist);
                    list.Add(Tag.Artist);
                    continue;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == Tag.Artist)
                        count++;
                }

                if (count == 0)
                {
                    metroComboBox2.Items.Add(Tag.Artist);
                    list.Add(Tag.Artist);
                }

                count = 0;
            }

            FS.Close();
        }
        //Fills the Title combobox
        public void TitleComboBox()
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<string> list = new List<string>();

            int count = 0;

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);

                if (list.Count == 0)
                {
                    metroComboBox1.Items.Add(Tag.Title);
                    list.Add(Tag.Title);
                    continue;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == Tag.Title)
                        count++;
                }

                if (count == 0)
                {
                    metroComboBox1.Items.Add(Tag.Title);
                    list.Add(Tag.Title);
                }

                count = 0;
            }

            FS.Close();
        }
        //Fills the Genre comboBox 
        public void GenreComboBox()
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<string> list = new List<string>();

            int count = 0;

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);

                if (list.Count == 0)
                {
                    metroComboBox5.Items.Add(Tag.Genere);
                    list.Add(Tag.Genere);
                    continue;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == Tag.Genere)
                        count++;
                }

                if (count == 0)
                {
                    metroComboBox5.Items.Add(Tag.Genere);
                    list.Add(Tag.Genere);
                }

                count = 0;
            }

            FS.Close();
        }
        //Fills the Album comboBox
        public void AlbumComboBox()
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<string> list = new List<string>();

            int count = 0;

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);

                if (list.Count == 0)
                {
                    metroComboBox3.Items.Add(Tag.Album);
                    list.Add(Tag.Album);
                    continue;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == Tag.Album)
                        count++;
                }

                if (count == 0)
                {
                    metroComboBox3.Items.Add(Tag.Album);
                    list.Add(Tag.Album);
                }

                count = 0;
            }

            FS.Close();
        }
        public void YearComboBox()
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<string> list = new List<string>();

            int count = 0;

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);

                if (list.Count == 0)
                {
                    metroComboBox4.Items.Add(Tag.Year);
                    list.Add(Tag.Year);
                    continue;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == Tag.Year)
                        count++;
                }

                if (count == 0)
                {
                    metroComboBox4.Items.Add(Tag.Year);
                    list.Add(Tag.Year);
                }

                count = 0;
            }

            FS.Close();
        }

        private void metroExpander1_Paint(object sender, PaintEventArgs e)
        {

        }

        string[] files;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                checkedListBox1.Items.Clear();

                files = Directory.GetFiles(FBD.SelectedPath, "*.mp3");

                foreach (string file in files)
                {
                    checkedListBox1.Items.Add(Path.GetFileName(file));

                }
                paths s = new paths();
                s.set_files(files);

            }
            paths sb = new paths();
            sb.set_from_path(FBD.SelectedPath.ToString());
            panel1.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("mp3.txt", FileMode.Truncate);
            fs.Close();

            fs = new FileStream("mp3.txt", FileMode.Open);

            BinaryFormatter BF = new BinaryFormatter();

            int count = 0;

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                for (int j = 0; j < files.Count(); j++)
                {
                    if (checkedListBox1.CheckedItems[i].ToString() == Path.GetFileName(files[j]))
                    {
                        MP3Reader MR = new MP3Reader(files[j]);
                        MP3Tag_and_nameOf_MP3 Tag = MR.getTag();
                        BF.Serialize(fs, Tag);
                        count++;
                        break;
                    }
                }
            }

            fs.Close();

            MessageBox.Show("You have Added: " + count + " MP3 files successfully");
            ArtistComboBox();
            TitleComboBox();
            GenreComboBox();
            AlbumComboBox();
            YearComboBox();

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        //Filter by Title button ( switches panels )
        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            TitlePanel.Show();
        }
        //Filter by Artis button ( switches panels )
        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            ArtistsPanel.Show();
        }
        //Filter by Album button ( switches panels )
        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            AlbumPanel.Show();
        }
        //Filter by Year button ( switches panels )
        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            YearPanel.Show();
        }
        //Filter by Genre button ( switches panels )
        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            GenrePanel.Show();
        }
        //Filter by Track Title Done button
        private void metroButton4_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);
                if (Tag.Title == metroComboBox1.SelectedItem.ToString())
                    list.Add(Tag);
            }

            FS.Close();

            FileStream fs = new FileStream("mp3.txt", FileMode.Truncate);
            fs.Close();

            FileStream F = new FileStream("mp3.txt", FileMode.Open);

            for (int i = 0; i < list.Count; i++)
                BF.Serialize(F, list[i]);

            F.Close();

            MessageBox.Show("You have chosen: " + list.Count().ToString() + " song for Title: " + list[0].Title);
            TitlePanel.Hide();

        }
        //Filter by Track Artist Done button
        private void metroButton5_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);
                if (Tag.Artist == metroComboBox2.SelectedItem.ToString())
                    list.Add(Tag);
            }

            FS.Close();

            FileStream fs = new FileStream("mp3.txt", FileMode.Truncate);
            fs.Close();

            FileStream F = new FileStream("mp3.txt", FileMode.Open);

            for (int i = 0; i < list.Count; i++)
                BF.Serialize(F, list[i]);

            F.Close();

            MessageBox.Show("You have chosen: " + list.Count().ToString() + " song for Artist: " + list[0].Artist);
            ArtistsPanel.Hide();
        }
        //Filter by Track Album Done button
        private void metroButton6_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);
                if (Tag.Album == metroComboBox3.SelectedItem.ToString())
                    list.Add(Tag);
            }

            FS.Close();

            FileStream fs = new FileStream("mp3.txt", FileMode.Truncate);
            fs.Close();

            FileStream F = new FileStream("mp3.txt", FileMode.Open);

            for (int i = 0; i < list.Count; i++)
                BF.Serialize(F, list[i]);

            F.Close();

            MessageBox.Show("You have chosen: " + list.Count().ToString() + " song for Album: " + list[0].Album);
            AlbumPanel.Hide();
        }
        //Filter by Track Year Done button
        private void metroButton7_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);
                if (Tag.Year == metroComboBox4.SelectedItem.ToString())
                    list.Add(Tag);
            }

            FS.Close();

            FileStream fs = new FileStream("mp3.txt", FileMode.Truncate);
            fs.Close();

            FileStream F = new FileStream("mp3.txt", FileMode.Open);

            for (int i = 0; i < list.Count; i++)
                BF.Serialize(F, list[i]);

            F.Close();

            MessageBox.Show("You have chosen: " + list.Count().ToString() + " song for Year: " + list[0].Year);
            YearPanel.Hide();
        }

        //Filter by Track Grenre Done button
        private void metroButton8_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();

            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();

            while (FS.Position < FS.Length)
            {
                MP3Tag_and_nameOf_MP3 Tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(FS);
                if (Tag.Genere == metroComboBox5.SelectedItem.ToString())
                    list.Add(Tag);
            }

            FS.Close();

            FileStream fs = new FileStream("mp3.txt", FileMode.Truncate);
            fs.Close();

            FileStream F = new FileStream("mp3.txt", FileMode.Open);

            for (int i = 0; i < list.Count; i++)
                BF.Serialize(F, list[i]);

            F.Close();

            MessageBox.Show("You have chosen: " + list.Count().ToString() + " song for Genere: " + list[0].Genere);
        }




        int sort_by_Title(List<MP3Tag_and_nameOf_MP3> list, BinaryFormatter bf)
        {
            FileStream fs2 = new FileStream("mp3.txt", FileMode.Truncate);
            fs2.Close();
            sort_by_Title T = new sort_by_Title();
            list.Sort(T);

            for (int k = 0; k < list.Count; k++)
            {
                list[k].Comment = (k + 1) + "";
            }
            int check = 0;
            for (int m = 0; m < list.Count; m++)
            {
                for (int n = m + 1; n < list.Count; n++)
                {
                    if (list[m].Title == list[n].Title)
                    {
                        list[n].Comment = list[m].Comment;
                        check++;
                    }
                }
            }
            int count = 0;
            int index = 0;
            for (int a = 0; a < list.Count; a++)
            {
                for (int b = 0; b < list.Count; b++)
                {
                    if (list[b].Comment == a + 1 + "")
                    {
                        count++;
                        index = b;
                    }
                }
                if (count != 0)
                {
                    for (int c = index + 1; c < list.Count; c++)
                    {

                        list[c].Comment = int.Parse(list[c].Comment) - count + 1 + "";
                    }
                }
                count = 0;
            }
            FileStream fs3 = new FileStream("mp3.txt", FileMode.Open);
            for (int j = 0; j < list.Count; j++)
            {
                bf.Serialize(fs3, list[j]);
            }
            dataGridView2.DataSource = list;
            fs3.Close();
            return check;
        }

        int sort_by_Artist(List<MP3Tag_and_nameOf_MP3> list, BinaryFormatter bf)
        {
            FileStream fs2 = new FileStream("mp3.txt", FileMode.Truncate);
            fs2.Close();
            sort_by_Artist A = new sort_by_Artist();
            list.Sort(A);
            for (int k = 0; k < list.Count; k++)
            {
                list[k].Comment = (k + 1) + "";
            }
            int check = 0;
            for (int m = 0; m < list.Count; m++)
            {
                for (int n = m + 1; n < list.Count; n++)
                {
                    if (list[m].Artist == list[n].Artist)
                    {
                        list[n].Comment = list[m].Comment;
                        check++;
                    }
                }
            }
            int count = 0;
            int index = 0;
            for (int a = 0; a < list.Count; a++)
            {
                for (int b = 0; b < list.Count; b++)
                {
                    if (list[b].Comment == a + 1 + "")
                    {
                        count++;
                        index = b;
                    }
                }
                if (count != 0)
                {
                    for (int c = index + 1; c < list.Count; c++)
                    {

                        list[c].Comment = int.Parse(list[c].Comment) - count + 1 + "";
                    }
                }
                count = 0;
            }
            FileStream fs3 = new FileStream("mp3.txt", FileMode.Open);
            for (int j = 0; j < list.Count; j++)
            {
                bf.Serialize(fs3, list[j]);
            }
            dataGridView2.DataSource = list;
            fs3.Close();
            return check;
        }
        int sort_by_Album(List<MP3Tag_and_nameOf_MP3> list, BinaryFormatter bf)
        {
            FileStream fs2 = new FileStream("mp3.txt", FileMode.Truncate);
            fs2.Close();
            sort_by_Album A = new sort_by_Album();
            list.Sort(A);
            for (int k = 0; k < list.Count; k++)
            {
                list[k].Comment = (k + 1) + "";
            }
            int check = 0;
            for (int m = 0; m < list.Count; m++)
            {
                for (int n = m + 1; n < list.Count; n++)
                {
                    if (list[m].Album == list[n].Album)
                    {
                        list[n].Comment = list[m].Comment;
                        check++;
                    }
                }
            }
            int count = 0;
            int index = 0;
            for (int a = 0; a < list.Count; a++)
            {
                for (int b = 0; b < list.Count; b++)
                {
                    if (list[b].Comment == a + 1 + "")
                    {
                        count++;
                        index = b;
                    }
                }
                if (count != 0)
                {
                    for (int c = index + 1; c < list.Count; c++)
                    {

                        list[c].Comment = int.Parse(list[c].Comment) - count + 1 + "";
                    }
                }
                count = 0;
            }
            FileStream fs3 = new FileStream("mp3.txt", FileMode.Open);
            for (int j = 0; j < list.Count; j++)
            {
                bf.Serialize(fs3, list[j]);
            }
            dataGridView2.DataSource = list;
            fs3.Close();
            return check;
        }

        int sort_by_Year(List<MP3Tag_and_nameOf_MP3> list, BinaryFormatter bf)
        {
            FileStream fs2 = new FileStream("mp3.txt", FileMode.Truncate);
            fs2.Close();
            sort_by_Year Y = new sort_by_Year();
            list.Sort(Y);
            for (int k = 0; k < list.Count; k++)
            {
                list[k].Comment = (k + 1) + "";
            }
            int check = 0;
            for (int m = 0; m < list.Count; m++)
            {
                for (int n = m + 1; n < list.Count; n++)
                {
                    if (list[m].Year == list[n].Year)
                    {
                        list[n].Comment = list[m].Comment;
                        check++;
                    }
                }
            }
            int count = 0;
            int index = 0;
            for (int a = 0; a < list.Count; a++)
            {
                for (int b = 0; b < list.Count; b++)
                {
                    if (list[b].Comment == a + 1 + "")
                    {
                        count++;
                        index = b;
                    }
                }
                if (count != 0)
                {
                    for (int c = index + 1; c < list.Count; c++)
                    {

                        list[c].Comment = int.Parse(list[c].Comment) - count + 1 + "";
                    }
                }
                count = 0;
            }
            FileStream fs3 = new FileStream("mp3.txt", FileMode.Open);
            for (int j = 0; j < list.Count; j++)
            {
                bf.Serialize(fs3, list[j]);
            }
            dataGridView2.DataSource = list;
            fs3.Close();

            return check;
        }
        int sort_by_Genere(List<MP3Tag_and_nameOf_MP3> list, BinaryFormatter bf)
        {
            FileStream fs2 = new FileStream("mp3.txt", FileMode.Truncate);
            fs2.Close();
            sort_by_Genere G = new sort_by_Genere();
            list.Sort(G);
            for (int k = 0; k < list.Count; k++)
            {
                list[k].Comment = (k + 1) + "";
            }
            int check = 0;
            for (int m = 0; m < list.Count; m++)
            {
                for (int n = m + 1; n < list.Count; n++)
                {
                    if (list[m].Genere == list[n].Genere)
                    {
                        list[n].Comment = list[m].Comment;
                        check++;
                    }
                }
            }
            int count = 0;
            int index = 0;
            for (int a = 0; a < list.Count; a++)
            {
                for (int b = 0; b < list.Count; b++)
                {
                    if (list[b].Comment == a + 1 + "")
                    {
                        count++;
                        index = b;
                    }
                }
                if (count != 0)
                {
                    for (int c = index + 1; c < list.Count; c++)
                    {

                        list[c].Comment = int.Parse(list[c].Comment) - count + 1 + "";
                    }
                }
                count = 0;
            }
            FileStream fs3 = new FileStream("mp3.txt", FileMode.Open);
            for (int j = 0; j < list.Count; j++)
            {
                bf.Serialize(fs3, list[j]);
            }
            dataGridView2.DataSource = list;
            fs3.Close();
            return check;
        }
        
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD2 = new FolderBrowserDialog();
            MessageBox.Show("choose the detination of stored items ");
            if (FBD2.ShowDialog() == DialogResult.OK)
            {
                List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();
                FileStream fs = new FileStream("mp3.txt", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                while (fs.Position != fs.Length)
                {
                    MP3Tag_and_nameOf_MP3 Tag = new MP3Tag_and_nameOf_MP3();
                    Tag = (MP3Tag_and_nameOf_MP3)bf.Deserialize(fs);
                    list.Add(Tag);
                }
                paths s = new paths();
                string from_file = s.get_from_path();
                string to_file = FBD2.SelectedPath.ToString();
                DirectoryInfo dir = new DirectoryInfo(from_file);
                if (!dir.Exists)
                {
                    throw new Exception("source directory doesnot exist " + from_file);
                }

                if (!Directory.Exists(to_file))
                {
                    Directory.CreateDirectory(to_file);
                }

                FileInfo[] fil = dir.GetFiles();
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < s.get_files().Count(); j++)
                    {
                        if (list[i].Mp3_Name == Path.GetFileName(s.get_files()[j]))
                        {
                            string temp = Path.Combine(to_file, fil[j].Name);
                            fil[j].CopyTo(temp);
                        }

                    }
                }

            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();
            while (fs.Position != fs.Length)
            {
                MP3Tag_and_nameOf_MP3 tag = (MP3Tag_and_nameOf_MP3)bf.Deserialize(fs);
                list.Add(tag);
            }
            fs.Close();

            FileStream fs3 = new FileStream("mp3.txt", FileMode.Open);
            for (int j = 0; j < list.Count; j++)
            {
                bf.Serialize(fs3, list[j]);
            }
            dataGridView2.DataSource = list;
            fs3.Close();
        }

        private void bunifuTileButton11_Click(object sender, EventArgs e)
        {
            paths s = new paths();
            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();

            FileStream fm = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();
            List<MP3Tag_and_nameOf_MP3> lis = new List<MP3Tag_and_nameOf_MP3>();
            while (fm.Position != fm.Length)
            {
                MP3Tag_and_nameOf_MP3 tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(fm);
                lis.Add(tag);
            }
            fm.Close();

            FileStream fs2 = new FileStream("mp3.txt", FileMode.Truncate);
            fs2.Close();
            int i = 0;
            for (int m = 0; m < lis.Count; m++)
            {
                for (int n = 0; n < s.get_files().Length; n++)
                {
                    if (lis[m].Mp3_Name == Path.GetFileName(s.get_files()[n]))
                    {


                        MP3Reader MR = new MP3Reader(s.get_files()[n]);
                        MP3Tag_and_nameOf_MP3 tag = MR.getTag();
                        Mp3FileReader reader = new Mp3FileReader(s.get_files()[n]);
                        TimeSpan duration = reader.TotalTime;
                        list.Add(tag);
                        list[i].Duration = duration;
                        reader.Close();
                    }
                }
                i++;
            }

            sort_by_Durat D = new sort_by_Durat();
            list.Sort(D);



            for (int k = 0; k < list.Count; k++)
            {
                list[k].Comment = (k + 1) + "";
            }
            for (int m = 0; m < list.Count; m++)
            {
                for (int n = m + 1; n < list.Count; n++)
                {
                    if (list[m].Duration == list[n].Duration)
                    {
                        list[n].Comment = list[m].Comment;

                    }
                }
            }
            int count = 0;
            int index = 0;
            for (int a = 0; a < list.Count; a++)
            {
                for (int b = 0; b < list.Count; b++)
                {
                    if (list[b].Comment == a + 1 + "")
                    {
                        count++;
                        index = b;
                    }
                }
                if (count != 0)
                {
                    for (int c = index + 1; c < list.Count; c++)
                    {

                        list[c].Comment = int.Parse(list[c].Comment) - count + 1 + "";
                    }
                }
                count = 0;
            }
            FileStream fs3 = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            for (int j = 0; j < list.Count; j++)
            {
                bf.Serialize(fs3, list[j]);
            }
            dataGridView2.DataSource = list;
            fs3.Close();
            //edit comment
            edit_comment();

        }

        //add comment
        void edit_comment()
        {

            paths sort = new paths();
            string[] files = sort.get_files();
            FileStream s = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            List<MP3Tag_and_nameOf_MP3> List = new List<MP3Tag_and_nameOf_MP3>();
            while (s.Position < s.Length)
            {
                MP3Tag_and_nameOf_MP3 m = (MP3Tag_and_nameOf_MP3)b.Deserialize(s);
                List.Add(m);
            }
            s.Close();
            for (int i = 0; i < List.Count(); i++)
            {
                for (int j = 0; j < files.Count(); j++)
                {
                    if (Path.GetFileName(files[j]) == List[i].Mp3_Name)
                    {
                        s = new FileStream(files[j], FileMode.Open);
                        byte[] tag = new byte[128];
                        s.Seek(s.Length - 128, SeekOrigin.Begin);
                        s.Read(tag, 0, 128);
                        Array.Clear(tag, 97, 30);
                        tag[97] = byte.Parse((List[i].Comment));
                        s.Write(tag, 0, 128);
                        s.Close();
                        break;
                    }
                }
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

            FileStream fs = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();
            while (fs.Position != fs.Length)
            {
                MP3Tag_and_nameOf_MP3 tag = (MP3Tag_and_nameOf_MP3)bf.Deserialize(fs);
                list.Add(tag);
            }
            fs.Close();

            List<string> L = new List<string>();

            foreach (string item in checkedListBox2.CheckedItems)
            {
                L.Add(item);
            }

            for (int i = 0; i < L.Count; i++)
            {
                if (L[i] == "Title")
                {
                    int check;
                    check = sort_by_Title(list, bf);

                    if (check > 0 && L.Count == 1)
                    {
                        MessageBox.Show("Select Another Property");
                    }

                }
                else if (L[i] == "Artist")
                {
                    int check;
                    check = sort_by_Artist(list, bf);
                    if (check > 0 && L.Count == 1)
                    {
                        MessageBox.Show("Select Another Property");
                    }
                    else if (check > 0 && L.Count > 1 && L.Count == i + 1)
                    {
                        int c;
                        for (int a = i - 1; a >= 0; a--)
                        {
                            if (L[a] == "Title")
                            {
                                c = sort_by_Title(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                        }
                    }

                }
                else if (L[i] == "Album")
                {
                    int check;
                    check = sort_by_Album(list, bf);
                    if (check > 0 && L.Count == 1)
                    {
                        MessageBox.Show("Select Another Property");
                    }
                    else if (check > 0 && L.Count > 1 && L.Count == i + 1)
                    {
                        int c;
                        for (int a = i - 1; a >= 0; a--)
                        {
                            if (L[a] == "Title")
                            {
                                c = sort_by_Title(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                            else if (L[a] == "Artist")
                            {
                                c = sort_by_Artist(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                        }
                    }


                }
                else if (L[i] == "Year")
                {
                    int check;
                    check = sort_by_Year(list, bf);
                    if (check > 0 && L.Count == 1)
                    {
                        MessageBox.Show("Select Another Property");
                    }
                    else if (check > 0 && L.Count > 1 && L.Count == i + 1)
                    {
                        int c;
                        for (int a = i - 1; a >= 0; a--)
                        {
                            if (L[a] == "Title")
                            {
                                c = sort_by_Title(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                            else if (L[a] == "Artist")
                            {
                                c = sort_by_Artist(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                            else if (L[a] == "Album")
                            {
                                c = sort_by_Album(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                        }
                    }
                }

                else if (L[i] == "Genere")
                {
                    int check;
                    check = sort_by_Genere(list, bf);

                    if (check > 0 && L.Count == 1)
                    {
                        MessageBox.Show("Select Another Property");
                    }
                    else if (check > 0 && L.Count > 1 && L.Count == i + 1)
                    {
                        int c;
                        for (int a = i - 1; a >= 0; a--)
                        {
                            if (L[a] == "Title")
                            {
                                c = sort_by_Title(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                            else if (L[a] == "Artist")
                            {
                                c = sort_by_Artist(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                            else if (L[a] == "Album")
                            {
                                c = sort_by_Album(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }
                            }
                            else if (L[a] == "Year")
                            {
                                c = sort_by_Year(list, bf);
                                if (c == 0)
                                {
                                    break;
                                }
                                else if (c != 0 && a == 0)
                                {
                                    MessageBox.Show("Select Another Property");
                                }

                            }

                        }
                    }

                }
            }

        }

        private void bunifuTileButton11_Click_1(object sender, EventArgs e)
        {
            paths s = new paths();
            List<MP3Tag_and_nameOf_MP3> list = new List<MP3Tag_and_nameOf_MP3>();

            FileStream fm = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter BF = new BinaryFormatter();
            List<MP3Tag_and_nameOf_MP3> lis = new List<MP3Tag_and_nameOf_MP3>();
            while (fm.Position != fm.Length)
            {
                MP3Tag_and_nameOf_MP3 tag = (MP3Tag_and_nameOf_MP3)BF.Deserialize(fm);
                lis.Add(tag);
            }
            fm.Close();

            FileStream fs2 = new FileStream("mp3.txt", FileMode.Truncate);
            fs2.Close();
            int i = 0;
            for (int m = 0; m < lis.Count; m++)
            {
                for (int n = 0; n < s.get_files().Length; n++)
                {
                    if (lis[m].Mp3_Name == Path.GetFileName(s.get_files()[n]))
                    {


                        MP3Reader MR = new MP3Reader(s.get_files()[n]);
                        MP3Tag_and_nameOf_MP3 tag = MR.getTag();
                        Mp3FileReader reader = new Mp3FileReader(s.get_files()[n]);
                        TimeSpan duration = reader.TotalTime;
                        list.Add(tag);
                        list[i].Duration = duration;
                        reader.Close();
                    }
                }
                i++;
            }

            sort_by_Durat D = new sort_by_Durat();
            list.Sort(D);



            for (int k = 0; k < list.Count; k++)
            {
                list[k].Comment = (k + 1) + "";
            }
            for (int m = 0; m < list.Count; m++)
            {
                for (int n = m + 1; n < list.Count; n++)
                {
                    if (list[m].Duration == list[n].Duration)
                    {
                        list[n].Comment = list[m].Comment;

                    }
                }
            }
            int count = 0;
            int index = 0;
            for (int a = 0; a < list.Count; a++)
            {
                for (int b = 0; b < list.Count; b++)
                {
                    if (list[b].Comment == a + 1 + "")
                    {
                        count++;
                        index = b;
                    }
                }
                if (count != 0)
                {
                    for (int c = index + 1; c < list.Count; c++)
                    {

                        list[c].Comment = int.Parse(list[c].Comment) - count + 1 + "";
                    }
                }
                count = 0;
            }
            FileStream fs3 = new FileStream("mp3.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            for (int j = 0; j < list.Count; j++)
            {
                bf.Serialize(fs3, list[j]);
            }
            dataGridView2.DataSource = list;
            fs3.Close();
            //edit comment
            edit_comment();

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
        
        
    

