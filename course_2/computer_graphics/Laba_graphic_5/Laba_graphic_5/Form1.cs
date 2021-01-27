using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_graphic_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Show();
            Graphics g = this.CreateGraphics();
            g.DrawString("Кликните мышкой по элементу PictureBox",
            new Font("Arial", 6, FontStyle.Regular), Brushes.Red, 0, 0);
            g.Dispose();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Graphics g = pictureBox1.CreateGraphics();
            Point[] point = new Point[9] //задаём координаты точек многоугольника
            {   new Point(120, 20),
                new Point(180, 30), new Point(240, 20),
                new Point(300, 30), new Point(360, 20),
                new Point(420, 30), new Point(500, 80),
                new Point(300, 110), new Point(100, 80)
            };
            Font fn = new Font("Broadway", 14, FontStyle.Bold);
            StringFormat sf = new StringFormat();
            drawHeading(g, point, fn, sf);

            g.DrawRectangle(new Pen(Color.Blue, 1), 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
            int start_x = 30;
            int end_x = pictureBox1.Width - 10;
            int start_y = 120;
            int end_y = pictureBox1.Height - 20;
            g.DrawLine(new Pen(Color.Black, 1), start_x, end_y, end_x, end_y); //рисуем ось x
            g.DrawLine(new Pen(Color.Black, 1), start_x, start_y, start_x, end_y); //рисуем ось у

            string[] experiment = new string[8] { "1", "2", "3", "4", "5", "6", "7", "8" };
            int[] value = new int[8] { 20, 65, 4, 33, 15, 12, 18, 44 };
            int max = -1;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] > max)
                    max = value[i];
            }

            double mash = 5.0;
            double dy = (end_y - start_y) / (max / mash);
            int widthRect = ((end_x - start_x) / value.Length) / 2;
            int x = start_x + widthRect;

            drawDiagram(g, value, dy, mash, end_y, x, widthRect);
            markupY(g, fn, sf, start_x, mash, value, end_y, end_x, dy);
            markupX(g, fn, sf, x, start_x, widthRect, experiment, end_y);
            g.Dispose();
        }
        private void drawDiagram(Graphics g, int[] value, double dy, double mash, int end_y, int x, int widthRect)
        {
            SolidBrush sb = new SolidBrush(Color.CornflowerBlue);
            HatchBrush hb = new HatchBrush(HatchStyle.BackwardDiagonal, Color.CornflowerBlue, Color.LightSkyBlue);
            Bitmap img = (Bitmap)Image.FromFile(@"C:\img.bmp", true);
            TextureBrush tb = new TextureBrush(img);
            for (int i = 0; i < value.Length; i++)
            {
                Rectangle rect = new Rectangle(x, end_y - (int)(dy * (value[i] /
                mash)), widthRect, (int)(dy * (value[i] / mash)));
                if (i < 3)
                    g.FillRectangle(sb, rect);
                if ((i >= 3) && (i < 6))
                    g.FillRectangle(hb, rect);
                if ((i >= 6) && (i < 8))
                    g.FillRectangle(tb, rect);
                g.DrawRectangle(new Pen(Color.Black, 1), rect);
                x += 2 * widthRect;
            }
        }
        private void markupY(Graphics g, Font fn, StringFormat sf, int start_x, double mash, int[] value, int end_y, int end_x, double dy)
        {
            Pen p = new Pen(Color.Blue, 2);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            fn = new Font("Arial", 8, FontStyle.Bold);
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < value.Length; i++)
            {
                g.DrawLine(p, start_x - 5, end_y - (int)(dy * (value[i] /
                mash)), end_x, end_y - (int)(dy * (value[i] / mash)));
                g.DrawString(value[i].ToString(), fn, Brushes.Black,
                new Rectangle(1, end_y - (int)(dy * (value[i] / mash)) -
                (int)fn.Size, 30, 20), sf);
            }
        }
        private void markupX(Graphics g, Font fn, StringFormat sf, int x, int start_x, int widthRect, string[] experiment, int end_y)
        {
            sf.Alignment = StringAlignment.Center;
            fn = new Font("Arial", 8, FontStyle.Bold);
            x = start_x + widthRect + widthRect / 2;
            for (int i = 0; i < experiment.Length; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), x, end_y - 5, x,
                end_y + 5);
                g.DrawString(experiment[i], fn, Brushes.Black, new Rectangle(x - 25,
                end_y, 50, 22), sf);
                x += 2 * widthRect;
            }
        }
        private void drawHeading(Graphics g, Point[] point, Font fn, StringFormat sf)
        {
            g.DrawPolygon(new Pen(Color.Red, 2), point);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            string s = "The result of eight experiments";
            g.DrawString(s, fn, Brushes.Red, new Rectangle(150, 30, 300, 70), sf);
        }

    }
}
