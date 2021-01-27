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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Today;
            if (date.Value < now)
                MessageBox.Show("This date has already passed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrganizerForm.Et.date = date.Value.ToString("dd.MM.yyyy");
            OrganizerForm.Et.time = time.Text;
            OrganizerForm.Et.txt = textEvent.Text;
            OrganizerForm.Et.type = type.Text;
            this.Close();
        }
    }
}
