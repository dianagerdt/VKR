using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace RustabBot_v1._0
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FromFileRadioButton.Checked = true;
            ByHandRadioButton.Checked = false;
            LoadTrajectoryTextBox.Visible = true;
            LoadTrajectoryButton.Visible = true;
            TrajectorySettingsButton.Visible = false;

            InfluentFactorsDataGridView.AllowUserToAddRows = false;
            InfluentFactorsDataGridView.RowHeadersVisible = false;
        }

        private void ByHandRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            FromFileRadioButton.Checked = false;
            ByHandRadioButton.Checked = true;
            LoadTrajectoryTextBox.Visible = false;
            LoadTrajectoryButton.Visible = false;
            TrajectorySettingsButton.Visible = true;
        }

        private void FromFileRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            FromFileRadioButton.Checked = true;
            ByHandRadioButton.Checked = false;
            LoadTrajectoryTextBox.Visible = true;
            LoadTrajectoryButton.Visible = true;
            TrajectorySettingsButton.Visible = false;
        }

        private void TrajectorySettingsButton_Click(object sender, EventArgs e)
        {
            var trajectorySettings = new TrajectorySettingsForm();
            trajectorySettings.Show();
        }

        private void DBConnectionButton_Click(object sender, EventArgs e)
        {
            var dbconnection = new DBConnectionForm();
            dbconnection.Show();
        }

        // Открытие диалогового окна, выбор файла и запись его пути в Текстбокс
        public void LoadInitialFile(string openFileDialogFilter, OpenFileDialog openFileDialog, TextBox textbox, RastrSupplier rastrSupplier)
        {
            openFileDialog.Filter = openFileDialogFilter;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textbox.Text = openFileDialog.FileName;
                    rastrSupplier.LoadFile(openFileDialog.FileName, "");
                }
                catch (Exception exeption)
                {
                    textbox.Text = "";
                    MessageBox.Show("Ошибка! Вы загрузили файл неверного формата.\nПопробуйте ещё раз.\n" + exeption.Message);
                }
            }
        }

        // Загрузка самого файла rst
        private void LoadRstButton_Click(object sender, EventArgs e)
        {
            RastrSupplier rastrSupplier = new RastrSupplier();
            string RstFilter = "Файл динамики (*.rst)|*.rst";
            LoadInitialFile(RstFilter, RstOpenFileDialog, LoadRstTextBox, rastrSupplier);
        }

        private void LoadSchButton_Click(object sender, EventArgs e)
        {
            RastrSupplier rastrSupplier = new RastrSupplier();
            string SchFilter = "Файл сечения (*.sch)|*.sch";
            LoadInitialFile(SchFilter, SchOpenFileDialog, LoadSchTextBox, rastrSupplier);
        }

        private void LoadDfwButton_Click(object sender, EventArgs e)
        {
            RastrSupplier rastrSupplier = new RastrSupplier();
            string DfwFilter = "Файл автоматики (*.dfw)|*.dfw";
            LoadInitialFile(DfwFilter, DfwOpenFileDialog, LoadDfwTextBox, rastrSupplier);
        }

        private void LoadTrajectoryButton_Click(object sender, EventArgs e)
        {
            RastrSupplier rastrSupplier = new RastrSupplier();
            string Ut2Filter = "Файл траектории (*.ut2)|*.ut2";
            LoadInitialFile(Ut2Filter, Ut2OpenFileDialog, LoadTrajectoryTextBox, rastrSupplier);
        }

        private void LoadScnButton_Click(object sender, EventArgs e)
        {
            LoadScnListBox.Text = "";
            RastrSupplier rastrSupplier = new RastrSupplier();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = false; //прикол
            dialog.Multiselect = true;
            dialog.Filters.Add(new CommonFileDialogFilter("Файлы сценария", "*.scn"));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                LoadScnListBox.Items.AddRange(dialog.FileNames.ToArray());
                foreach(string fileName in dialog.FileNames)
                {
                    rastrSupplier.LoadFile(fileName, "");
                }
                MessageBox.Show("Файлы сценариев успешно загружены в рабочую область.");
            }

        }
    }
}
