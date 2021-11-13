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
    /// <summary>
    /// Класс с настройками траектории утяжеления
    /// </summary>
    public partial class TrajectorySettingsForm : Form
    {
        /// <summary>
        /// Список с сечениями из файла sch
        /// </summary>
        private List<int> numbersOfSectionsFromRastrCopy;

        /// <summary>
        /// Список с узлами из файла rst
        /// </summary>
        private List<int> numbersOfNodesFromRastrCopy;

        /// <summary>
        /// RadioButton "из файла" MainForm
        /// </summary>
        private RadioButton FromFileRadioButtonCopy;

        /// <summary>
        /// RadioButton "вручную" MainForm
        /// </summary>
        private RadioButton ByHandRadioButtonCopy;

        /// <summary>
        /// Экземпляр класса RastrSupplier для операций 
        /// над данными из таблиц RastrWin
        /// </summary>
        private RastrSupplier _rastrSupplierCopy;

        /// <summary>
        /// Форма с настройками траектории утяжеления
        /// </summary>
        public TrajectorySettingsForm(List<int> numbersOfSectionsFromRastr, List<int> numbersOfNodesFromRastr, 
            RadioButton FromFileRadioButton, RadioButton ByHandRadioButton, RastrSupplier _rastrSupplier)
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
            _rastrSupplierCopy = _rastrSupplier;
        }

        /// <summary>
        /// Событие при выборе типа генераторов
        /// </summary>
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

        /// <summary>
        /// Событие при загрузке формы
        /// Создается таблица по заготовленой схеме
        /// Если траектория была ранее загружена из файла, она 
        /// отобразиться в dataGridView
        /// </summary>
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
                try
                {
                    RastrSupplier.LoadUt2ToDataGrid((DataTable)ChosenGeneratorsForTrajectoryData.DataSource);
                    ChosenGeneratorsForTrajectoryData.ReadOnly = true;
                    ChooseGeneratorForTrajectoryButton.Visible = false;
                    RemoveGeneratorFromTrajectoryButton.Visible = false;
                }
                catch 
                {
                    MessageBox.Show("Прежде чем приступить к настройке траектории, " +
                        "загрузите файл формата *.ut2 или выберите опцию задания вручную.", 
                        "Загрузите файл траектории!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        /// <summary>
        /// Событие при нажатии на Combobox с выбором сечения - фактора
        /// </summary>
        private void SchInfluentFactorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SchInfluentFactorComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SchInfluentFactorComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Событие при нажатии на Combobox с выбором исследуемого сечения
        /// </summary>
        private void ResearchingSchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResearchingSchComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ResearchingSchComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Обработчик исключения для DataGridView
        /// </summary>
        private void ChosenGeneratorsForTrajectoryData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if(e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show(e.Exception.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Событие при нажатии на кнопку "ОК"
        /// Если выбрана опция "сформировать траекторию вручную",
        /// система инициализирует сохранение в желаемую директорию
        /// и подгрузит этот файл в экземпляр класса RastrSupplier для дальнейших расчётов
        /// </summary>
        private void SetTrajectorySettingsButton_Click(object sender, EventArgs e)
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
                
                DialogResult = DialogResult.OK;
                _rastrSupplierCopy.LoadFile(saveFileDialog.FileName, shablon);
                Close();
            }
            else if(FromFileRadioButtonCopy.Checked == true) 
            {
                Close();
            }
        }

        /// <summary>
        /// Полностью очистить таблицу
        /// </summary>
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

        /// <summary>
        /// Закрыть форму
        /// </summary>
        private void TrajectoryCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
