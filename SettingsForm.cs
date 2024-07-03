using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace dIplom3
{
    public partial class SettingsForm : Form
    {
        Form1 parentForm;
        public SettingsForm(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            string[] connectionData = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString.Split(';');
            serverTextBox.Text = connectionData[0].Split('=')[1];
            databaseTextBox.Text = connectionData[1].Split('=')[1];
            usernameTextBox.Text = connectionData[2].Split('=')[1];
            passwordTextBox.Text = connectionData[3].Split('=')[1];
            tasksList.DataSource = parentForm.acceptableTasks;
            tasksList.DisplayMember = "task_name";
            tasksList.ValueMember = "task_name";
            if (tasksList.Items.Contains(ConfigurationManager.AppSettings["task"]))
            {
                Debug.WriteLine("text");
                tasksList.SelectedItem = ConfigurationManager.AppSettings["task"];
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                parentForm.ConnectToDatabase(serverTextBox.Text, databaseTextBox.Text, usernameTextBox.Text, passwordTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных с указанными данными", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void localSaveButton_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionString = config.ConnectionStrings.ConnectionStrings["db_connection"];
            if (connectionString != null)
            {
                connectionString.ConnectionString = $"Server={serverTextBox.Text};Database={databaseTextBox.Text};Username={usernameTextBox.Text};Password={passwordTextBox.Text}";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        private void saveTaskButton_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["task"] != null)
            {
                config.AppSettings.Settings["task"].Value = tasksList.Text;
            }
            else
            {
                config.AppSettings.Settings.Add("task", tasksList.Text);
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
