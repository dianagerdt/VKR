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
using static Model.MessageType;
using System.Threading;
using System.Xml.Serialization;


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
        /// Путь к файлу исходного файла сечений
        /// </summary>
        private string _schFileName;

        /// <summary>
        /// Путь к файлу исходного файла автоматики
        /// </summary>
        private string _dfwFileName;

        /// <summary>
        /// Путь к файлу исходного файла автоматики
        /// </summary>
        private string _ut2FileName;

        /// <summary>
        /// Путь к файлам сценариев
        /// </summary>
        private List<string> _scnFileNames = new List<string>();

        private CancellationTokenSource _tokenSource;

        /// <summary>
        /// Для файлов
        /// </summary>
        private readonly XmlSerializer _serializer =
            new XmlSerializer(typeof(BindingList<InfluentFactorBase>));

        DataTable resultsTable = new DataTable("Results");

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
                dataTable, _factorList, ResearchingSectionNumber))
            {
                trajectorySettings.ShowDialog();
                ResearchingSectionNumber = trajectorySettings.ResearchingSectionNumberCopy;
                if(ByHandRadioButton.Checked == true)
                {
                    _ut2FileName = trajectorySettings.ut2NewFileName;
                }
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
                    AddMessageToDataGrid(Info, $"Загружен файл '{openFileDialog.FileName}'.");
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
            string shablon = @"../../../Resources/динамика.rst";

            try
            {
                if (File.Exists(shablon))
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
            catch
            {

            }
        }
        
        /// <summary>
        /// Загрузка файла сечения
        /// И заполнение списка с номерами сечений
        /// </summary>
        private void LoadSchButton_Click(object sender, EventArgs e)
        {
            string SchFilter = "Файл сечения (*.sch)|*.sch";
            string shablon = @"../../../Resources/сечения.sch";

            try
            {
                if (File.Exists(shablon))
                {

                    LoadInitialFile(SchFilter, SchOpenFileDialog, LoadSchTextBox, shablon);
                    _schFileName = LoadSchTextBox.Text;
                    numbersOfSectionsFromRastr = RastrSupplier.FillListOfNumbersFromRastr("sechen", "ns");
                }
                else
                {
                    MessageBox.Show("Вам необходимо добавить шаблон 'сценарий.sch' в папку Resources!");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Загрузка файла автоматики
        /// И заполнение списка с узлами
        /// </summary>
        private void LoadDfwButton_Click(object sender, EventArgs e)
        {
            string DfwFilter = "Файл автоматики (*.dfw)|*.dfw";
            string shablon = @"../../../Resources/автоматика.dfw";

            try
            {
                if (File.Exists(shablon))
                {

                    LoadInitialFile(DfwFilter, DfwOpenFileDialog, LoadDfwTextBox, shablon);
                    _dfwFileName = LoadDfwTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Вам необходимо добавить шаблон 'автоматика.dfw' в папку Resources!");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Загрузка файла траектории утяжеления
        /// </summary>
        private void LoadTrajectoryButton_Click(object sender, EventArgs e)
        {
            string Ut2Filter = "Файл траектории (*.ut2)|*.ut2";
            string shablon = @"../../../Resources/траектория утяжеления.ut2";

            try
            {
                if (File.Exists(shablon))
                {

                    LoadInitialFile(Ut2Filter, Ut2OpenFileDialog, LoadTrajectoryTextBox, shablon);
                    _ut2FileName = LoadTrajectoryTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Вам необходимо добавить шаблон 'траектория утяжеления.ut2' в папку Resources!");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Загрузка файлов сценариев
        /// </summary>
        private void LoadScnButton_Click(object sender, EventArgs e)
        {
            LoadScnListBox.Items.Clear();
            _scnFileNames.Clear();
            ScnOpenFileDialog.Multiselect = true;
            ScnOpenFileDialog.Filter = "Файл сценария (*.scn)|*.scn";
            
            if (ScnOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadScnListBox.Items.AddRange(ScnOpenFileDialog.FileNames);

                    foreach (string fileName in ScnOpenFileDialog.FileNames)
                    {
                        _scnFileNames.Add(fileName);
                    }

                    AddMessageToDataGrid(Info, $"Загружено {_scnFileNames.Count} сценариев (scn).");
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
            DataGridViewTools.CreateTableForProtocol(ProtocolDataGrid);
            RastrSupplier.Message += MessageHandler;
            RastrSupplier.Step += ProgressHandler;

            LoadFilesFromXML();
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
        /// Инициирование расчёта 
        /// </summary>
        private async void StartCalcButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {

                this.Invoke((Action)delegate
                {
                    //ProgressBar.Enabled = true;
                    //ProgressBar.Style = ProgressBarStyle.Marquee;
                    ProgressBar.Maximum = _scnFileNames.Count();
                    ProgressBar.Value = 0;
                    SaveResultsButton.Enabled = false;
                });

                string shablon = @"../../../Resources/динамика.rst";
            
                RastrSupplier.LoadFile(LoadRstTextBox.Text, shablon);

                this.Invoke((Action)delegate
                {
                    InfluentFactorsDataGridView.Refresh();
                });

                if (_factorList.Count == 0)
                {
                    this.Invoke((Action)delegate
                    {
                        //ProgressBar.Style = ProgressBarStyle.Blocks;
                        MessageBox.Show("Вы не добавили в таблицу ни одного влияющего фактора!"
                    + "\n Расчёт остановлен.");
                    });
                    return;
                }
                else
                {
                    RastrSupplier.PrimaryCheckForReactionOfSection(_factorList, researchingPlantGenerators, _rstFileName);
                }

                if (_scnFileNames.Count == 0)
                {
                    this.Invoke((Action)delegate
                    {
                        AddMessageToDataGrid(Error, "Отсутствуют файлы сценариев!"
                        + " Расчёт остановлен.");
                        //ProgressBar.Style = ProgressBarStyle.Blocks;
                    });

                    return;
                }

                RastrSupplier.Regime(); //первичный расчёт режима
                //проверка, не разошёлся ли режим
                if (!RastrSupplier.IsRegimeOK())
                {
                    this.Invoke((Action)delegate
                    {
                        AddMessageToDataGrid(Error, "Внимание! Режим разошёлся до начала выполнения утяжеления. Проверьте исходные данные.");
                        InfluentFactorsDataGridView.Refresh();
                        //ProgressBar.Style = ProgressBarStyle.Blocks;
                    });
                    return;
                }

                if (RememberFilesPaths.Checked == true)
                {
                    XMLManager.SaveXMLFile(_rstFileName, _schFileName, _dfwFileName, _ut2FileName, _scnFileNames);
                }

                foreach (var factor in _factorList)
                {
                    if (!InfluentFactorBase.IsInDiapasone(factor))
                    {
                        this.Invoke((Action)delegate
                        {
                            AddMessageToDataGrid(Error, "Расчёт остановлен. Проверьте исходные данные!");
                            AddMessageToDataGrid(Error, "В исходном режиме влияющие факторы должны " +
                                "находиться в заданном диапазоне значений.");
                            InfluentFactorsDataGridView.Refresh();
                            //ProgressBar.Style = ProgressBarStyle.Blocks;
                        });
                        return;
                    }
                }

                var startCalc = DateTime.Now;

                resultsTable.Clear();

                this.Invoke((Action)delegate
                {
                    AddMessageToDataGrid(Info, $"Время начала расчёта: " + startCalc.ToLongTimeString());
                });

                int maxIteration = 100;
                int iteration = 0;

                //главный метод расчёта
                try
                {
                    _tokenSource = new CancellationTokenSource();
                    RastrSupplier.Worsening(_factorList, maxIteration,
                    researchingPlantGenerators, iteration, ResearchingSectionNumber, _rstFileName, _scnFileNames, 
                    _tokenSource.Token, resultsTable);
                }
                catch (OperationCanceledException exeption)
                {
                    this.Invoke((Action)delegate
                    {
                        AddMessageToDataGrid(Warning, "Расчёт остановлен пользователем. ");
                        //ProgressBar.Style = ProgressBarStyle.Blocks;
                    });
                }
                catch (Exception exeption)
                {
                    MessageBox.Show($"{exeption.Message}");
                    this.Invoke((Action)delegate
                    {
                        AddMessageToDataGrid(Error, "Расчёт остановлен " +
                        "в результате ошибки. Проверьте исходные данные!");
                        //ProgressBar.Style = ProgressBarStyle.Blocks;
                    });
                    return;
                }

                this.Invoke((Action)delegate
                {
                    InfluentFactorsDataGridView.Refresh();
                });

                var endCalc = DateTime.Now;
                TimeSpan calcTime = endCalc - startCalc;

                this.Invoke((Action)delegate
                {
                    //TODO: а точно ли нужны секунды?
                    AddMessageToDataGrid(Info, $"Время окончания расчёта: " + endCalc.ToLongTimeString());
                    AddMessageToDataGrid(Info, $"Суммарное время расчёта: " + Math.Round(calcTime.TotalSeconds, 2) + " секунд.");

                    if (resultsTable.Rows.Count == 0)
                    {
                        DataRow newRow = resultsTable.NewRow();
                        newRow["Сценарий"] = "Потери синхронизма не выявлено для всех сценариев.";
                        newRow["Шаг (Р_пред)"] = DBNull.Value;
                        newRow["Р_пред"] = DBNull.Value;
                        newRow["Шаг (Р_неустойч)"] = DBNull.Value;
                        newRow["Р_неустойч"] = DBNull.Value;
                        resultsTable.Rows.Add(newRow);
                    }
                });

                this.Invoke((Action)delegate
                {
                    //ProgressBar.Enabled = false;
                    //ProgressBar.Style = ProgressBarStyle.Blocks;
                    //ProgressBar.Value = ProgressBar.Maximum;
                    SaveResultsButton.Enabled = true;
                });

                RastrSupplier.LoadFile(_rstFileName, shablon);
            });
        }
            
        /// <summary>
        /// Обработчик сообщений
        /// </summary>
        private void MessageHandler(object sender, EventProtocolMessage e)
        {
            this.Invoke((Action)delegate
            {
                AddMessageToDataGrid(e.MessageType, e.Message);
            });
        }

        
        /// <summary>
        /// Обработчик шагов
        /// </summary>
        private void ProgressHandler(object sender, EventForProgress e)
        {
            this.Invoke((Action)delegate
            {
                StepUp(e.Step);
            });
        }

        /// <summary>
        /// Добавить сообщение в протокол
        /// </summary>
        public void StepUp(int step)
        {
            if(step == 0)
            {
                ProgressBar.Value = 0;
            }
            else
            {
                ProgressBar.Value += step;
            }
        }
        
        /// <summary>
        /// Добавить сообщение в протокол
        /// </summary>
        public void AddMessageToDataGrid(MessageType type, string message)
        {
            switch (type)
            {
                case Error:
                    {
                        Bitmap img = new Bitmap(@"../../../Resources/new_close.png");
                        ProtocolDataGrid.Rows.Add(img, message);
                        break;
                    }
                case Warning:
                    {
                        Bitmap img = new Bitmap(@"../../../Resources/warning.png");
                        ProtocolDataGrid.Rows.Add(img, message);
                        break;
                    }
                case Info:
                    {
                        Bitmap img = new Bitmap(@"../../../Resources/info.png");
                        ProtocolDataGrid.Rows.Add(img, message);
                        break;
                    }
            }

            ProtocolDataGrid.CurrentCell = null;
        }

        /// <summary>
        /// Очистить протокол
        /// </summary>
        private void ClearProtocol_Click(object sender, EventArgs e)
        {
            ProtocolDataGrid.Rows.Clear();
        }

        /// <summary>
        /// Событие, благодаря которому в протоколе нельзя выделить ни одну строку
        /// </summary>
        private void ProtocolDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            ProtocolDataGrid.ClearSelection();
        }

        private void StopCalcButton_Click(object sender, EventArgs e)
        {
            try
            {
                _tokenSource.Cancel();
            }
            catch
            {

            }
        }

        private void LoadFilesFromXML()
        {
            try
            {
                if(XMLManager.IsFileExists())
                {
                    _scnFileNames.Clear();
                    XMLManager getxml = new XMLManager(_rstFileName, _schFileName, _dfwFileName, _ut2FileName, _scnFileNames);
                    getxml.LoadFromXMLFile();
                    LoadRstTextBox.Text = getxml.RstFileName;
                    //TODO: разобраться (потом)
                    _rstFileName = getxml.RstFileName; 

                    LoadSchTextBox.Text = getxml.SchFileName;
                    _schFileName = getxml.SchFileName;

                    LoadDfwTextBox.Text = getxml.DfwFileName;
                    _dfwFileName = getxml.DfwFileName;

                    LoadTrajectoryTextBox.Text = getxml.Ut2FileName;
                    _ut2FileName = getxml.Ut2FileName;

                    foreach (string scn in getxml.ScnFiles)
                    {
                        LoadScnListBox.Items.Add(scn);
                    }

                    RastrSupplier.LoadFile(getxml.RstFileName, @"../../../Resources/динамика.rst");
                    numbersOfNodesFromRastr = RastrSupplier.FillListOfNumbersFromRastr("node", "ny");
                    AddMessageToDataGrid(Info, $"Загружен файл '{LoadRstTextBox.Text}'.");

                    RastrSupplier.LoadFile(getxml.SchFileName, @"../../../Resources/сечения.sch");
                    numbersOfSectionsFromRastr = RastrSupplier.FillListOfNumbersFromRastr("sechen", "ns");
                    AddMessageToDataGrid(Info, $"Загружен файл '{LoadSchTextBox.Text}'.");

                    RastrSupplier.LoadFile(getxml.DfwFileName, @"../../../Resources/автоматика.dfw");
                    AddMessageToDataGrid(Info, $"Загружен файл '{LoadDfwTextBox.Text}'.");
                    RastrSupplier.LoadFile(getxml.Ut2FileName, @"../../../Resources/траектория утяжеления.ut2");
                    AddMessageToDataGrid(Info, $"Загружен файл '{LoadTrajectoryTextBox.Text}'.");
                    AddMessageToDataGrid(Info, $"Загружено {getxml.ScnFiles.Count} сценариев (scn).");
                }
            }
            catch
            {

            }
        }

        private void ClearProtocolMenuItem_Click(object sender, EventArgs e)
        {
            ProtocolDataGrid.Rows.Clear();
        }

        private void SaveFactorsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_factorList.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения.",
                    "Данные не сохранены",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.fact)|*.fact|Все файлы (*.*)|*.*",
                AddExtension = true,
                DefaultExt = ".fact"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName.ToString();
                using (FileStream fileStream = new FileStream(path,
                    FileMode.OpenOrCreate))
                {
                    _serializer.Serialize(fileStream, _factorList);
                }
                AddMessageToDataGrid(Info, $"Файл с влияющими факторами сохранён в {path}");
            }
        }

        private void LoadFactorsStripMenuItem_Click(object sender, EventArgs e)
        {
            _factorList.Clear();
            InfluentFactorsDataGridView.Rows.Clear();
            if(_rstFileName == null)
            {
                AddMessageToDataGrid(Error, "Прежде чем загрузить список факторов, загрузите файл исходных данных *.rst!");
                return;
            }


            var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.fact)|*.fact|Все файлы (*.*)|*.*",
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var path = openFileDialog.FileName.ToString();
            try
            {
                using (FileStream fileStream = new FileStream(path,
                    FileMode.OpenOrCreate))
                {
                    _factorList = (BindingList<InfluentFactorBase>)_serializer.
                        Deserialize(fileStream);
                }
                InfluentFactorsDataGridView.DataSource = _factorList;

                foreach(var factor in _factorList)
                {
                    if(factor is VoltageFactor)
                    {
                        factor.CurrentValue = RastrSupplier.GetValue("node", "ny", factor.NumberFromRastr, "vras");
                    }
                    if(factor is SectionFactor)
                    {
                        factor.CurrentValue = RastrSupplier.GetValue("sechen", "ns", factor.NumberFromRastr, "psech");
                    }
                }

                InfluentFactorsDataGridView.CurrentCell = null;
                InfluentFactorsDataGridView.Refresh();
                AddMessageToDataGrid(Info, $"Файл с влияющими факторами Загружен из {path}");
            }
            catch (Exception)
            {
                MessageBox.Show("Файл повреждён или не соответствует формату. Проверьте загруженный файл *.rst!",
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveResultsButton_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder fileContent = new StringBuilder();

                    foreach (var col in resultsTable.Columns)
                    {
                        fileContent.Append(col.ToString() + ",");
                    }

                    fileContent.Replace(",", Environment.NewLine, fileContent.Length - 1, 1);

                    foreach (DataRow dr in resultsTable.Rows)
                    {
                        foreach (var column in dr.ItemArray)
                        {
                            fileContent.Append("\"" + column.ToString() + "\",");
                        }

                        fileContent.Replace(",", Environment.NewLine, fileContent.Length - 1, 1);
                    }


                    File.WriteAllText(saveFileDialog.FileName, fileContent.ToString(), Encoding.UTF8);
                    DialogResult = DialogResult.OK;
                    AddMessageToDataGrid(Info, $"Файл протокола сохранён в {saveFileDialog.FileName}");
                }
            
            }
            catch
            {
                AddMessageToDataGrid(Error, $"Закройте файл и повторите попытку!");
            }
        }
    }
}
