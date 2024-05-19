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
            this.paramsTable = new System.Windows.Forms.TableLayoutPanel();
            this.newParameterNameLabel = new System.Windows.Forms.Label();
            this.newParameterValueLabel = new System.Windows.Forms.Label();
            this.newParameterNameTextBox = new System.Windows.Forms.TextBox();
            this.newParameterValueTextBox = new System.Windows.Forms.TextBox();
            this.updateParametersButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // paramsTable
            // 
            this.paramsTable.AutoScroll = true;
            this.paramsTable.AutoSize = true;
            this.paramsTable.ColumnCount = 2;
            this.paramsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.paramsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.paramsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.paramsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.paramsTable.Location = new System.Drawing.Point(37, 23);
            this.paramsTable.Name = "paramsTable";
            this.paramsTable.RowCount = 10;
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.33333F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.66667F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.paramsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.paramsTable.Size = new System.Drawing.Size(491, 383);
            this.paramsTable.TabIndex = 1;
            // 
            // newParameterNameLabel
            // 
            this.newParameterNameLabel.AutoSize = true;
            this.newParameterNameLabel.Location = new System.Drawing.Point(34, 419);
            this.newParameterNameLabel.Name = "newParameterNameLabel";
            this.newParameterNameLabel.Size = new System.Drawing.Size(197, 16);
            this.newParameterNameLabel.TabIndex = 2;
            this.newParameterNameLabel.Text = "Название нового параметра";
            // 
            // newParameterValueLabel
            // 
            this.newParameterValueLabel.AutoSize = true;
            this.newParameterValueLabel.Location = new System.Drawing.Point(289, 419);
            this.newParameterValueLabel.Name = "newParameterValueLabel";
            this.newParameterValueLabel.Size = new System.Drawing.Size(196, 16);
            this.newParameterValueLabel.TabIndex = 3;
            this.newParameterValueLabel.Text = "Значение нового параметра";
            // 
            // newParameterNameTextBox
            // 
            this.newParameterNameTextBox.Location = new System.Drawing.Point(37, 451);
            this.newParameterNameTextBox.Name = "newParameterNameTextBox";
            this.newParameterNameTextBox.Size = new System.Drawing.Size(194, 22);
            this.newParameterNameTextBox.TabIndex = 4;
            // 
            // newParameterValueTextBox
            // 
            this.newParameterValueTextBox.Location = new System.Drawing.Point(292, 450);
            this.newParameterValueTextBox.Name = "newParameterValueTextBox";
            this.newParameterValueTextBox.Size = new System.Drawing.Size(193, 22);
            this.newParameterValueTextBox.TabIndex = 5;
            // 
            // updateParametersButton
            // 
            this.updateParametersButton.Location = new System.Drawing.Point(232, 494);
            this.updateParametersButton.Name = "updateParametersButton";
            this.updateParametersButton.Size = new System.Drawing.Size(90, 23);
            this.updateParametersButton.TabIndex = 6;
            this.updateParametersButton.Text = "Изменить";
            this.updateParametersButton.UseVisualStyleBackColor = true;
            this.updateParametersButton.Click += new System.EventHandler(this.updateParametersButton_Click);
            // 
            // SoundSourceEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 593);
            this.Controls.Add(this.updateParametersButton);
            this.Controls.Add(this.newParameterValueTextBox);
            this.Controls.Add(this.newParameterNameTextBox);
            this.Controls.Add(this.newParameterValueLabel);
            this.Controls.Add(this.newParameterNameLabel);
            this.Controls.Add(this.paramsTable);
            this.KeyPreview = true;
            this.Name = "SoundSourceEditForm";
            this.Text = "SoundeSourceEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel paramsTable;
        private System.Windows.Forms.Label newParameterNameLabel;
        private System.Windows.Forms.Label newParameterValueLabel;
        private System.Windows.Forms.TextBox newParameterNameTextBox;
        private System.Windows.Forms.TextBox newParameterValueTextBox;
        private System.Windows.Forms.Button updateParametersButton;
    }
}