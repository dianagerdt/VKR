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
        public TrajectorySettingsForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            ResearchingSchLabel.Visible = false;
            ResearchingSchComboBox.Visible = false;
            SchInfluentFactorLabel.Visible = false;
            SchInfluentFactorComboBox.Visible = false;
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
                        break;
                    }
                case 1:
                    {
                        ResearchingSchLabel.Visible = false;
                        ResearchingSchComboBox.Visible = false;
                        SchInfluentFactorLabel.Visible = true;
                        SchInfluentFactorComboBox.Visible = true;
                        break;
                    }
            }
        }

        private void TrajectorySettingsForm_Load(object sender, EventArgs e)
        {
            DataGridViewTools.CreateTableForTrajectory(ChosenGeneratorsForTrajectoryData);
        }
    }
}
