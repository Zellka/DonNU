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
    public partial class AddEventForm : Form
    {
       
        public AddEventForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrganizerForm.Dt.dText = date.Value.ToString("dd.MM.yyyy");
            OrganizerForm.Dt.tTime = time.Text;
            OrganizerForm.Dt.tEvent = textEvent.Text;
            OrganizerForm.Dt.tType = type.Text;
            this.Close();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Today;
            if(date.Value < now)
                MessageBox.Show("This date has already passed");
        }

    }
}
