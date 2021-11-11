using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RustabBot_v1._0
{
    public partial class TrajectorySettingsForm : Form
    {
        public List<int> numbersOfSectionsFromRastrCopy;

        public List<int> numbersOfNodesFromRastrCopy;

        public TrajectorySettingsForm(List<int> numbersOfSectionsFromRastr, List<int> numbersOfNodesFromRastr)
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
        }
    }
}
