using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_лаба
{
    public partial class AddLogo : Form
    {
        public AddLogo()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CopyrighterForm.Dt.text = textBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
