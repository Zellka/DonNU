using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Laba_graphic_11
{
    public partial class Form1 : Form
    {
        public struct Simple
        {
            public double xx; 
            public double yy; 
            public int ii;
        };
        FileInfo file = new FileInfo("SCRATCH");
        double x, y, xmin, xmax, ymin, ymax; double X, Y, Xmin, Xmax, Ymin, Ymax;

        double fx, fy, f, xC, yC, XC, YC, c1, c2;
        Simple s; Graphics dc; Pen p;
        public Form1()
        {
            InitializeComponent();
        }
        private int IX(double x)
        {
            double xx = x * (pictureBox1.Size.Width / 10.0) + 0.5; 
            return (int)xx;
        }
        private int IY(double y)
        {
            double yy = pictureBox1.Size.Height - y * (pictureBox1.Size.Height / 7.0) + 0.5;
            return (int)yy;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dc = pictureBox1.CreateGraphics(); p = new Pen(Brushes.Yellow, 1);
            Point X1Y1 = new Point(); Point X2Y2 = new Point();
            using (BinaryReader fr = new BinaryReader(file.Open(FileMode.OpenOrCreate,FileAccess.Read, FileShare.Read)))
            {
                while (fr.BaseStream.Position < fr.BaseStream.Length)
                {
                    s.xx = fr.ReadDouble();
                    s.yy = fr.ReadDouble();
                    s.ii = fr.ReadInt32();
                    x = s.xx; y = s.yy;
                    if (x < xmin) xmin = x; if (x > xmax) xmax = x;
                    if (y < ymin) ymin = y; if (y > ymax) ymax = y;
                }
                fr.Close();
            }
            Xmin = 0; Xmax = 10; Ymin = 0; Ymax = 7;
            fx = (Xmax - Xmin) / (xmax - xmin);

            fy = (Ymax - Ymin) / (ymax - ymin);
            f = (fx < fy ? fx : fy);
            xC = 0.5 * (xmin + xmax);
            yC = 0.5 * (ymin + ymax);
            XC = 0.5 * (Xmin + Xmax);
            YC = 0.5 * (Ymin + Ymax);
            c1 = XC - f * xC;
            c2 = YC - f * yC;
            using (BinaryReader fr = new BinaryReader(file.Open(FileMode.OpenOrCreate,FileAccess.Read, FileShare.Read)))
            {
                while (fr.BaseStream.Position < fr.BaseStream.Length)
                {
                    s.xx = fr.ReadDouble();
                    s.yy = fr.ReadDouble();
                    s.ii = fr.ReadInt32();
                    x = s.xx;
                    y = s.yy;
                    X = f * x + c1;
                    Y = f * y + c2;
                    X2Y2.X = IX(X);
                    X2Y2.Y = IY(Y);
                    if (s.ii == 1) { dc.DrawLine(p, X1Y1, X2Y2); X1Y1 = X2Y2; }

                    else { X1Y1 = X2Y2; }

                }
                fr.Close();
            }
        }
    }
}
