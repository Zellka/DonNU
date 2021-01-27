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
using System.Collections;


namespace _4_лаба
{
    public struct DataText
    {
        public string text;
    }
    public partial class CopyrighterForm : Form
    {
        public string n; //в ней будет хранится путь каждого файла
        static public DataText Dt;
        public int count;
        public CopyrighterForm()  {InitializeComponent();}
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageList1.Images.Clear();
                listView1.Clear();
                pictureBox1.Image = null;
                int num = open.FileNames.Length;
                string[] path = new string[num];
                foreach(string f in open.FileNames)
                {
                    path[count] = f;
                    imageList1.Images.Add(Image.FromFile(f));
                    count++;
                }
                listView1.LargeImageList = imageList1;
                for (int i = 0; i < count; i++)
                    listView1.Items.Add(path[i], i);
            }
        }
        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DirectoryInfo dir;
            FileInfo[] fil;
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageList1.Images.Clear();
                listView1.Clear();
                pictureBox1.Image = null;
                dir = new DirectoryInfo(folder.SelectedPath);
                fil = dir.GetFiles();
                int count = 0;
                string p = folder.SelectedPath;
                string[] c = new string[fil.Length];
                for (int i = 0; i < fil.Length; i++)
                {
                    c[i] = p + "\\" + fil[i].Name;
                    imageList1.Images.Add(Image.FromFile(c[i]));
                    count++;
                }
                listView1.LargeImageList = imageList1;
                for (int i = 0; i < count; i++)
                    listView1.Items.Add(c[i], i);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    string file = listView1.SelectedItems[i].Text;
                    n = listView1.SelectedItems[i].Text;
                    pictureBox1.Image = Image.FromFile(file);
                }
            }
            catch { MessageBox.Show("Вы уже изменили этот файл");}
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }
        private void Add_Click(object sender, EventArgs e)
        {
            string logo = "Zellka";
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Font myFont = new Font("Sitka Heading", 64))
                    g.DrawString(logo, myFont, Brushes.LightGray, 10, 60);
            }
            pictureBox1.Image.Dispose();
            pictureBox1.Image = bmp;

            for (int k = 0; k < count; k++)
            {
                if (listView1.Items[k].Text == n)
                {
                    listView1.Items[k].Text = "CHANGED";
                    listView1.Items[k].ForeColor = Color.Red;
                }
            }

            string name = Path.GetFileName(n);
            int width = bmp.Width;
            int height = bmp.Height;
            int i;
            for (i = 0; i < DataTable.RowCount; i++)
            {
                DataTable.Rows[i].Cells[0].Value = name;
                DataTable.Rows[i].Cells[1].Value = width;
                DataTable.Rows[i].Cells[2].Value = height;
                DataTable.Rows[i].Cells[3].Value = logo;
            }
            i++;
        }
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                pictureBox1.Image = null;
                foreach (int i in listView1.SelectedIndices)
                    listView1.Items.Remove(listView1.Items[i]);
                MessageBox.Show("Removed");
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            Bitmap bmpSave = new Bitmap(pictureBox1.DisplayRectangle.Width, pictureBox1.DisplayRectangle.Height);
            pictureBox1.DrawToBitmap(bmpSave, pictureBox1.DisplayRectangle);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "bmp";
            sfd.Filter = "Image files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                bmpSave.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }
        private void copyrightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLogo logoAdd = new AddLogo();
            logoAdd.ShowDialog();
            string logo = Dt.text;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Font myFont = new Font("Sitka Heading", 64))
                    g.DrawString(logo, myFont, Brushes.LightGray, 10, 60);
            }
            pictureBox1.Image.Dispose();
            pictureBox1.Image = bmp;

            for (int k = 0; k < count; k++)
            {
                if (listView1.Items[k].Text == n)
                {
                    listView1.Items[k].Text = "CHANGED";
                    listView1.Items[k].ForeColor = Color.Red;
                }
            }

            string name = Path.GetFileName(n);
            int width = bmp.Width;
            int height = bmp.Height;
            int i;
            for (i = 0; i < DataTable.RowCount; i++)
            {
                DataTable.Rows[i].Cells[0].Value = name;
                DataTable.Rows[i].Cells[1].Value = width;
                DataTable.Rows[i].Cells[2].Value = height;
                DataTable.Rows[i].Cells[3].Value = logo;
            }
            i++;
        }

        private void addCopyrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string logo = "Zellka";
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Font myFont = new Font("Sitka Heading", 64))
                    g.DrawString(logo, myFont, Brushes.LightGray, 10, 60);
            }
            pictureBox1.Image.Dispose();
            pictureBox1.Image = bmp;

            for (int k = 0; k < count; k++)
            {
                if (listView1.Items[k].Text == n)
                {
                    listView1.Items[k].Text = "CHANGED";
                    listView1.Items[k].ForeColor = Color.Red;
                }
            }
            string name = Path.GetFileName(n);
            int width = bmp.Width;
            int height = bmp.Height;
            int i;
            for (i = 0; i < DataTable.RowCount; i++)
            {
                DataTable.Rows[i].Cells[0].Value = name;
                DataTable.Rows[i].Cells[1].Value = width;
                DataTable.Rows[i].Cells[2].Value = height;
                DataTable.Rows[i].Cells[3].Value = logo;
            }
            i++;
        }
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmpSave = new Bitmap(pictureBox1.DisplayRectangle.Width, pictureBox1.DisplayRectangle.Height);
            pictureBox1.DrawToBitmap(bmpSave, pictureBox1.DisplayRectangle);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "bmp";
            sfd.Filter = "Image files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                bmpSave.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }
        private void Batch_Click(object sender, EventArgs e)
        {
            string filename = @"C:\Save\tmp-";
            int i = 0;
            string path = " ";
            for (int k = 0; k < listView1.Items.Count; k++)
            {
                string file = listView1.Items[k].Text;
                pictureBox1.Image = Image.FromFile(file);
                path = filename + i.ToString() + ".bmp";
                string logo = "Zellka";
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    using (Font myFont = new Font("Sitka Heading", 64))
                        g.DrawString(logo, myFont, Brushes.LightGray, 10, 60);
                }
                pictureBox1.Image.Dispose();
                pictureBox1.Image = bmp;
                Bitmap bmpSave = new Bitmap(pictureBox1.DisplayRectangle.Width, pictureBox1.DisplayRectangle.Height);
                pictureBox1.DrawToBitmap(bmpSave, pictureBox1.DisplayRectangle);
                bmpSave.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                i++;
            }
            pictureBox1.Image = null;
            MessageBox.Show("DONE");
        }

        private void batchModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = @"C:\Save\tmp-";
            int i = 0;
            string path = " ";
            for (int k = 0; k < listView1.Items.Count; k++)
            {
                string file = listView1.Items[k].Text;
                pictureBox1.Image = Image.FromFile(file);
                path = filename + i.ToString() + ".bmp";
                string logo = "Zellka";
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    using (Font myFont = new Font("Sitka Heading", 64))
                        g.DrawString(logo, myFont, Brushes.LightGray, 10, 60);
                }
                pictureBox1.Image.Dispose();
                pictureBox1.Image = bmp;
                Bitmap bmpSave = new Bitmap(pictureBox1.DisplayRectangle.Width, pictureBox1.DisplayRectangle.Height);
                pictureBox1.DrawToBitmap(bmpSave, pictureBox1.DisplayRectangle);
                bmpSave.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                i++;
            }
            pictureBox1.Image = null;
            MessageBox.Show("DONE");
        }

        private void copyrightDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = folder.SelectedPath + "\\tmp-";
                int i = 0;
                string path = " ";
                for (int k = 0; k < listView1.Items.Count; k++)
                {
                    string file = listView1.Items[k].Text;
                    pictureBox1.Image = Image.FromFile(file);
                    path = filename + i.ToString() + ".bmp";
                    string logo = "Zellka";
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        using (Font myFont = new Font("Sitka Heading", 64))
                            g.DrawString(logo, myFont, Brushes.LightGray, 10, 60);
                    }
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = bmp;
                    Bitmap bmpSave = new Bitmap(pictureBox1.DisplayRectangle.Width, pictureBox1.DisplayRectangle.Height);
                    pictureBox1.DrawToBitmap(bmpSave, pictureBox1.DisplayRectangle);
                    bmpSave.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                    i++;
                }
                pictureBox1.Image = null;
                MessageBox.Show("DONE");
            }
        }
    }
}
