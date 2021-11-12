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

namespace RustabBot_v1._0
{
    public partial class TrajectorySettingsForm : Form
    {
        public List<int> numbersOfSectionsFromRastrCopy;

        public List<int> numbersOfNodesFromRastrCopy;

        public RadioButton FromFileRadioButtonCopy;

        public RadioButton ByHandRadioButtonCopy;

        public TrajectorySettingsForm(List<int> numbersOfSectionsFromRastr, List<int> numbersOfNodesFromRastr, 
            RadioButton FromFileRadioButton, RadioButton ByHandRadioButton)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            ResearchingSchLabel.Visible = false;
            ResearchingSchComboBox.Visible = false;
            SchInfluentFactorLabel.Visible = false;
            SchInfluentFactorComboBox.Visible = false;
            ChooseGenOfResearchingSection.Visible = false;
            ChooseGenOfInfluentSection.Visible = false;

            numbersOfSectionsFromRastrCopy = numbersOfSectionsFromRastr;
            numbersOfNodesFromRastrCopy = numbersOfNodesFromRastr;
            FromFileRadioButtonCopy = FromFileRadioButton;
            ByHandRadioButtonCopy = ByHandRadioButton;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GeneratorTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(GeneratorTypeComboBox.SelectedIndex)
            {
                case 0:
                    {
                        ResearchingSchLabel.Visible = true;
                        ResearchingSchComboBox.Visible = true;
                        SchInfluentFactorLabel.Visible = false;
                        SchInfluentFactorComboBox.Visible = false;
                        ChooseGenOfResearchingSection.Visible = true;
                        ChooseGenOfInfluentSection.Visible = false;
                        break;
                    }
                case 1:
                    {
                        ResearchingSchLabel.Visible = false;
                        ResearchingSchComboBox.Visible = false;
                        SchInfluentFactorLabel.Visible = true;
                        SchInfluentFactorComboBox.Visible = true;
                        ChooseGenOfResearchingSection.Visible = false;
                        ChooseGenOfInfluentSection.Visible = true;
                        break;
                    }
            }
        }

        private void TrajectorySettingsForm_Load(object sender, EventArgs e)
        {
            DataGridViewTools.CreateTableForTrajectory(ChosenGeneratorsForTrajectoryData);

            SchInfluentFactorComboBox.DataSource = numbersOfSectionsFromRastrCopy;
            ResearchingSchComboBox.DataSource = numbersOfSectionsFromRastrCopy;

            GeneratorsFromFileListBox.SelectionMode = SelectionMode.MultiSimple;
            foreach (var number in numbersOfNodesFromRastrCopy)
            {
                GeneratorsFromFileListBox.Items.Add(number);
            }

            if (FromFileRadioButtonCopy.Checked == true)
            {
                RastrSupplier.LoadUt2ToDataGrid((DataTable)ChosenGeneratorsForTrajectoryData.DataSource);
            }
        }

        private void SchInfluentFactorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SchInfluentFactorComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SchInfluentFactorComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ResearchingSchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResearchingSchComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ResearchingSchComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ChosenGeneratorsForTrajectoryData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if(e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show(e.Exception.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakeTrajectoryByHandButton_Click(object sender, EventArgs e)
        {
            if (ByHandRadioButtonCopy.Checked == true) 
            {
                RastrSupplier.SaveToUt2FromDataGrid((DataTable)ChosenGeneratorsForTrajectoryData.DataSource);

                string shablon = @"../../Resources/траектория утяжеления.ut2";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "ut2";
                saveFileDialog.Filter = "Файл траектории (*.ut2)|*.ut2";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog.FileName;
                    RastrSupplier.SaveFile(filename, shablon);
                }
                MessageBox.Show($"Файл с траекторией утяжеления сохранен в {saveFileDialog.FileName}."); 
            }
        }

        private void ClearDataGridButton_Click(object sender, EventArgs e)
        {
            while (ChosenGeneratorsForTrajectoryData.Rows.Count > 1)
            {
                for (int i = 0; i < ChosenGeneratorsForTrajectoryData.Rows.Count - 1; i++)
                {
                    ChosenGeneratorsForTrajectoryData.Rows.Remove(ChosenGeneratorsForTrajectoryData.Rows[i]);
                }
            }
        }
    }
}
