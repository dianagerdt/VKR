using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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
    /// Класс MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Экземпляр класса RastrSupplier для операций 
        /// над данными из таблиц RastrWin
        /// Здесь происходит вся магия
        /// </summary>
        private RastrSupplier _rastrSupplier = new RastrSupplier();

        /// <summary>
        /// Поле для создания фактора
        /// </summary>
        private InfluentFactorBase _factor;

        /// <summary>
		/// Cписок факторов
		/// </summary>
		private BindingList<InfluentFactorBase> _factorList =
            new BindingList<InfluentFactorBase>();

        /// <summary>
		/// Спискок, хранящий номера узлов из файла rst 
		/// </summary>
        private List<int> numbersOfNodesFromRastr = new List<int>();

        /// <summary>
		/// Спискок, хранящий номера сечений из файла sch
		/// </summary>
        private List<int> numbersOfSectionsFromRastr = new List<int>();

        /// <summary>
        /// Словарь для сопоставления TextBox и Action для свойств double
        /// </summary>
        private readonly Dictionary<TextBox,
            Action<InfluentFactorBase, double>> _textBoxValidationActionForMinMax;

        /// <summary>
        /// Словарь для сопоставления TextBox и Action для свойств int
        /// </summary>
        private readonly Dictionary<ComboBox,
            Action<InfluentFactorBase, int>> _textBoxValidationActionForNumber;

        /// <summary>
        /// Таблица, в которой хранится траектория утяжеления
        /// </summary>
        private DataTable dataTable = new DataTable();

        /// <summary>
        /// Генераторы исследуемой станции.
        /// С их помощью будет осуществляться регулирование 
        /// напряжения-влияющего фактора
        /// Список формируется в форме TrajectorySettingsForm
        /// </summary>
        private List<int> researchingPlantGenerators = new List<int>();

        /// <summary>
        /// Номер исследуемого сечения
        /// Назначается в форме TrajectorySettingsForm 
        /// </summary>
        public int ResearchingSectionNumber;

        /// <summary>
        /// Главная форма
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FromFileRadioButton.Checked = false;
            ByHandRadioButton.Checked = true;
            LoadTrajectoryTextBox.Visible = false;
            LoadTrajectoryButton.Visible = false;
            InfoAboutTrajectoryLabel.Visible = true;
            InfoAboutTrajectoryLabel2.Visible = true;


            //Вторая вкладка "Расчёт"

            _textBoxValidationActionForMinMax = new Dictionary<TextBox, Action<InfluentFactorBase, double>>
            {
                {
                    InfluentFactorMinTextBox,
                    (factor, value) =>
                    {
                        if (factor is LoadFactor loadFactor)
                        {
                            loadFactor.MinValue = value;
                        }
                        else if (factor is SectionFactor sectionFactor)
                        {
                            sectionFactor.MinValue = value;
                        }
                        else if (factor is VoltageFactor voltageFactor)
                        {
                            voltageFactor.MinValue = value;
                        }
                    }
                },
                {
                    InfluentFactorMaxTextbox,
                    (factor, value) =>
                    {
                        if (factor is LoadFactor loadFactor)
                        {
                            loadFactor.MaxValue = value;
                        }
                        else if (factor is SectionFactor sectionFactor)
                        {
                            sectionFactor.MaxValue = value;
                        }
                        else if (factor is VoltageFactor voltageFactor)
                        {
                            voltageFactor.MaxValue = value;
                        }
                    }
                }
            };

            _textBoxValidationActionForNumber = new Dictionary<ComboBox, Action<InfluentFactorBase, int>>
            {
                {
                    InfluentFactorNumCombobox,
                    (factor, value) =>
                    {
                        if (factor is LoadFactor loadFactor)
                        {
                            loadFactor.NumberFromRastr = value;
                        }
                        else if (factor is SectionFactor sectionFactor)
                        {
                            sectionFactor.NumberFromRastr = value;
                        }
                        else if (factor is VoltageFactor voltageFactor)
                        {
                            voltageFactor.NumberFromRastr = value;
                        }
                    }
                },
            };
        }

        /// <summary>
        /// Событие при нажатии кнопки 
        /// задать траекторию "вручную"
        /// </summary>
        private void ByHandRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            FromFileRadioButton.Checked = false;
            ByHandRadioButton.Checked = true;
            LoadTrajectoryTextBox.Visible = false;
            LoadTrajectoryButton.Visible = false;
            InfoAboutTrajectoryLabel.Visible = true;
            InfoAboutTrajectoryLabel2.Visible = true;
        }

        /// <summary>
        /// Событие при нажатии кнопки 
        /// задать траекторию "из файла"
        /// </summary>
        private void FromFileRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            FromFileRadioButton.Checked = true;
            ByHandRadioButton.Checked = false;
            LoadTrajectoryTextBox.Visible = true;
            LoadTrajectoryButton.Visible = true;
            InfoAboutTrajectoryLabel.Visible = false;
            InfoAboutTrajectoryLabel2.Visible = false;
        }

        /// <summary>
        /// Событие при нажатии на кнопку "Настройка траектории"
        /// передаёт в форму с настройками списки с узлами и генераторами,
        /// радиокнопки и объект класса RastrSupplier
        /// </summary>
        private void TrajectorySettingsButton_Click(object sender, EventArgs e)
        {
            using (TrajectorySettingsForm trajectorySettings = new TrajectorySettingsForm(numbersOfSectionsFromRastr,
                numbersOfNodesFromRastr, GetFromRadioButtons(), _rastrSupplier,
                dataTable, _factorList, researchingPlantGenerators, ResearchingSectionNumber))
            {
                trajectorySettings.ShowDialog();
                ResearchingSectionNumber = trajectorySettings.ResearchingSectionNumberCopy;
                
            }
        }

        private TrajectoryWeightnessLoadingType GetFromRadioButtons()
        {
            return ByHandRadioButton.Checked
                ? TrajectoryWeightnessLoadingType.EnteredManually
                : TrajectoryWeightnessLoadingType.LoadedFromFile;
        }

        /// <summary>
        /// Событие при нажатии на кнопку "Подключение к БД"
        /// </summary>
        private void DBConnectionButton_Click(object sender, EventArgs e)
        {
            var dbconnection = new DBConnectionForm();
            dbconnection.Show();
        }

        /// <summary>
        ///  Открытие диалогового окна, выбор и загрузка файла 
        ///  и запись его пути в Текстбокс
        /// </summary>
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

        /// <summary>
        /// Загрузка файла динамики
        /// И заполнение списка с узлами
        /// </summary>
        private void LoadRstButton_Click(object sender, EventArgs e)
        {
            string RstFilter = "Файл динамики (*.rg2)|*.rg2";
            string shablon = @"../../Resources/режим.rg2";
            if(File.Exists(shablon))
            {
                LoadInitialFile(RstFilter, RstOpenFileDialog, LoadRstTextBox, _rastrSupplier, shablon);
                numbersOfNodesFromRastr.Clear();
                RastrSupplier.FillListOfNumbersFromRastr(numbersOfNodesFromRastr, "node", "ny");
            }
            else
            {
                MessageBox.Show("Вам необходимо добавить шаблон 'режим.rg2' в папку Resources!");
            }
        }
        
        /// <summary>
        /// Загрузка файла сечения
        /// И заполнение списка с номерами сечений
        /// </summary>
        private void LoadSchButton_Click(object sender, EventArgs e)
        {
            string SchFilter = "Файл сечения (*.sch)|*.sch";
            string shablon = @"../../Resources/сечения.sch";
            LoadInitialFile(SchFilter, SchOpenFileDialog, LoadSchTextBox, _rastrSupplier, shablon);
            numbersOfSectionsFromRastr.Clear();
            RastrSupplier.FillListOfNumbersFromRastr(numbersOfSectionsFromRastr, "sechen", "ns");
        }

        /// <summary>
        /// Загрузка файла автоматики
        /// И заполнение списка с узлами
        /// </summary>
        private void LoadDfwButton_Click(object sender, EventArgs e)
        {
            string DfwFilter = "Файл автоматики (*.dfw)|*.dfw";
            string shablon = @"../../Resources/автоматика.dfw";
            LoadInitialFile(DfwFilter, DfwOpenFileDialog, LoadDfwTextBox, _rastrSupplier, shablon);
        }

        /// <summary>
        /// Загрузка файла траектории утяжеления
        /// </summary>
        private void LoadTrajectoryButton_Click(object sender, EventArgs e)
        {
            string Ut2Filter = "Файл траектории (*.ut2)|*.ut2";
            string shablon = @"../../Resources/траектория утяжеления.ut2";
            LoadInitialFile(Ut2Filter, Ut2OpenFileDialog, LoadTrajectoryTextBox, _rastrSupplier, shablon);
        }

        /// <summary>
        /// Загрузка файлов сценариев
        /// </summary>
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
                    MessageBox.Show("Ошибка! Вы загрузили файл неверного формата.\n" +
                        "Попробуйте ещё раз.\n" + exeption.Message);
                }
            }
        }

        /// <summary>
        /// Событие при загрузки MainForm
        /// Создает таблицу влияющих факторов во вкладке "Расчёт"
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataGridViewTools.CreateTableForFactors(_factorList, InfluentFactorsDataGridView);
        }

        /// <summary>
        /// Событие при выборе пользователем
        /// типа влияющего фактора 
        /// </summary>
        private void FactorTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (FactorTypeComboBox.SelectedIndex)
            {
                case 0:
                {
                    _factor = new VoltageFactor();
                    InfluentFactorNumCombobox.DataSource = numbersOfNodesFromRastr;
                    InfluentFactorNumCombobox.Text = "";
                    break;
                }
                case 1:
                {
                    _factor = new SectionFactor();
                    InfluentFactorNumCombobox.DataSource = numbersOfSectionsFromRastr;
                    InfluentFactorNumCombobox.Text = "";
                    break;
                }
                case 2:
                {
                    _factor = new LoadFactor();
                    InfluentFactorNumCombobox.DataSource = numbersOfNodesFromRastr;
                    InfluentFactorNumCombobox.Text = "";
                    break;
                }
            }
        }

        /// <summary>
        /// Установить значение свойствам экземпляра класса 
        /// </summary>
        private void SetFactorValue(Action action)
        {
            action.Invoke();
        }

        /// <summary>
        /// Ввод данных о напряжении
        /// </summary>
        /// <returns>
        /// Созданный экземпляр класса VoltageFactor
        /// </returns>
        private VoltageFactor GetNewVoltageFactor()
        {
            var newVoltageFactor = new VoltageFactor();

            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    newVoltageFactor.NumberFromRastr =
                    Convert.ToInt32(InfluentFactorNumCombobox.Text);
                }),
                new Action(() =>
                {
                    newVoltageFactor.MinValue =
                    Convert.ToDouble(InfluentFactorMinTextBox.Text);
                }),
                new Action(() =>
                {
                    newVoltageFactor.MaxValue =
                    Convert.ToDouble(InfluentFactorMaxTextbox.Text);
                }),
                new Action(() =>
                {
                    newVoltageFactor.CurrentValue =
                    RastrSupplier.GetValue("node", "ny", 
                    Convert.ToInt32(InfluentFactorNumCombobox.Text), "vras");
                })
            };
            actions.ForEach(SetFactorValue);
            return newVoltageFactor;
        }

        /// <summary>
        /// Ввод данных о перетоке во влияющем сечении
        /// </summary>
        /// <returns>
        /// Созданный экземпляр класса SectionFactor
        /// </returns>
        private SectionFactor GetNewSectionFactor()
        {
            var newSectionFactor = new SectionFactor();

            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    newSectionFactor.NumberFromRastr =
                    Convert.ToInt32(InfluentFactorNumCombobox.Text);
                }),
                new Action(() =>
                {
                    newSectionFactor.MinValue =
                    Convert.ToDouble(InfluentFactorMinTextBox.Text);
                }),
                new Action(() =>
                {
                    newSectionFactor.MaxValue =
                    Convert.ToDouble(InfluentFactorMaxTextbox.Text);
                }),
                new Action(() =>
                {
                    newSectionFactor.CurrentValue =
                    RastrSupplier.GetValue("sechen", "ns", 
                    Convert.ToInt32(InfluentFactorNumCombobox.Text), "psech");
                })
            };
            actions.ForEach(SetFactorValue);
            return newSectionFactor;
        }

        /// <summary>
        /// Ввод данных о нагрузке
        /// </summary>
        /// <returns>Созданный экземпляр класса LoadFactor</returns>
        private LoadFactor GetNewLoadFactor()
        {
            var newLoadFactor = new LoadFactor();

            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    newLoadFactor.NumberFromRastr =
                    Convert.ToInt32(InfluentFactorNumCombobox.Text);
                }),
                new Action(() =>
                {
                    newLoadFactor.MinValue =
                    Convert.ToDouble(InfluentFactorMinTextBox.Text);
                }),
                new Action(() =>
                {
                    newLoadFactor.MaxValue =
                    Convert.ToDouble(InfluentFactorMaxTextbox.Text);
                }),
                new Action(() =>
                {
                    newLoadFactor.CurrentValue =
                    RastrSupplier.GetValue("node", "ny", 
                    Convert.ToInt32(InfluentFactorNumCombobox.Text), "pn");
                })
            };
            actions.ForEach(SetFactorValue);
            return newLoadFactor;
        }

        /// <summary>
        /// Ввод данных о факторах
        /// </summary>
        private void InsertData()
        {
            switch (_factor)
            {
                case VoltageFactor _:
                {
                    _factor = GetNewVoltageFactor();
                    break;
                }
                case SectionFactor _:
                {
                    _factor = GetNewSectionFactor();
                    break;
                }
                case LoadFactor _:
                {
                    _factor = GetNewLoadFactor();
                    break;
                }
                default:
                {
                    throw new ArgumentException("Такого фактора нет.");
                }
            }
        }

        /// <summary>
        /// Добавить влияющий фактор в dataGridView
        /// </summary>
        private void AddFactorToGridButton_Click(object sender, EventArgs e)
        {
            try
            {
                InsertData();
                InfluentFactorBase.IsMinMaxCorrect(_factor.MinValue, _factor.MaxValue);

                for (int i = 0; i < InfluentFactorsDataGridView.Rows.Count; i++)
                {
                    if(_factor.NumberFromRastr == 
                        Convert.ToDouble(InfluentFactorsDataGridView[1, i].Value))
                    {
                        throw new Exception("Этот влияющий фактор уже добавлен" +
                            " в список! Попробуйте ещё раз.");
                    }
                }
                _factorList.Add(_factor);
            }
            catch
            {
                MessageBox.Show("Вы не загрузили исходные файлы или" +
                    " введено некорректное значение!\n" +
                    "Пожалуйста, проверьте исходные данные.",
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                InfluentFactorNumCombobox.Text = "";
                InfluentFactorMinTextBox.Clear();
                InfluentFactorMaxTextbox.Clear();
            }
        }

        /// <summary>
        /// Удалить любое количество выделенных строк в таблице
        /// с влияющими факторами
        /// </summary>
        private void RemoveFactorFromGridButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < InfluentFactorsDataGridView.SelectedRows.Count; i++)
            {
                _factorList.RemoveAt(InfluentFactorsDataGridView.SelectedRows[0].Index);
            }
        }

        /// <summary>
        /// Удалить любое количество выделенных строк в таблице
        /// с влияющими факторами
        /// </summary>
        private void ClearAllFactorsFromGridButton_Click(object sender, EventArgs e)
        {
            _factorList.Clear();
        }

        /// <summary>
        /// Очистить таблицу
        /// </summary>
        private void InfluentFactorNumCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InfluentFactorNumCombobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            InfluentFactorNumCombobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Инициирование расчёта (пока что только траектории)
        /// </summary>
        private void StartCalcButton_Click(object sender, EventArgs e)
        {
            if(_factorList.Count == 0)
            {
                MessageBox.Show("Вы не добавили в таблицу ни одного влияющего фактора!"
                    +"\n Расчёт остановлен.");
                return;
            }
            
            _rastrSupplier.Regime(); //первичный расчёт режима

            ProtocolListBox.Items.Add("Расчёт установившегося режима...");

            foreach(var factor in _factorList)
            {
                if(!InfluentFactorBase.IsInDiapasone(factor))
                {
                    ProtocolListBox.Items.Add("Расчёт остановлен. Проверьте исходные данные!");
                    ProtocolListBox.Items.Add("В исходном режиме влияющие факторы должны " +
                        "находиться в заданном диапазоне значений."); 
                    return;
                }
            }

            int maxIteration = 100;
            int iteration = 0;

            try
            {
                RastrSupplier.Worsening(_factorList, maxIteration,
                    researchingPlantGenerators, _rastrSupplier,
                    ProtocolListBox, InfluentFactorsDataGridView, 
                    iteration, ResearchingSectionNumber);
            }
            catch(Exception exeption)
            {
                MessageBox.Show($"{exeption.Message}");
                ProtocolListBox.Items.Add("Расчёт остановлен " +
                    "в результате ошибки. Проверьте исходные данные!");
                return;
            }

            InfluentFactorsDataGridView.Refresh();

            ProtocolListBox.Items.Add($"Vzad = {RastrSupplier.GetValue("node", "ny", 60533008, "vzd")}" +
                $" Vfactor = {RastrSupplier.GetValue("node", "ny", 60533027, "vras")}, " +
                $"Psech={RastrSupplier.GetValue("sechen", "ns", 60014, "psech")}");

            ProtocolListBox.Items.Add($"Рген = {RastrSupplier.GetValue("Generator", "Node", 60533008, "P")}");


        }

        /// <summary>
        /// Очистить протокол
        /// </summary>
        private void ClearProtocol_Click(object sender, EventArgs e)
        {
            ProtocolListBox.Items.Clear();
        }
    }
}
