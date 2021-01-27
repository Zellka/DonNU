using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba_graphic_7
{
    public partial class Form1 : Form
    {
        Bitmap pictureBoxBitMap;
        Bitmap spriteBitMap;
        Bitmap cloneBitMap;
        Graphics g_pictureBox;
        Graphics g_sprite;
        int diametr = 60; 
        int x, y; 
        public Form1() { InitializeComponent(); }
        void DrawSprite()
        {
            g_sprite.FillRectangle(Brushes.Black, 0, 0, 10, 10);
            g_sprite.FillEllipse(Brushes.Black, 0, 0, diametr-1, 10);
        }
        void SavePart(int xt, int yt)
        {
            Rectangle cloneRect = new Rectangle(xt, yt, diametr, diametr);
            System.Drawing.Imaging.PixelFormat format =
            pictureBoxBitMap.PixelFormat;
            cloneBitMap = pictureBoxBitMap.Clone(cloneRect, format);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"sea1.jpg");
            pictureBoxBitMap = new Bitmap(pictureBox1.Image);
            g_pictureBox = Graphics.FromImage(pictureBox1.Image);
            spriteBitMap = new Bitmap(diametr, 15);
            g_sprite = Graphics.FromImage(spriteBitMap);
            DrawSprite();
            cloneBitMap = new Bitmap(diametr, 15);
            x = 185; y = pictureBox1.Height / 2;
            SavePart(x, y);
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            pictureBox1.Invalidate();
            
            timer1 = new Timer();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        private void button1_Click(object sender, EventArgs e) { timer1.Enabled = true; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g_pictureBox.DrawImage(cloneBitMap, x, y);
            x = x + 25;
            if (x > pictureBox1.Width - diametr)  x = pictureBox1.Location.X; 
            SavePart(x, y);
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            pictureBox1.Invalidate();
        }
    }
}
