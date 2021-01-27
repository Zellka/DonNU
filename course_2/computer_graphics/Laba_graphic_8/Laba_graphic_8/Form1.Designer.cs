namespace Laba_graphic_8
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_money_count = new System.Windows.Forms.Label();
            this.button_start_game = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_left = new System.Windows.Forms.Button();
            this.button_up = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1918, 677);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(612, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "ВСЕГО: ";
            // 
            // label_money_count
            // 
            this.label_money_count.AutoSize = true;
            this.label_money_count.Font = new System.Drawing.Font("Segoe UI Historic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_money_count.Location = new System.Drawing.Point(750, 9);
            this.label_money_count.Name = "label_money_count";
            this.label_money_count.Size = new System.Drawing.Size(0, 38);
            this.label_money_count.TabIndex = 2;
            // 
            // button_start_game
            // 
            this.button_start_game.BackColor = System.Drawing.Color.LightGreen;
            this.button_start_game.Font = new System.Drawing.Font("Segoe UI Historic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start_game.Location = new System.Drawing.Point(1066, 11);
            this.button_start_game.Name = "button_start_game";
            this.button_start_game.Size = new System.Drawing.Size(158, 35);
            this.button_start_game.TabIndex = 3;
            this.button_start_game.Text = "Начать игру";
            this.button_start_game.UseVisualStyleBackColor = false;
            this.button_start_game.Click += new System.EventHandler(this.button_start_game_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_left
            // 
            this.button_left.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_left.Font = new System.Drawing.Font("Segoe UI Historic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_left.Location = new System.Drawing.Point(426, 740);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(167, 38);
            this.button_left.TabIndex = 4;
            this.button_left.Text = "Влево";
            this.button_left.UseVisualStyleBackColor = false;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            // 
            // button_up
            // 
            this.button_up.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_up.Font = new System.Drawing.Font("Segoe UI Historic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_up.Location = new System.Drawing.Point(637, 740);
            this.button_up.Name = "button_up";
            this.button_up.Size = new System.Drawing.Size(167, 38);
            this.button_up.TabIndex = 5;
            this.button_up.Text = "Вверх";
            this.button_up.UseVisualStyleBackColor = false;
            this.button_up.Click += new System.EventHandler(this.button_up_Click);
            // 
            // button_right
            // 
            this.button_right.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button_right.Font = new System.Drawing.Font("Segoe UI Historic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_right.Location = new System.Drawing.Point(855, 740);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(167, 38);
            this.button_right.TabIndex = 6;
            this.button_right.Text = "Вправо";
            this.button_right.UseVisualStyleBackColor = false;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1918, 790);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_up);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.button_start_game);
            this.Controls.Add(this.label_money_count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Змейка";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_money_count;
        private System.Windows.Forms.Button button_start_game;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_up;
        private System.Windows.Forms.Button button_right;
    }
}

