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
using System.Text.RegularExpressions;

namespace _3_лаба
{
    public partial class DirectoryBrowser : Form
    {
        public DirectoryBrowser() {  InitializeComponent(); }
        private void Tree_BeforeExpand(object sender, TreeViewCancelEventArgs e) { Build(e.Node); }
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e) //после нажатия по папке (ветке дерева) 
        {                                                                    //происходит заполнение таблицы
            TreeNode selectedNode = e.Node;
            string fullPath = selectedNode.FullPath;
            DirectoryInfo di = new DirectoryInfo(fullPath);
            FileInfo[] fiArray;
            DirectoryInfo[] diArray;
            try
            {
                fiArray = di.GetFiles();
                diArray = di.GetDirectories();
            }
            catch { return; }
            DataTable.Items.Clear(); //очищаем таблицу перед каждым "обновлением"
            foreach (DirectoryInfo dirInfo in diArray) //папки
            {
                ListViewItem list = new ListViewItem(dirInfo.Name);
                list.Checked = true;
                list.SubItems.Add(" ");
                list.SubItems.Add("Folder with files");
                DataTable.Items.Add(list);
            }
            long small = 0, mid = 0, big = 0;
            long count = 0;
            foreach (FileInfo fileInfo in fiArray) //файлы
            {
                count += fileInfo.Length;
                string name = fileInfo.Name; 
                ListViewItem list = new ListViewItem(name);
                list.Checked = true;
                list.Tag = fileInfo.FullName; 
                list.SubItems.Add(fileInfo.Length.ToString() + " B"); //размер файла
                string type;
                Regex reg = new Regex(@"(\.\w{1,4}$)"); //ищет в конце строки от 1 до 4 символом, перед которыми стоит "."
                foreach (Match wrd in reg.Matches(name)) 
                {
                    type = wrd.ToString(); //тип файла 
                    list.SubItems.Add(type);
                    DataTable.Items.Add(list);
                    //окрашивание строк таблицы
                    if (type == ".png" || type == ".jpg" || type == ".bmp" || type == ".gif" || type == ".JPG")
                        list.BackColor = Color.Thistle; //светло-фиолетовый
                    else if (type == ".docx" || type == ".xlsx" || type == ".pdf" || type == ".txt")
                        list.BackColor = Color.LightGreen;
                    else if (type == ".zip" || type == ".rar" || type == ".7z")
                        list.BackColor = Color.Khaki;
                    else if (type == ".exe" || type == ".dll" || type == ".ini")
                        list.BackColor = Color.Pink;
                }
                //график (6 вариант)
                Chart.Series.Clear();
                Chart.Series.Add("Maximum file size");
                if (fileInfo.Length <= 100000)
                {
                    if (fileInfo.Length > small)
                        small = fileInfo.Length;
                }
                if (fileInfo.Length > 100000 && fileInfo.Length < 1000000)
                {
                    if (fileInfo.Length > mid)
                        mid = fileInfo.Length;
                }
                if (fileInfo.Length >= 1000000)
                {
                    if (fileInfo.Length > big)
                        big = fileInfo.Length;
                }
                Chart.Series[0].Points.AddXY("Small", small);
                Chart.Series[0].Points.AddXY("Mid", mid);
                Chart.Series[0].Points.AddXY("Big", big);
                
            }
            statusStrip1.Items[0].Text = "Total bytes: " + count; 
            statusStrip1.Items[1].Text = DataTable.CheckedItems.Count + " of " + DataTable.CheckedItems.Count + " items selected"; //эта строка изначально
        }
        private void Build(TreeNode parent) //формирование дерева
        {
            var path = parent.Tag as string;
            parent.Nodes.Clear();
            foreach (var dir in Directory.GetDirectories(path))
                parent.Nodes.Add(new TreeNode(Path.GetFileName(dir), new[] { new TreeNode("...") }) { Tag = dir });
            foreach (var file in Directory.GetFiles(path))
                parent.Nodes.Add(new TreeNode(Path.GetFileName(file), 1, 1) { Tag = file });
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e) //пункт меню "Оpen"                
        {                                                                    
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TreeNode node = new TreeNode() { Text = fbd.SelectedPath.ToString(), Tag = fbd.SelectedPath };
                Tree.Nodes.Add(node);
                Build(node);
                node.Expand();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //пункт меню "Save"
        {                   
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TreeNode TNode = Tree.SelectedNode;
                string DI_path = TNode.FullPath;
                string path = fbd.SelectedPath + @"\saved.txt";
                FileStream FS = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter file = new StreamWriter(FS);
                DirectoryInfo DI = new DirectoryInfo(DI_path);
                DirectoryInfo[] dir = DI.GetDirectories();
                foreach (DirectoryInfo s in dir)
                    file.Write(s.Name + "\n");
                file.Close();
                FS.Close();
            }
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e) //возможность выбрать цвет текста в таблице
        {
            ColorDialog color = new ColorDialog();
            if(color.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                DataTable.ForeColor = color.Color;
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e) //возможность выбрать шрифт текста в таблице
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                DataTable.Font = font.Font;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string caption = "Завершить работу?";
            string message = "Работу выполнила Зелинская Илона\n" + "\t1 курс, ИВТ-3";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e) 
        {  
            MessageBox.Show("Если в стутусной строке не изменяется" +
                             "\nкол-во выбранных элементов, а вы их меняли." +
                             "\nПопробуйте после того, как вы убрали(поставили) галочку," +
                             "\nнажать на ячейку в колонке Name (желательно именно на текст)"); 
        }
        private void DataTable_SelectedIndexChanged(object sender, EventArgs e) //эта строка, когда изменяется количество выделенных элементов
        {
            if (DataTable.SelectedIndices.Count > 0)
            {
                int total = DataTable.Items.Count;
                int elem = DataTable.CheckedItems.Count;
                statusStrip1.Items[1].Text = elem + " of " + total + " items selected";
            }
        }
        private void DirectoryBrowser_Load(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "";
            statusStrip1.Items[1].Text = "";
        }
    }
}
