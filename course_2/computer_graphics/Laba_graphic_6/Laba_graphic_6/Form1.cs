using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba_graphic_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush roadColor = new SolidBrush(Color.Gray); 
            SolidBrush lineColor = new SolidBrush(Color.White); 
            SolidBrush wheelColor = new SolidBrush(Color.Black); 
            SolidBrush carColor = new SolidBrush(Color.Red);
            SolidBrush windshieldColor = new SolidBrush(Color.Silver); 
            SolidBrush truckColor = new SolidBrush(Color.DarkGreen); 
            SolidBrush cabinColor = new SolidBrush(Color.Orange); 
            SolidBrush sunColor = new SolidBrush(Color.Yellow); 
            
            /*рисуем солнце*/
            g.FillEllipse(sunColor, 10, 10, 50, 50);

            /*рисуем дорогу*/
            g.FillRectangle(roadColor, 0, 220, 900, 230);
            g.FillRectangle(lineColor, 300, 300, 350, 15);
             
            DrawTruck(g, truckColor, cabinColor, windshieldColor, wheelColor);
            DrawCar(g, carColor, windshieldColor, wheelColor);

        }
        private void DrawTruck(Graphics g, SolidBrush truckColor, SolidBrush cabinColor, SolidBrush windshieldColor, SolidBrush wheelColor)
        {
            g.FillEllipse(wheelColor, 310, 215, 70, 70);
            g.DrawEllipse(Pens.Silver, 310, 215, 70, 70);
            g.FillEllipse(wheelColor, 360, 215, 70, 70);
            g.DrawEllipse(Pens.Silver, 360, 215, 70, 70);
            g.FillEllipse(wheelColor, 470, 215, 70, 70);
            g.DrawEllipse(Pens.Silver, 470, 215, 70, 70);
            g.FillEllipse(wheelColor, 520, 215, 70, 70);
            g.DrawEllipse(Pens.Silver, 520, 215, 70, 70);
            g.FillRectangle(truckColor, 300, 150, 300, 100);
            g.FillRectangle(cabinColor, 600, 175, 65, 75);
            g.FillRectangle(windshieldColor, 630, 175, 35, 45);
        }
        private void DrawCar(Graphics g, SolidBrush carColor, SolidBrush windshieldColor, SolidBrush wheelColor)
        {
            g.FillRectangle(carColor, 100, 270, 170, 120);
            g.FillRectangle(carColor, 50, 340, 270, 70);
            g.FillRectangle(windshieldColor, 170, 270, 100, 45);
            g.FillEllipse(wheelColor, 60, 370, 70, 70);
            g.DrawEllipse(Pens.Silver, 60, 370, 70, 70);
            g.FillEllipse(wheelColor, 240, 370, 70, 70);
            g.DrawEllipse(Pens.Silver, 240, 370, 70, 70);
        }
    }
}
