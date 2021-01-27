using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ex_b
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.White, 10, 120, 200, 250);

            g.DrawEllipse(Pens.White, 10, 20, 110, 45);
            g.DrawRectangle(Pens.White, 10, 70, 110, 45);

            g.FillEllipse(new LinearGradientBrush(new Point(0, 0),
               new Point(20, 40), Color.Yellow, Color.Red), 130, 20, 110, 45);
            g.FillRectangle(new LinearGradientBrush(new Point(0, 0),
               new Point(45, 75), Color.LightGreen, Color.DarkBlue), 130, 70, 110, 45);

            base.OnPaint(e);
        }
    }
}
