namespace dIplom3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cursorButton = new System.Windows.Forms.Button();
            this.soundSourceButton = new System.Windows.Forms.Button();
            this.wallButton = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cursorButton);
            this.panel1.Controls.Add(this.soundSourceButton);
            this.panel1.Controls.Add(this.wallButton);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(58, 435);
            this.panel1.TabIndex = 0;
            // 
            // cursorButton
            // 
            this.cursorButton.Location = new System.Drawing.Point(0, 122);
            this.cursorButton.Name = "cursorButton";
            this.cursorButton.Size = new System.Drawing.Size(57, 55);
            this.cursorButton.TabIndex = 2;
            this.cursorButton.Text = "Выделение";
            this.cursorButton.UseVisualStyleBackColor = true;
            this.cursorButton.Click += new System.EventHandler(this.cursorButton_Click);
            // 
            // soundSourceButton
            // 
            this.soundSourceButton.Location = new System.Drawing.Point(0, 59);
            this.soundSourceButton.Name = "soundSourceButton";
            this.soundSourceButton.Size = new System.Drawing.Size(57, 57);
            this.soundSourceButton.TabIndex = 2;
            this.soundSourceButton.Text = "Звук";
            this.soundSourceButton.UseVisualStyleBackColor = true;
            this.soundSourceButton.Click += new System.EventHandler(this.soundSourceButton_Click);
            // 
            // wallButton
            // 
            this.wallButton.Location = new System.Drawing.Point(0, 0);
            this.wallButton.Name = "wallButton";
            this.wallButton.Size = new System.Drawing.Size(57, 53);
            this.wallButton.TabIndex = 0;
            this.wallButton.Text = "Стена\r\n";
            this.wallButton.UseVisualStyleBackColor = true;
            this.wallButton.Click += new System.EventHandler(this.wallButtonClick);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(354, 35);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(753, 435);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 504);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button wallButton;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button soundSourceButton;
        private System.Windows.Forms.Button cursorButton;
    }
}

