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
            this.interiorObjectButton = new System.Windows.Forms.Button();
            this.doorButton = new System.Windows.Forms.Button();
            this.windowButton = new System.Windows.Forms.Button();
            this.cursorButton = new System.Windows.Forms.Button();
            this.soundSourceButton = new System.Windows.Forms.Button();
            this.wallButton = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.модельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isClosedLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.interiorObjectButton);
            this.panel1.Controls.Add(this.doorButton);
            this.panel1.Controls.Add(this.windowButton);
            this.panel1.Controls.Add(this.cursorButton);
            this.panel1.Controls.Add(this.soundSourceButton);
            this.panel1.Controls.Add(this.wallButton);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 435);
            this.panel1.TabIndex = 0;
            // 
            // interiorObjectButton
            // 
            this.interiorObjectButton.Location = new System.Drawing.Point(1, 252);
            this.interiorObjectButton.Name = "interiorObjectButton";
            this.interiorObjectButton.Size = new System.Drawing.Size(94, 57);
            this.interiorObjectButton.TabIndex = 5;
            this.interiorObjectButton.Text = "Интерьер";
            this.interiorObjectButton.UseVisualStyleBackColor = true;
            this.interiorObjectButton.Click += new System.EventHandler(this.wallButtonClick);
            // 
            // doorButton
            // 
            this.doorButton.Location = new System.Drawing.Point(1, 189);
            this.doorButton.Name = "doorButton";
            this.doorButton.Size = new System.Drawing.Size(94, 57);
            this.doorButton.TabIndex = 4;
            this.doorButton.Text = "Дверь";
            this.doorButton.UseVisualStyleBackColor = true;
            this.doorButton.Click += new System.EventHandler(this.wallButtonClick);
            // 
            // windowButton
            // 
            this.windowButton.Location = new System.Drawing.Point(1, 126);
            this.windowButton.Name = "windowButton";
            this.windowButton.Size = new System.Drawing.Size(94, 57);
            this.windowButton.TabIndex = 3;
            this.windowButton.Text = "Окно";
            this.windowButton.UseVisualStyleBackColor = true;
            this.windowButton.Click += new System.EventHandler(this.wallButtonClick);
            // 
            // cursorButton
            // 
            this.cursorButton.Location = new System.Drawing.Point(1, 0);
            this.cursorButton.Name = "cursorButton";
            this.cursorButton.Size = new System.Drawing.Size(94, 57);
            this.cursorButton.TabIndex = 2;
            this.cursorButton.Text = "Выделение";
            this.cursorButton.UseVisualStyleBackColor = true;
            this.cursorButton.Click += new System.EventHandler(this.cursorButton_Click);
            // 
            // soundSourceButton
            // 
            this.soundSourceButton.Location = new System.Drawing.Point(1, 315);
            this.soundSourceButton.Name = "soundSourceButton";
            this.soundSourceButton.Size = new System.Drawing.Size(94, 57);
            this.soundSourceButton.TabIndex = 2;
            this.soundSourceButton.Text = "Звук";
            this.soundSourceButton.UseVisualStyleBackColor = true;
            this.soundSourceButton.Click += new System.EventHandler(this.soundSourceButton_Click);
            // 
            // wallButton
            // 
            this.wallButton.Location = new System.Drawing.Point(1, 63);
            this.wallButton.Name = "wallButton";
            this.wallButton.Size = new System.Drawing.Size(94, 57);
            this.wallButton.TabIndex = 0;
            this.wallButton.Text = "Стена\r\n";
            this.wallButton.UseVisualStyleBackColor = true;
            this.wallButton.Click += new System.EventHandler(this.wallButtonClick);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(212, 35);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1480, 878);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvasMouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasMouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvasMouseUp);
            // 
            // модельToolStripMenuItem
            // 
            this.модельToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.модельToolStripMenuItem.Name = "модельToolStripMenuItem";
            this.модельToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.модельToolStripMenuItem.Text = "Модель";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.importToolStripMenuItem.Text = "Импорт...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.exportToolStripMenuItem.Text = "Экспорт...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.модельToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // isClosedLabel
            // 
            this.isClosedLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.isClosedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.isClosedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.isClosedLabel.Location = new System.Drawing.Point(1398, 916);
            this.isClosedLabel.Name = "isClosedLabel";
            this.isClosedLabel.Padding = new System.Windows.Forms.Padding(3);
            this.isClosedLabel.Size = new System.Drawing.Size(294, 49);
            this.isClosedLabel.TabIndex = 3;
            this.isClosedLabel.Text = "Помещение не замкнуто";
            this.isClosedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.isClosedLabel);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button wallButton;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button soundSourceButton;
        private System.Windows.Forms.Button cursorButton;
        private System.Windows.Forms.ToolStripMenuItem модельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button windowButton;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button doorButton;
        private System.Windows.Forms.Button interiorObjectButton;
        private System.Windows.Forms.Label isClosedLabel;
    }
}

