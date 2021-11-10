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
using System.Windows.Resources;


namespace RustabBot_v1._0
{
    public partial class MainForm : Form
    {
        private RastrSupplier _rastrSupplier = new RastrSupplier();

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

        // Открытие диалогового окна, выбор и загрузка файла и запись его пути в Текстбокс
        public void LoadInitialFile(string openFileDialogFilter, OpenFileDialog openFileDialog, 
            TextBox textbox, RastrSupplier rastrSupplier, string shablon)
        {
            openFileDialog.Filter = openFileDialogFilter;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textbox.Text = openFileDialog.FileName;
                    rastrSupplier.LoadFile(openFileDialog.FileName, shablon);
                }
                catch (Exception exeption)
                {
                    textbox.Text = "";
                    MessageBox.Show("Ошибка! Вы загрузили файл неверного формата." +
                        "\nПопробуйте ещё раз.\n" + exeption.Message);
                }
            }
        }

        // Загрузка самого файла rst
        private void LoadRstButton_Click(object sender, EventArgs e)
        {
            string RstFilter = "Файл динамики (*.rst)|*.rst";
            string shablon = @"../../Resources/динамика.rst";
            LoadInitialFile(RstFilter, RstOpenFileDialog, LoadRstTextBox, _rastrSupplier, shablon);
        }

        private void LoadSchButton_Click(object sender, EventArgs e)
        {
            string SchFilter = "Файл сечения (*.sch)|*.sch";
            string shablon = @"../../Resources/сечения.sch";
            LoadInitialFile(SchFilter, SchOpenFileDialog, LoadSchTextBox, _rastrSupplier, shablon);
        }

        private void LoadDfwButton_Click(object sender, EventArgs e)
        {
            string DfwFilter = "Файл автоматики (*.dfw)|*.dfw";
            string shablon = @"../../Resources/автоматика.dfw";
            LoadInitialFile(DfwFilter, DfwOpenFileDialog, LoadDfwTextBox, _rastrSupplier, shablon);
        }

        private void LoadTrajectoryButton_Click(object sender, EventArgs e)
        {
            string Ut2Filter = "Файл траектории (*.ut2)|*.ut2";
            string shablon = @"../../Resources/траектория утяжеления.ut2";
            LoadInitialFile(Ut2Filter, Ut2OpenFileDialog, LoadTrajectoryTextBox, _rastrSupplier, shablon);
        }

        private void LoadScnButton_Click(object sender, EventArgs e)
        {
            LoadScnListBox.Items.Clear();
            ScnOpenFileDialog.Multiselect = true;
            ScnOpenFileDialog.Filter = "Файл сценария (*.scn)|*.scn";
            string shablon = @"../../Resources/сценарий.scn";
            
            if (ScnOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadScnListBox.Items.AddRange(ScnOpenFileDialog.FileNames);
                    foreach (string fileName in ScnOpenFileDialog.FileNames)
                    {
                        _rastrSupplier.LoadFile(fileName, shablon);
                    }
                }
                catch (Exception exeption)
                {
                    LoadScnListBox.Items.Clear();
                    MessageBox.Show("Ошибка! Вы загрузили файл неверного формата.\nПопробуйте ещё раз.\n" + exeption.Message);
                }
            }

        }
    }
}
