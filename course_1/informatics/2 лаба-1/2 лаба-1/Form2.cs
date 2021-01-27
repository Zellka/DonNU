using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace _2_лаба_1
{
    
    public struct DataText    
    {
        public string dText;
        public string tTime;
        public string tEvent;
        public string tType;
        public string findTxt;
        public string filter;
    }
    public struct EditText
    {
        public string date;
        public string time;
        public string txt;
        public string type;
    }

    public partial class OrganizerForm : Form
    {
        static public DataText Dt;
        static public EditText Et;
        public OrganizerForm()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddEventForm addEvent = new AddEventForm();
            addEvent.ShowDialog();
            int index = listView1.Items.Add(Dt.dText).Index;
            listView1.Items[index].SubItems.Add(Dt.tTime);
            listView1.Items[index].SubItems.Add(Dt.tEvent);
            listView1.Items[index].SubItems.Add(Dt.tType);
        }
        private int indexSrch = 0;
    
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm();
            edit.ShowDialog();
            foreach (int k in listView1.SelectedIndices)
            {
                listView1.Items.Remove(listView1.Items[k]);
                int index = listView1.Items.Add(Et.date).Index;
                listView1.Items[index].SubItems.Add(Et.time);
                listView1.Items[index].SubItems.Add(Et.txt);
                listView1.Items[index].SubItems.Add(Et.type);
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int i in listView1.SelectedIndices)
            {
                string c1 = listView1.Items[i].SubItems[0].Text;
                string c2 = listView1.Items[i].SubItems[1].Text;
                string c3 = listView1.Items[i].SubItems[2].Text;
                string caption = c1 + " " + c2 + " " + c3;
                string message = "Are you sure you want to delete the record "+ "\n" + "«" + caption + "»" + " ?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo; 
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);       
                if (result == System.Windows.Forms.DialogResult.Yes)     
                {
                    foreach (int k in listView1.SelectedIndices)
                        listView1.Items.Remove(listView1.Items[k]);
                    MessageBox.Show("Removed");
                }
            }
        }
       
        private void OrganizerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                foreach (int i in listView1.SelectedIndices)
                {
                    string f1 = listView1.Items[i].SubItems[0].Text;
                    string f2 = listView1.Items[i].SubItems[1].Text;
                    string f3 = listView1.Items[i].SubItems[2].Text;
                    string f4 = listView1.Items[i].SubItems[3].Text;
                    string data = f1 + "-" + f2 + "-" + f3 + "-" + f4;
                    System.IO.File.WriteAllText(filename, data);
                }
                MessageBox.Show("Record Saved");
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;  
                string fileText = System.IO.File.ReadAllText(filename);
                string text = listView1.Items.ToString();
                text = fileText;
                MessageBox.Show("File open");
            }
            if (e.KeyCode == Keys.Delete)
            {
                foreach (int i in listView1.SelectedIndices)
                    listView1.Items.Remove(listView1.Items[i]);
                MessageBox.Show("Removed");
            }
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            int index = listView1.Items.Add("19.03.20").Index;  //изначальное заполнение органайзера
            listView1.Items[index].SubItems.Add("20:00");
            listView1.Items[index].SubItems.Add("Сдать работу");
            listView1.Items[index].SubItems.Add("Memo");
            int index1 = listView1.Items.Add("21.03.20").Index;
            listView1.Items[index1].SubItems.Add("20:00");
            listView1.Items[index1].SubItems.Add("Сделать реферат");
            listView1.Items[index1].SubItems.Add("Task");
            int inde = listView1.Items.Add("25.03.20").Index;
            listView1.Items[inde].SubItems.Add("20:22");
            listView1.Items[inde].SubItems.Add("Встреча с подругами");
            listView1.Items[inde].SubItems.Add("Meeting");
        }
        private void FilterBtn_Click(object sender, EventArgs e)
        {
            this.listView1.ListViewItemSorter = new ListViewItemComparer(2); //сортирует 3 столбец с текстом события (отсчёт от 0)
        }
        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer() { col = 0; }
            public ListViewItemComparer(int column) { col = column; }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            FindForm find = new FindForm();
            find.ShowDialog();
            if (listView1.Items.Count == 0)
                return;
            if (indexSrch == listView1.Items.Count)
            {
                MessageBox.Show("No More Items Found!");
                indexSrch = 0;
            }
            ListViewItem foundItem = listView1.FindItemWithText(Dt.findTxt, true, indexSrch, true);
            if (foundItem != null)
            {
                listView1.TopItem = foundItem;
                foundItem.Selected = true;
                listView1.Select();
                indexSrch = foundItem.Index + 1;
            }
            else
            {
                if (indexSrch.Equals(0))
                    MessageBox.Show("Items Not Found");
                else
                    MessageBox.Show("No More Items Found!");
                indexSrch = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            string value = comboBox1.Text;
            for (int i = listView1.Items.Count - 1; i > -1; i--)
            {
                 if
                 (listView1.Items[i].SubItems[3].Text.StartsWith(value) == false)
                 {
                    listView1.Items[i].Remove();
                 }
            }
        }
    }
    
}
