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
using Model.InfluentFactors;

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
        /// Таблица, в которой хранится траектория утяжеления
        /// </summary>
        private DataTable dataTableCopy;

        /// <summary>
        /// Cписок с влияющими факторами
        /// </summary>
        private BindingList<InfluentFactorBase> _factorListCopy;

        /// <summary>
        /// Cписок с генераторами исследуемого сечения
        /// </summary>
        private List<int> researchingPlantGeneratorsCopy;

        /// <summary>
        /// Номер исследуемого сечения
        /// </summary>
        public int ResearchingSectionNumberCopy { get; set; }

        /// <summary>
        /// Состояние Radio Buttons на главной форме: вручную
        /// или из файла задаётся траектория утяжеления
        /// </summary>
        private TrajectoryWeightnessLoadingType _trajectoryWeightnessLoadingType;

        string rg2FileNameCopy;
        

        /// <summary>
        /// Форма с настройками траектории утяжеления
        /// </summary>
        public TrajectorySettingsForm(RastrData rastrData, 
            TrajectoryWeightnessLoadingType trajectoryWeightnessLoadingType, RastrSupplier _rastrSupplier,
            DataTable dataTable, BindingList<InfluentFactorBase> _factorList, 
            int ResearchingSectionNumber, string rg2FileName)
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

            var tmpRastrData = (RastrData)rastrData.Clone();

            numbersOfSectionsFromRastrCopy = tmpRastrData.NumbersOfSectionsFromRastr;
            numbersOfNodesFromRastrCopy = numbersOfNodesFromRastr;
            _trajectoryWeightnessLoadingType = trajectoryWeightnessLoadingType;
            dataTableCopy = dataTable;
            _factorListCopy = _factorList;
            researchingPlantGeneratorsCopy = researchingPlantGenerators;
            ResearchingSectionNumberCopy = ResearchingSectionNumber;
            rg2FileNameCopy = rg2FileName;
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
                    GeneratorsFromFileListBox.ClearSelected();
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
                    GeneratorsFromFileListBox.ClearSelected();
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
            dataTableCopy = (DataTable)ChosenGeneratorsForTrajectoryData.DataSource;

            SchInfluentFactorComboBox.DataSource = numbersOfSectionsFromRastrCopy;
            ResearchingSchComboBox.DataSource = numbersOfSectionsFromRastrCopy;

            GeneratorsFromFileListBox.SelectionMode = SelectionMode.MultiSimple;
            foreach (var number in numbersOfNodesFromRastrCopy)
            {
                GeneratorsFromFileListBox.Items.Add(number);
            }

            if (_trajectoryWeightnessLoadingType == TrajectoryWeightnessLoadingType.LoadedFromFile)
            {
                try
                {
                    RastrSupplier.LoadUt2ToDataGrid(dataTableCopy);
                    ChosenGeneratorsForTrajectoryData.ReadOnly = true;
                    AddGensToTrajectory.Enabled = false;
                    ClearDataGridButton.Enabled = false;
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
            if (_trajectoryWeightnessLoadingType == TrajectoryWeightnessLoadingType.EnteredManually
                == true && dataTableCopy.Rows.Count != 0) 
            {
                RastrSupplier.SaveToUt2FromDataGrid(dataTableCopy); //взяли траекторию из таблицы

                RastrSupplier.PrimaryCheckForReactionOfSection(_factorListCopy, researchingPlantGeneratorsCopy, rg2FileNameCopy);

                string shablon = @"../../Resources/траектория утяжеления.ut2";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "ut2";
                saveFileDialog.Filter = "Файл траектории (*.ut2)|*.ut2";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog.FileName;
                    RastrSupplier.SaveFile(filename, shablon);
                    MessageBox.Show($"Файл с траекторией утяжеления сохранен в {saveFileDialog.FileName}.");
                    DialogResult = DialogResult.OK;
                    RastrSupplier.LoadFile(saveFileDialog.FileName, shablon);
                    Close();
                }
            }
            else if(dataTableCopy.Rows.Count == 0)
            {
                MessageBox.Show("Вы не добавили ни одного генератора в траекторию утяжеления! " +
                    "\nДобавьте генераторы в таблицу и укажите их приращения." +
                    "\nЕсли вы хотите задать траекторию из файла, нажмите 'Отмена' и загрузите файл из" +
                    " главного меню. ",
                    "Ошибка!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(_trajectoryWeightnessLoadingType == TrajectoryWeightnessLoadingType.LoadedFromFile) 
            {
                RastrSupplier.PrimaryCheckForReactionOfSection(_factorListCopy, researchingPlantGeneratorsCopy, rg2FileNameCopy);
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

        /// <summary>
        /// Поиск в ListBox по номеру узла
        /// </summary>
        private void TrajectoryGeneratorsSearchButton_Click(object sender, EventArgs e)
        {
            GeneratorsFromFileListBox.SelectedIndex = 
                GeneratorsFromFileListBox.FindString(TrajectoryGeneratorsSearchTextBox.Text);
        }

        /// <summary>
        /// Снимает выделение с выбранных генераторов
        /// </summary>
        private void DropSettings_Click(object sender, EventArgs e)
        {
            GeneratorsFromFileListBox.ClearSelected();
            researchingPlantGeneratorsCopy.Clear();
            if(_factorListCopy.Count != 0)
            {
                foreach (var factor in _factorListCopy)
                {
                    if(factor is SectionFactor)
                    {
                        ((SectionFactor)factor).RegulatingGeneratorsList.Clear();
                    }
                }
            }
            MessageBox.Show("Настройки сброшены.\n" +
                "Укажите исследуемое и влияющие сечения (при наличии) " +
                "и укажите их генераторы!");
        }

        /// <summary>
        /// Добавляет генераторные узлы в траекторию
        /// </summary>
        private void AddGensToTrajectory_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in GeneratorsFromFileListBox.SelectedItems)
                {
                    dataTableCopy.Rows.Add();
                    dataTableCopy.Rows[dataTableCopy.Rows.Count - 1]
                        ["ny"] = Convert.ToInt32(item);
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Ошибка! " + exeption.Message, 
                    "",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Фиксирует номер исследуемого сечения
        /// Фиксирует список генераторов исследуемого сечения
        /// </summary>
        private void ChooseGenOfResearchingSection_Click(object sender, EventArgs e)
        {
            if(GeneratorsFromFileListBox.SelectedItems.Count != 0)
            {
                foreach (int item in GeneratorsFromFileListBox.SelectedItems)
                {
                    researchingPlantGeneratorsCopy.Add(item);
                }
                ResearchingSectionNumberCopy = Convert.ToInt32(ResearchingSchComboBox.Text);
                MessageBox.Show($"Выбрано исследуемое сечение - {ResearchingSectionNumberCopy} и генераторы исследуемой станции." +
                    $"\nЕсли вы хотите сбросить настройки и ввести параметры заново, нажмите на кнопку 'Сбросить'. " );
            }
            else if (GeneratorsFromFileListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите номер исследуемого сечения и номера генераторов исследуемой станции! " ,
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Событие для формирования списков с генераторами, поддерживающими
        /// переток в каждом из сечений-факторов.
        /// Обязательное условие - соответствие номера сечения таблице во вкладке "Расчёт"
        /// </summary>
        private void ChooseGenOfInfluentSection_Click(object sender, EventArgs e)
        {
            if (GeneratorsFromFileListBox.SelectedItems.Count != 0)
            {
                int counterOfSections = 0;
                foreach (var factor in _factorListCopy)
                {
                    if (factor is SectionFactor)
                    {
                        if (factor.NumberFromRastr == Convert.ToInt32(SchInfluentFactorComboBox.Text))
                        {
                            foreach (int item in GeneratorsFromFileListBox.SelectedItems)
                            {
                                ((SectionFactor)factor).RegulatingGeneratorsList.Add(item);
                                counterOfSections++;
                            }

                            MessageBox.Show($"Выбрано влияющее сечение - {factor.NumberFromRastr} и генераторы влияющей станции." +
                                $"\nЕсли вы хотите сбросить настройки и ввести параметры заново, нажмите на кнопку 'Сбросить'. ");
                        }
                    }
                }
                if (counterOfSections == 0)
                {
                    MessageBox.Show("Не найдено влияющего фактора, соответствующего выбранному влияющему сечению!" +
                        "\nПроверьте, добавили ли вы Сечение-влияющий фактор во вкладке 'Расчёт' основного меню.");
                }
                GeneratorsFromFileListBox.SelectedItems.Clear();
            }
            else if (GeneratorsFromFileListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите номер влияющего сечения и номера генераторов влияющей станции! ",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
