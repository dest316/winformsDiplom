namespace dIplom3
{
    partial class SoundSourceEditForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.soundParametersContainer = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.soundParametersContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // soundParametersContainer
            // 
            this.soundParametersContainer.AllowUserToAddRows = false;
            this.soundParametersContainer.AllowUserToDeleteRows = false;
            this.soundParametersContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.soundParametersContainer.Location = new System.Drawing.Point(60, 52);
            this.soundParametersContainer.Name = "soundParametersContainer";
            this.soundParametersContainer.RowHeadersWidth = 51;
            this.soundParametersContainer.RowTemplate.Height = 24;
            this.soundParametersContainer.Size = new System.Drawing.Size(444, 381);
            this.soundParametersContainer.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(197, 453);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(148, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SoundSourceEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 593);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.soundParametersContainer);
            this.KeyPreview = true;
            this.Name = "SoundSourceEditForm";
            this.Text = "SoundeSourceEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.soundParametersContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView soundParametersContainer;
        private System.Windows.Forms.Button saveButton;
    }
}