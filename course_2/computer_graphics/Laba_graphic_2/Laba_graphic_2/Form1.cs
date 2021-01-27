using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//4 вариант

namespace Laba_graphic_2
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button_pixel_Click(object sender, EventArgs e)
        {
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;  //экранные координаты
            double x = 0, y = 0; //математические значения

            Pen axesPen = new Pen(Color.DarkBlue);
            Pen graphicsPen = new Pen(Color.FromArgb(255, 0, 0), 3); 
            pictureBox1.BackColor = Color.FromName("White");
            pictureBox1.Refresh();

            g.PageUnit = GraphicsUnit.Pixel; //cтандарт страничного пространства в Pixel
            g.DrawRectangle(axesPen, 0, 0, pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            //рисуем оси
            g.DrawLine(axesPen, 0, (pictureBox1.Size.Height - 1) / 2, pictureBox1.Size.Width - 1, (pictureBox1.Size.Height - 1) / 2);
            g.DrawLine(axesPen, (pictureBox1.Size.Width - 1) / 2, 0, (pictureBox1.Size.Width - 1) / 2, pictureBox1.Size.Height - 1);

            //рисуем график функции y=Sin(x)
            x = -Math.PI * 2;
            for (ex = 0; ex <= 1000; ex++)
            {
                y = Math.Sin(x);
                ey = (pictureBox1.Size.Height - 1) - (Convert.ToInt16(y * 200) + 250);
                if (ex != 0) 
                    g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); 
                old_ex = ex; old_ey = ey;
                x = x + (Math.PI * 4) / (pictureBox1.Size.Width - 1);
            }
        }

        private void button_millimeter_Click(object sender, EventArgs e)
        {
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            double x = 0, y = 0;
            
            g.PageUnit = GraphicsUnit.Millimeter; //стандарт страничного пространства Millimeter
            Pen axesPen = new Pen(Color.Green, 0.1f);
            Pen graphicsPen = new Pen(Color.FromArgb(230, 0, 150), 1);

            pictureBox1.BackColor = Color.FromName("White");
            pictureBox1.Refresh();

            //получаем ширину и высоту прямоугольника в миллиметрах
            int widthInMM = Convert.ToInt16((pictureBox1.Size.Width - 1) / g.DpiX * 25.4);
            int heightInMM = Convert.ToInt16((pictureBox1.Size.Height - 1) / g.DpiY * 25.4);
            g.DrawRectangle(axesPen, 0, 0, widthInMM, heightInMM);
            //рисуем оси
            g.DrawLine(axesPen, 0, heightInMM / 2, widthInMM, heightInMM / 2);
            g.DrawLine(axesPen, widthInMM / 2, 0, widthInMM / 2, heightInMM);

            //рисуем график функции y=Sin(x)
            x = -Math.PI * 2;
            for (ex = 0; ex <= widthInMM; ex++)
            {
                y = Math.Sin(x);
                ey = heightInMM - (Convert.ToInt16(y *

                Convert.ToSingle(200 / g.DpiX * 25.4)) +
                Convert.ToInt16(250 / g.DpiX * 25.4));
                if (ex != 0) 
                    g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey);
                old_ex = ex; 
                old_ey = ey;
                x = x + (Math.PI * 4) / widthInMM;
            }
        }

        private void button_inch_Click(object sender, EventArgs e)
        {
            float ex = 0, old_ex = 0, ey = 0, old_ey = 0;
            float x = 0, y = 0;
            float shag = 0;
            
            g.PageUnit = GraphicsUnit.Inch; //стандарт страничного пространства Inch
            Pen axesPen = new Pen(Color.DimGray, 0.01f);
            Pen graphicsPen = new Pen(Color.FromArgb(0, 150, 0), 0.05f);

            pictureBox1.BackColor = Color.FromName("White");
            pictureBox1.Refresh();

            //получаем ширину и высоту прямоугольника в дюймах
            float WidthInInches = (pictureBox1.Size.Width - 1) / g.DpiX;
            float HeightInInches = (pictureBox1.Size.Height - 1) / g.DpiY;
            g.DrawRectangle(axesPen, 0, 0, WidthInInches, HeightInInches);
            //рисуем оси
            g.DrawLine(axesPen, 0, HeightInInches / 2, WidthInInches, HeightInInches / 2);
            g.DrawLine(axesPen, WidthInInches / 2, 0, WidthInInches / 2, HeightInInches);

            //рисуем график функции y=Sin(x)
            x = -Convert.ToSingle(Math.PI * 2);
            ex = 0;
            shag = Convert.ToSingle(WidthInInches / 25.4);
            while (ex <= WidthInInches + shag)
            {
                y = Convert.ToSingle(Math.Sin(x));
                ey = Convert.ToSingle(-y) + HeightInInches / 2;
                if (ex != 0) 
                    g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); 
                old_ex = ex; 
                old_ey = ey;
                ex = ex + shag;
                x = x + Convert.ToSingle((Math.PI * 4) / shag);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }
    }
}
