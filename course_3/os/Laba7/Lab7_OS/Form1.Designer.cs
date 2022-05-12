namespace Laba7.View
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFileBtn = new System.Windows.Forms.Button();
            this.fileContent = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorList = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AnalyzeFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.BackColor = System.Drawing.Color.LightCoral;
            this.OpenFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFileBtn.Location = new System.Drawing.Point(127, 670);
            this.OpenFileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(322, 50);
            this.OpenFileBtn.TabIndex = 0;
            this.OpenFileBtn.Text = "Open file";
            this.OpenFileBtn.UseVisualStyleBackColor = false;
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // fileContent
            // 
            this.fileContent.BackColor = System.Drawing.Color.White;
            this.fileContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileContent.Location = new System.Drawing.Point(25, 65);
            this.fileContent.Margin = new System.Windows.Forms.Padding(4);
            this.fileContent.Name = "fileContent";
            this.fileContent.ReadOnly = true;
            this.fileContent.Size = new System.Drawing.Size(498, 576);
            this.fileContent.TabIndex = 1;
            this.fileContent.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(219, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "File contents";
            // 
            // errorList
            // 
            this.errorList.BackColor = System.Drawing.Color.White;
            this.errorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorList.ForeColor = System.Drawing.Color.Black;
            this.errorList.Location = new System.Drawing.Point(544, 65);
            this.errorList.Margin = new System.Windows.Forms.Padding(4);
            this.errorList.Name = "errorList";
            this.errorList.ReadOnly = true;
            this.errorList.Size = new System.Drawing.Size(524, 576);
            this.errorList.TabIndex = 3;
            this.errorList.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(739, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "List of errors";
            // 
            // AnalyzeFileBtn
            // 
            this.AnalyzeFileBtn.BackColor = System.Drawing.Color.LightGreen;
            this.AnalyzeFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnalyzeFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AnalyzeFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnalyzeFileBtn.Location = new System.Drawing.Point(667, 670);
            this.AnalyzeFileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AnalyzeFileBtn.Name = "AnalyzeFileBtn";
            this.AnalyzeFileBtn.Size = new System.Drawing.Size(322, 50);
            this.AnalyzeFileBtn.TabIndex = 5;
            this.AnalyzeFileBtn.Text = "Analyze file";
            this.AnalyzeFileBtn.UseVisualStyleBackColor = false;
            this.AnalyzeFileBtn.Click += new System.EventHandler(this.AnalyzeFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 742);
            this.Controls.Add(this.AnalyzeFileBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileContent);
            this.Controls.Add(this.OpenFileBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1121, 789);
            this.MinimumSize = new System.Drawing.Size(1121, 789);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFileBtn;
        private System.Windows.Forms.RichTextBox fileContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox errorList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AnalyzeFileBtn;
    }
}

