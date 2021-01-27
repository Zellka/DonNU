using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_graphic_8
{
    public partial class Form1 : Form
    {
        int moneyCount = 0;
        PictureBox cobra = new PictureBox();
        PictureBox man = new PictureBox();
        PictureBox shrub = new PictureBox();
        PictureBox fiveCoin = new PictureBox();
        PictureBox oneCoin = new PictureBox();
        int manSpeed = 30;
        Timer timer;

        public Form1()  {  InitializeComponent();  }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"house.jpg");
            label_money_count.Text = moneyCount.ToString();
        }
        private void button_start_game_Click(object sender, EventArgs e)
        {
            button_start_game.Visible = false;
            DrawGamePlatform();
            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += timer1_Tick;
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cobra.Left += 2;
            Rectangle rMan = man.DisplayRectangle;
            rMan.Location = man.Location;
            Rectangle rCobra = cobra.DisplayRectangle;
            rCobra.Location = cobra.Location;
            if (rCobra.IntersectsWith(rMan))
            {
                timer.Stop();
                LosingMessage();
            }
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            if (man.Left + man.Width + manSpeed < pictureBox1.Image.Width) 
            {
                man.Left += manSpeed;
                Collision();
            }  
            else VictoryMessage();
        }
        private void button_up_Click(object sender, EventArgs e)
        {
            if (man.Left + man.Width + manSpeed < pictureBox1.Image.Width-50)
            {
                man.Top -= 60;
                man.Left += 280;
                System.Threading.Thread.Sleep(100);
                man.Top += 60;
                Collision();
            }
            else VictoryMessage();
        }
        private void button_left_Click(object sender, EventArgs e)
        {
            if (man.Left >= manSpeed)
            {
                man.Left -= 20;
                Collision();
            }
        }
        private void VictoryMessage()
        {
            man.Dispose();
            DialogResult result = MessageBox.Show("ПОБЕДА!");
            if (result == DialogResult.OK) this.Close();
        }
        private void LosingMessage()
        {
            man.Dispose();
            DialogResult result = MessageBox.Show("ПРОИГРЫШ");
            if (result == DialogResult.OK) this.Close();
        }
        private void Collision()
        {
            Rectangle rMan = man.DisplayRectangle;
            rMan.Location = man.Location;
            Rectangle rFiveCoin = fiveCoin.DisplayRectangle;
            rFiveCoin.Location = fiveCoin.Location;
            Rectangle rOneCoin = oneCoin.DisplayRectangle;
            rOneCoin.Location = oneCoin.Location;
            Rectangle rShrub = shrub.DisplayRectangle;
            rShrub.Location = shrub.Location;
            if (rMan.IntersectsWith(rFiveCoin) && moneyCount < 60)
            {
                fiveCoin.Dispose();
                moneyCount += 50;
            }
            if (rMan.IntersectsWith(rOneCoin) && moneyCount < 10)
            {
                oneCoin.Dispose();
                moneyCount += 10;
            }
            if (rMan.IntersectsWith(rShrub))
            {
                LosingMessage();
            }
            label_money_count.Text = moneyCount.ToString();
        }

        private void DrawGamePlatform()
        {
            man.Image = Image.FromFile(@"man.png");
            man.BackColor = Color.Transparent;
            man.Location = new Point(0, 370);
            man.Size = new Size(man.Image.Width, man.Image.Height);
            pictureBox1.Controls.Add(man);
            man.BringToFront();

            cobra.Image = Image.FromFile(@"cobra.png");
            cobra.BackColor = Color.Transparent;
            cobra.Location = new Point(-250, 400);
            cobra.Size = new Size(cobra.Image.Width, cobra.Image.Height);
            pictureBox1.Controls.Add(cobra);
            cobra.BringToFront();

            shrub.Image = Image.FromFile(@"shrub.png");
            shrub.BackColor = Color.Transparent;
            shrub.Location = new Point(350, 450);
            shrub.Size = new Size(shrub.Image.Width, shrub.Image.Height);
            pictureBox1.Controls.Add(shrub);
            shrub.BringToFront();

            oneCoin.Image = Image.FromFile(@"one.png");
            oneCoin.BackColor = Color.Transparent;
            oneCoin.Location = new Point(550, 450);
            oneCoin.Size = new Size(oneCoin.Image.Width, oneCoin.Image.Height);
            pictureBox1.Controls.Add(oneCoin);
            oneCoin.BringToFront();

            fiveCoin.Image = Image.FromFile(@"five.png");
            fiveCoin.BackColor = Color.Transparent;
            fiveCoin.Location = new Point(820, 450);
            fiveCoin.Size = new Size(fiveCoin.Image.Width, fiveCoin.Image.Height);
            pictureBox1.Controls.Add(fiveCoin);
            fiveCoin.BringToFront();
        }
    }
}
