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
        private string senderName;
        public SoundSourceEditForm(Dictionary<string, string> parameters, string senderName)
        {
            InitializeComponent();
            this.parameters = parameters;
            this.senderName = senderName;
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

    }
}
