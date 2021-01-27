namespace Laba_graphic_2
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
            this.button_pixel = new System.Windows.Forms.Button();
            this.button_millimeter = new System.Windows.Forms.Button();
            this.button_inch = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1143, 574);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_pixel
            // 
            this.button_pixel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_pixel.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pixel.Location = new System.Drawing.Point(22, 592);
            this.button_pixel.Name = "button_pixel";
            this.button_pixel.Size = new System.Drawing.Size(194, 133);
            this.button_pixel.TabIndex = 1;
            this.button_pixel.Text = "Pixel";
            this.button_pixel.UseVisualStyleBackColor = false;
            this.button_pixel.Click += new System.EventHandler(this.button_pixel_Click);
            // 
            // button_millimeter
            // 
            this.button_millimeter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_millimeter.Font = new System.Drawing.Font("Showcard Gothic", 14F);
            this.button_millimeter.Location = new System.Drawing.Point(325, 592);
            this.button_millimeter.Name = "button_millimeter";
            this.button_millimeter.Size = new System.Drawing.Size(194, 133);
            this.button_millimeter.TabIndex = 2;
            this.button_millimeter.Text = "Millimeter";
            this.button_millimeter.UseVisualStyleBackColor = false;
            this.button_millimeter.Click += new System.EventHandler(this.button_millimeter_Click);
            // 
            // button_inch
            // 
            this.button_inch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_inch.Font = new System.Drawing.Font("Showcard Gothic", 14F);
            this.button_inch.Location = new System.Drawing.Point(624, 592);
            this.button_inch.Name = "button_inch";
            this.button_inch.Size = new System.Drawing.Size(194, 133);
            this.button_inch.TabIndex = 3;
            this.button_inch.Text = "Inch";
            this.button_inch.UseVisualStyleBackColor = false;
            this.button_inch.Click += new System.EventHandler(this.button_inch_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_clear.Font = new System.Drawing.Font("Showcard Gothic", 14F);
            this.button_clear.Location = new System.Drawing.Point(925, 592);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(194, 133);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(1146, 735);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_inch);
            this.Controls.Add(this.button_millimeter);
            this.Controls.Add(this.button_pixel);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_pixel;
        private System.Windows.Forms.Button button_millimeter;
        private System.Windows.Forms.Button button_inch;
        private System.Windows.Forms.Button button_clear;
    }
}

