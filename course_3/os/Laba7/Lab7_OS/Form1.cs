using System;
using System.Windows.Forms;
using Laba7.Core;
using Laba7.Exceptions;

namespace Laba7.View
{
    public partial class Form1 : Form
    {
        private string[] content;

        private string errorMessage;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            FileReader fileReader = new FileReader(dialog.FileName);
            content = fileReader.ReadFile();
            fileContent.Lines = content;

            DefinedList.Clear();
            errorList.Text = string.Empty;
        }

        private void AnalyzeFileBtn_Click(object sender, EventArgs e)
        {
            LinesToCodeConverter converter = new LinesToCodeConverter(content);
            try
            {
                int[][] codes = converter.CalculateCodes();
                string[] codesFile = new string[codes.Length];
                for (int i = 0; i < codesFile.Length; i++)
                {
                    string line = string.Empty;
                    if (codes[i] == null) continue;
                    foreach (int code in codes[i])
                        line += code.ToString() + " ";
                    codesFile[i] = line;
                }

                CodeChecker checker = new CodeChecker(codes);
                checker.CheckSyntaxCorrection();
                fileContent.Lines = codesFile;
                MessageBox.Show("No errors", "No errors", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SyntaxException ex)
            {
                errorMessage = ex.Message;
                errorList.Text = errorMessage;
            }
        }
    }
}

