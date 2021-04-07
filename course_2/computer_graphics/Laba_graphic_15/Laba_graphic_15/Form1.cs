﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba_graphic_15
{
    public struct Point3D
    {
        public int x;
        public int y;
        public int z;
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            vertices = new Point3D[6];

            vertices[0].x = length/2;
            vertices[0].y = -length/2;
            vertices[0].z = -length/2;

            vertices[1].x = length/2;
            vertices[1].y = length/2;
            vertices[1].z = -length/2;

            vertices[2].x = -length/2;
            vertices[2].y = length/2;
            vertices[2].z = -length/2;

            vertices[3].x = -length/2;
            vertices[3].y = -length/2;
            vertices[3].z = -length/2;

            vertices[4].x = 0;
            vertices[4].y = 0;
            vertices[4].z = length/4;

            vertices[5].x = 0;
            vertices[5].y = 0;
            vertices[5].z = -length;
        }

        Graphics graphics;
        int length = 50;
        Point3D[] vertices;
        double v11, v12, v13, v21, v22, v23, v32, v33, v43;
        double rho = 150.0, theta = 520.0, phi = 90.0;

        private void button1_Click(object sender, EventArgs e)
        {
            getCoefficient(rho, theta, phi);
            DrawParallelepiped();
        }

        double c1 = 5.0, c2 = 4.5;
        double screenDist = 8;

        private void DrawParallelepiped()
        {
            DrawPerspectiveLine(vertices[0], vertices[1]);
            DrawPerspectiveLine(vertices[1], vertices[2]);
            DrawPerspectiveLine(vertices[2], vertices[3]);
            DrawPerspectiveLine(vertices[3], vertices[0]);

            DrawPerspectiveLine(vertices[0], vertices[4]);
            DrawPerspectiveLine(vertices[1], vertices[4]);
            DrawPerspectiveLine(vertices[2], vertices[4]);
            DrawPerspectiveLine(vertices[3], vertices[4]);

            DrawPerspectiveLine(vertices[0], vertices[5]);
            DrawPerspectiveLine(vertices[1], vertices[5]);
            DrawPerspectiveLine(vertices[2], vertices[5]);
            DrawPerspectiveLine(vertices[3], vertices[5]);
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
        private void getCoefficient(double rho, double theta, double phi)
        {
            double th, ph, coeff, costh, sinth, cosph, sinph;
            coeff = Math.PI / 180;
            th = theta * coeff;
            ph = phi * coeff;
            costh = Math.Cos(th);
            sinth = Math.Sin(th);
            cosph = Math.Cos(ph);
            sinph = Math.Sin(ph);
            v11 = -sinth;
            v12 = -cosph * costh;
            v13 = -sinph * costh;
            v21 = costh;
            v22 = -cosph * sinth;
            v23 = -sinph * sinth;
            v32 = sinph;
            v33 = -cosph;
            v43 = rho;
        }
        private void Perspective(double x, double y, double z, ref double pX, ref double pY)
        {
            double xe, ye, ze;
            xe = v11 * x + v21 * y;
            ye = v12 * x + v22 * y + v32 * z;
            ze = v13 * x + v23 * y + v33 * z + v43;
            pX = screenDist * xe / ze + c1;
            pY = screenDist * ye / ze + c2;
        }
        private void DrawPerspectiveLine(Point3D p1, Point3D p2)
        {
            double x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            Perspective(p1.x, p1.y, p1.z, ref x1, ref y1);
            Perspective(p2.x, p2.y, p2.z, ref x2, ref y2);
            Point point1 = new Point(IX(x1), IY(y1));
            Point point2 = new Point(IX(x2), IY(y2));
            graphics.DrawLine(Pens.DarkGreen, point1, point2);
        }
    }
}
