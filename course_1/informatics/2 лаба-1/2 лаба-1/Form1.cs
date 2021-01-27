using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_лаба_1
{
    public partial class AutorizationForm : Form
    {
        public AutorizationForm()
        {
            InitializeComponent();
        }
        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked == false)
                textBox2.UseSystemPasswordChar = true;
            else
                textBox2.UseSystemPasswordChar = false;
        }
        private void OK_Click(object sender, EventArgs e)
        {
            OrganizerForm organizer = new OrganizerForm();
            if (textBox1.Text != "1" || textBox2.Text != "2")
                MessageBox.Show("Wrong login or password!");
            else
            {
                organizer.Show();
                this.Hide();
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }
    }
}
