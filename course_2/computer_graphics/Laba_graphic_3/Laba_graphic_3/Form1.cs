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
using System.Drawing.Drawing2D;

namespace Laba_graphic_3
{
    public partial class Form1 : Form
    {
        Graphics g;
        string fileName = @"Строки из 3 лабы.txt";

        string[] lines = { "First line", "Second line", "Third line",
                        "Fourth line", "Fifth line", "Sixth line",
                        "Seventh line", "Eighth line", "Ninth line",
                        "Tenth line", "Eleven line"};

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button_to_file_Click(object sender, EventArgs e)
        {
            StreamWriter fileWrite = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write));
            foreach (string line in lines)
                fileWrite.WriteLine(line);
            fileWrite.Close();
            MessageBox.Show("Данные записаны");
        }

        private void button_сlear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
        }

        private void button_del_file_Click(object sender, EventArgs e)
        {
            File.Delete(fileName);
            MessageBox.Show("Файл удалён");
        }

        private void button_display_Click(object sender, EventArgs e)
        {
            ReaderFile();

            pictureBox1.BackColor = Color.AliceBlue;
            pictureBox1.Refresh();

            for (int i = 0; i < 11; i++)
            {
                if ((i >= 0) && (i < 8))
                    FirstGroupLines(i);

                if ((i >= 8) && (i < 10))
                    SecondGroupLines(i);

                if (i == 10)
                    ThirdGroupLines(i);
            }
        }
        public void ReaderFile()
        {
            try
            {
                StreamReader reader = new StreamReader(new FileStream(fileName,
                FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 11; i++)
                    lines[i] = reader.ReadLine();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FirstGroupLines(int i)
        {
            Font font = new Font("Magneto", 18, FontStyle.Bold);
            StringFormat format =
            (StringFormat)StringFormat.GenericTypographic.Clone();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Far;
            g.DrawString(lines[i], font, Brushes.Blue,
            new RectangleF(0, 0 + i * 20, pictureBox1.Size.Width - 20,
            pictureBox1.Size.Height - 150), format);
            font.Dispose();
        }
        public void SecondGroupLines(int i)
        {
            int k = 0;
            k = i - 8;
            Font font = new Font("Perpetua", 24, FontStyle.Italic);
            StringFormat format =
            (StringFormat)StringFormat.GenericTypographic.Clone();
            format.FormatFlags = StringFormatFlags.DirectionVertical;
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Far;
            g.DrawString(lines[i], font, Brushes.Black,
            new RectangleF(0 + k * 24, 0, pictureBox1.Size.Width - 20,
            pictureBox1.Size.Height - 20), format);
            font.Dispose();
        }
        public void ThirdGroupLines(int i)
        {
            Font font = new Font("Cambria", 72, FontStyle.Regular);
            StringFormat format =
            (StringFormat)StringFormat.GenericTypographic.Clone();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Near;
            g.DrawString(lines[i], font, Brushes.Green,
            new RectangleF(0, 0 + i * 24, pictureBox1.Size.Width - 20,
            pictureBox1.Size.Height - 20), format);
            font.Dispose();
        }

    }
}
