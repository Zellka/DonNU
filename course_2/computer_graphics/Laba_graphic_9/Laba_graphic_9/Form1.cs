using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba_graphic_9
{
    public partial class Form1 : Form
    {
        Graphics graphic; Pen p;
        public Form1()
        {
            InitializeComponent();
            graphic = pictureBox1.CreateGraphics();
            p = new Pen(Brushes.DarkBlue, 1);
        }
        //метод преобразования вещественной координаты X в целую
        private int IX(double x)
        {
            double xx = x * (pictureBox1.Size.Width / 15.0) + 70;
            return (int)xx;
        }
        //метод преобразования вещественной координаты Y в целую 
        private int IY(double y)
        {
            double yy = pictureBox1.Size.Height - y * (pictureBox1.Size.Height / 10.0) + 0.5;
            return (int)yy;
        }
        private void Draw(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            graphic.DrawLine(p, point1, point2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] x; 
            x = new double[3] { 1.0, 6.0, 3.0};
            double[] y; 
            y = new double[3] { 1.0, 1.0, 5.0 };
            int i, j;
            double Phi, cos_Phi, sin_Phi, dx, dy;
            double x0 = 3.0, y0 = 3.0; //начальные кординаты отсчёта
            Phi = 3 * Math.PI / 180;  //угол поворота
            cos_Phi = Math.Cos(Phi);
            sin_Phi = Math.Sin(Phi);

            //смещение относительно центра вращения
            for (j = 0; j < 3; j++)
            {
                x[j] += x0;
                y[j] += y0;
            }
            //цикл прорисовки треугольников
            for (i = 0; i < 30; i++)
            {
                //прорисовка текущего треугольника
                for (j = 0; j < 3; j++)
                {
                    //пересчет координат для текущего треугольника
                    dx = x[j] - x0;
                    dy = y[j] - y0;
                    x[j] = x0 + dx * cos_Phi - dy * sin_Phi;
                    y[j] = y0 + dx * sin_Phi + dy * cos_Phi;
                }
                //прорисовка треугольника
                double xold = x[2];
                double yold = y[2];
                for (j = 0; j <= 2; j++)
                {
                    Draw(xold, yold, x[j], y[j]);
                    xold = x[j]; yold = y[j];
                }
            }
        }
    }
}
