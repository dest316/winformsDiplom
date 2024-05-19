using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dIplom3
{
    public partial class SoundSourceEditForm : Form
    {
        private Dictionary<string, string> parameters;
        public string senderName {get; set;}
        public SoundSourceEditForm(Dictionary<string, string> parameters, string senderName)
        {
            InitializeComponent();
            this.KeyDown += SSEF_KeyDown;
            this.parameters = parameters;
            this.senderName = senderName;
            InitializeParamsTable(parameters);
        }
        //починить удаление
        private void SSEF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveFocusedRowFromTable();
            }
        }

        private void RemoveFocusedRowFromTable()
        {
            Control focusedControl = this.ActiveControl;
            if (focusedControl != null && focusedControl.Parent == paramsTable)
            {
                TableLayoutPanelCellPosition position = paramsTable.GetPositionFromControl(focusedControl);
                int rowToDelete = position.Row;
                for (int column = 0; column < paramsTable.ColumnCount; column++)
                {
                    Control control = paramsTable.GetControlFromPosition(column, rowToDelete);
                    if (control != null)
                    {
                        paramsTable.Controls.Remove(control);
                    }
                }
                for (int row = rowToDelete + 1; row < paramsTable.RowCount; row++)
                {
                    for (int column = 0; column < paramsTable.ColumnCount; column++)
                    {
                        Control control = paramsTable.GetControlFromPosition(column, row);
                        if (control != null)
                        {
                            paramsTable.SetRow(control, row - 1);
                        }
                    }
                }
                paramsTable.RowCount--;
            }
        }

        private void InitializeParamsTable(Dictionary<string, string> parameters) 
        {
            paramsTable.Controls.Clear();
            foreach (var pair in parameters)
            {
                Label label = new Label();
                label.Text = pair.Key;
                label.Location = new Point(10, 30 * paramsTable.RowCount);

                TextBox textBox = new TextBox();
                textBox.Text = pair.Value;
                textBox.Location = new Point(150, 30 * paramsTable.RowCount);

                paramsTable.Controls.Add(label);
                paramsTable.Controls.Add(textBox);
                paramsTable.RowCount++;
            }
        }

        private void updateParametersButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < paramsTable.RowCount; i++)
            {
                if (paramsTable.GetControlFromPosition(0, i) != null)
                {
                    parameters[paramsTable.GetControlFromPosition(0, i).Text] = paramsTable.GetControlFromPosition(1, i).Text;
                }
            }
            if (newParameterNameTextBox.Text != "" && newParameterValueTextBox.Text != "" && !parameters.ContainsKey(newParameterNameTextBox.Text))
            {
                parameters[newParameterNameTextBox.Text] = newParameterValueTextBox.Text;
            }
            newParameterNameTextBox.Clear();
            newParameterValueTextBox.Clear();
            InitializeParamsTable(parameters);
            MessageBox.Show("Данные сохранены");
        }
    }
}
