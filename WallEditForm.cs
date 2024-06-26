using Org.BouncyCastle.Tls;
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
    public partial class WallEditForm : Form
    {
        private Line sender;
        public WallEditForm(Line sender, DataTable info)
        {
            InitializeComponent();
            this.sender = sender;
            materialsList.Items.Add("Не выбрано");
            materialsList.Items.AddRange(info.AsEnumerable().Select(row => row.Field<string>("material_name")).ToArray());
            materialsList.SelectedItem = sender.MaterialName;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.sender.MaterialName = materialsList.SelectedItem.ToString();
        }
    }
}
