﻿using System;
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
        /// Путь к файлу исходного режима
        /// </summary>
        private string _rstFileName;

        /// <summary>
        /// Главная форма
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FromFileRadioButton.Checked = true;
            ByHandRadioButton.Checked = false;
            LoadTrajectoryTextBox.Visible = true;
            LoadTrajectoryButton.Visible = true;
            InfoAboutTrajectoryLabel.Visible = false;
            InfoAboutTrajectoryLabel2.Visible = false;


            //Вторая вкладка "Расчёт"

            _textBoxValidationActionForMinMax = new Dictionary<TextBox, Action<InfluentFactorBase, double>>
            {
                {
                    InfluentFactorMinTextBox,
                    (factor, value) =>
                    {
                        if (factor is SectionFactor sectionFactor)
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
                        if (factor is SectionFactor sectionFactor)
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
                        if (factor is SectionFactor sectionFactor)
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
            var tmpRastrData = new RastrData(numbersOfNodesFromRastr,
                numbersOfSectionsFromRastr,
                researchingPlantGenerators);

            using (TrajectorySettingsForm trajectorySettings = new TrajectorySettingsForm(tmpRastrData, GetFromRadioButtons(), 
                dataTable, _factorList, ResearchingSectionNumber, _rstFileName))
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
            TextBox textbox, string shablon)
        {
            openFileDialog.Filter = openFileDialogFilter;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textbox.Text = openFileDialog.FileName;
                    RastrSupplier.LoadFile(openFileDialog.FileName, shablon);
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
            string RstFilter = "Файл динамики (*.rst)|*.rst";
            string shablon = @"../../Resources/динамика.rst";
            if(File.Exists(shablon))
            {
                LoadInitialFile(RstFilter, RstOpenFileDialog, LoadRstTextBox, shablon);
                _rstFileName = LoadRstTextBox.Text;
                numbersOfNodesFromRastr = RastrSupplier.FillListOfNumbersFromRastr("node", "ny");
            }
            else
            {
                MessageBox.Show("Вам необходимо добавить шаблон 'динамика.rst' в папку Resources!");
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
            LoadInitialFile(SchFilter, SchOpenFileDialog, LoadSchTextBox, shablon);
            numbersOfSectionsFromRastr = RastrSupplier.FillListOfNumbersFromRastr("sechen", "ns");
        }

        /// <summary>
        /// Загрузка файла автоматики
        /// И заполнение списка с узлами
        /// </summary>
        private void LoadDfwButton_Click(object sender, EventArgs e)
        {
            string DfwFilter = "Файл автоматики (*.dfw)|*.dfw";
            string shablon = @"../../Resources/автоматика.dfw";
            LoadInitialFile(DfwFilter, DfwOpenFileDialog, LoadDfwTextBox, shablon);
        }

        /// <summary>
        /// Загрузка файла траектории утяжеления
        /// </summary>
        private void LoadTrajectoryButton_Click(object sender, EventArgs e)
        {
            string Ut2Filter = "Файл траектории (*.ut2)|*.ut2";
            string shablon = @"../../Resources/траектория утяжеления.ut2";
            LoadInitialFile(Ut2Filter, Ut2OpenFileDialog, LoadTrajectoryTextBox, shablon);
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
                        RastrSupplier.LoadFile(fileName, shablon);
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
            RastrSupplier.Message += MessageHandler;
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
                InfluentFactorMinTextBox.Clear();
                InfluentFactorMaxTextbox.Clear();
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
        private async void StartCalcButton_Click(object sender, EventArgs e)
        {
            string shablon = @"../../Resources/динамика.rst";

            RastrSupplier.LoadFile(_rstFileName, shablon);

            InfluentFactorsDataGridView.Refresh();

            var startCalc = DateTime.Now;

            this.Invoke((Action)delegate
            {
                ProtocolListBox.Items.Add($"Время начала расчёта: " + startCalc.ToLongTimeString());
            });

            if (_factorList.Count == 0)
            {
                MessageBox.Show("Вы не добавили в таблицу ни одного влияющего фактора!"
                    +"\n Расчёт остановлен.");
                return;
            }
            else
            {
                await Task.Run(() =>
                {
                    RastrSupplier.PrimaryCheckForReactionOfSection(_factorList, researchingPlantGenerators, _rstFileName);
                });
            }

            ProtocolListBox.Items.Add("Расчёт установившегося режима...");
            RastrSupplier.Regime(); //первичный расчёт режима

            foreach(var factor in _factorList)
            {
                if(!InfluentFactorBase.IsInDiapasone(factor))
                {
                    this.Invoke((Action)delegate
                    {
                        ProtocolListBox.Items.Add("Расчёт остановлен. Проверьте исходные данные!");
                        ProtocolListBox.Items.Add("В исходном режиме влияющие факторы должны " +
                            "находиться в заданном диапазоне значений.");
                        InfluentFactorsDataGridView.Refresh();
                    });
                    return;
                }
            }

            int maxIteration = 100;
            int iteration = 0;

            try
            {
                await Task.Run(() =>
                {
                    RastrSupplier.Worsening(_factorList, maxIteration,
                    researchingPlantGenerators, iteration, ResearchingSectionNumber, _rstFileName);
                });
                
            }
            catch(Exception exeption)
            {
                MessageBox.Show($"{exeption.Message}");
                this.Invoke((Action)delegate
                {
                    ProtocolListBox.Items.Add("Расчёт остановлен " +
                    "в результате ошибки. Проверьте исходные данные!");
                });
                return;
            }

            this.Invoke((Action)delegate
            {
                InfluentFactorsDataGridView.Refresh();

                ProtocolListBox.Items.Add($"Vzad = {RastrSupplier.GetValue("node", "ny", 60533008, "vzd")}" +
                    $" Vfactor = {RastrSupplier.GetValue("node", "ny", 60533027, "vras")}, " +
                    $"Psech={RastrSupplier.GetValue("sechen", "ns", 60014, "psech")}");

                ProtocolListBox.Items.Add($"Рген = {RastrSupplier.GetValue("Generator", "Node", 60533008, "P")}");

                ProtocolListBox.Items.Add($"ТАЗ = {RastrSupplier.GetValue("sechen", "ns", 60015, "psech")}");
            });

            var endCalc = DateTime.Now;

            TimeSpan calcTime = endCalc - startCalc;

            this.Invoke((Action)delegate
            {
                //TODO: а точно ли нужны секунды?
                ProtocolListBox.Items.Add($"Время окончания расчёта: " + endCalc.ToLongTimeString());
                ProtocolListBox.Items.Add($"Суммарное время расчёта: " + Math.Round(calcTime.TotalSeconds, 2) + " секунд.");
            });

            RastrSupplier.LoadFile(_rstFileName, shablon);
        }

        private void MessageHandler(object sender, EventProvider e)
        {
            this.Invoke((Action)delegate
            {
                ProtocolListBox.Items.Add(e.Message);
            });
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
