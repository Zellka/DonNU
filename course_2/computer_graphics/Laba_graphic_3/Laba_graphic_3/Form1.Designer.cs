namespace Laba_graphic_3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_to_file = new System.Windows.Forms.Button();
            this.button_display = new System.Windows.Forms.Button();
            this.button_сlear = new System.Windows.Forms.Button();
            this.button_del_file = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1193, 664);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_to_file
            // 
            this.button_to_file.BackColor = System.Drawing.Color.Gainsboro;
            this.button_to_file.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_to_file.Location = new System.Drawing.Point(12, 673);
            this.button_to_file.Name = "button_to_file";
            this.button_to_file.Size = new System.Drawing.Size(273, 118);
            this.button_to_file.TabIndex = 1;
            this.button_to_file.Text = "Writing to file";
            this.button_to_file.UseVisualStyleBackColor = false;
            this.button_to_file.Click += new System.EventHandler(this.button_to_file_Click);
            // 
            // button_display
            // 
            this.button_display.BackColor = System.Drawing.Color.Gainsboro;
            this.button_display.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_display.Location = new System.Drawing.Point(317, 673);
            this.button_display.Name = "button_display";
            this.button_display.Size = new System.Drawing.Size(273, 118);
            this.button_display.TabIndex = 2;
            this.button_display.Text = "display";
            this.button_display.UseVisualStyleBackColor = false;
            this.button_display.Click += new System.EventHandler(this.button_display_Click);
            // 
            // button_сlear
            // 
            this.button_сlear.BackColor = System.Drawing.Color.Gainsboro;
            this.button_сlear.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_сlear.Location = new System.Drawing.Point(615, 673);
            this.button_сlear.Name = "button_сlear";
            this.button_сlear.Size = new System.Drawing.Size(273, 118);
            this.button_сlear.TabIndex = 3;
            this.button_сlear.Text = "Clear";
            this.button_сlear.UseVisualStyleBackColor = false;
            this.button_сlear.Click += new System.EventHandler(this.button_сlear_Click);
            // 
            // button_del_file
            // 
            this.button_del_file.BackColor = System.Drawing.Color.Gainsboro;
            this.button_del_file.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_del_file.Location = new System.Drawing.Point(913, 673);
            this.button_del_file.Name = "button_del_file";
            this.button_del_file.Size = new System.Drawing.Size(273, 118);
            this.button_del_file.TabIndex = 4;
            this.button_del_file.Text = "Delete file";
            this.button_del_file.UseVisualStyleBackColor = false;
            this.button_del_file.Click += new System.EventHandler(this.button_del_file_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 803);
            this.Controls.Add(this.button_del_file);
            this.Controls.Add(this.button_сlear);
            this.Controls.Add(this.button_display);
            this.Controls.Add(this.button_to_file);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_to_file;
        private System.Windows.Forms.Button button_display;
        private System.Windows.Forms.Button button_сlear;
        private System.Windows.Forms.Button button_del_file;
    }
}

