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

namespace Laba_graphic_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.FillRectangle(new LinearGradientBrush(new Point(0, 0),
                              new Point(ClientRectangle.Width, ClientRectangle.Height),
                              Color.LightPink, Color.Red), ClientRectangle);
            g.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
