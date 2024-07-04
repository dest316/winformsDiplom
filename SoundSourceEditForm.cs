using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dIplom3
{
    public partial class SoundSourceEditForm : Form
    {
        private DataTable parameters;
        public string senderName {get; set;}
        private Dictionary<string, string> currentParameters;
        public SoundSourceEditForm(DataTable parameters, Dictionary<string, string> currentParameters, string senderName)
        {
            InitializeComponent();
            
            this.parameters = parameters;
            this.senderName = senderName;
            this.currentParameters = currentParameters;
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "ParameterName";
            nameColumn.HeaderText = "Параметр";
            nameColumn.ReadOnly = true;
            soundParametersContainer.Columns.Add(nameColumn);

            var valueColumn = new DataGridViewTextBoxColumn();
            valueColumn.Name = "ParameterValue";
            valueColumn.HeaderText = "Value";
            soundParametersContainer.Columns.Add(valueColumn);

            var unitColumn = new DataGridViewTextBoxColumn();
            unitColumn.Name = "ParameterUnits";
            unitColumn.HeaderText = "Единицы измерения";
            unitColumn.ReadOnly = true;
            soundParametersContainer.Columns.Add(unitColumn);
            LoadParameters();
        }

        private void LoadParameters()
        {
            foreach (DataRow row in parameters.Rows)
            {
                
                if (!currentParameters.TryGetValue(row["parameter_name"].ToString(), out string value)) 
                {
                    value = "";
                }
                soundParametersContainer.Rows.Add(row["parameter_name"], value, row["parameter_units"]);

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool success = true;
            foreach (DataGridViewRow row in soundParametersContainer.Rows)
            {         
                List<string> values = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    values.Add(cell.Value?.ToString());
                }
                DataRow[] foundRows = parameters.Select($"parameter_name = '{values[0]}'");
                string parameter_range = foundRows[0]["parameter_range"].ToString();
                var range = parameter_range.Split(';').Select(x => x == "" ? null : x).ToList();
                int? typed_value = null;
                try
                {
                    typed_value = int.Parse(values[1]);
                }
                catch (FormatException ex)
                {
                    success = false;
                }
                if (range[0] != null)
                {
                    if (typed_value < int.Parse(range[0])) { success = false; }
                }
                if (range[1] != null)
                {
                    if (typed_value > int.Parse(range[1])) { success = false; }
                }
            }
            if (success)
            {
                foreach (DataGridViewRow row in soundParametersContainer.Rows)
                {
                    List<string> values = new List<string>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        values.Add(cell.Value?.ToString());
                    }
                    currentParameters[values[0]] = values[1];
                }
            }
            else
            {
                MessageBox.Show("Параметры были введены неверно");
            }
        }
    }
}
