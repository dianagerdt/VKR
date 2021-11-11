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
    public partial class MainForm : Form
    {
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

        //Списки, хранящие номера узлов и сечений из файлов rst и sch
        public List<int> numbersOfNodesFromRastr = new List<int>();
        public List<int> numbersOfSectionsFromRastr = new List<int>();

        /// <summary>
        /// Словарь для сопоставления TextBox и Action
        /// </summary>
        private readonly Dictionary<TextBox,
            Action<InfluentFactorBase, double>> _textBoxValidationActionForMinMax;

        /// <summary>
        /// Словарь для сопоставления TextBox и Action
        /// </summary>
        private readonly Dictionary<ComboBox,
            Action<InfluentFactorBase, int>> _textBoxValidationActionForNumber;

        /// <summary>
        /// Свойство для вывода данных о факторе
        /// </summary>
        public InfluentFactorBase FactorData
        {
            get
            {
                return _factor;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FromFileRadioButton.Checked = true;
            ByHandRadioButton.Checked = false;
            LoadTrajectoryTextBox.Visible = true;
            LoadTrajectoryButton.Visible = true;
            InfoAboutTrajectoryLabel.Visible = false;

            //Вторая вкладка

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

        private void ByHandRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            FromFileRadioButton.Checked = false;
            ByHandRadioButton.Checked = true;
            LoadTrajectoryTextBox.Visible = false;
            LoadTrajectoryButton.Visible = false;
            InfoAboutTrajectoryLabel.Visible = true;
        }

        private void FromFileRadioButton_MouseClick(object sender, MouseEventArgs e)
        {
            FromFileRadioButton.Checked = true;
            ByHandRadioButton.Checked = false;
            LoadTrajectoryTextBox.Visible = true;
            LoadTrajectoryButton.Visible = true;
            InfoAboutTrajectoryLabel.Visible = false;
        }

        private void TrajectorySettingsButton_Click(object sender, EventArgs e)
        {
            var trajectorySettings = new TrajectorySettingsForm(numbersOfSectionsFromRastr, numbersOfNodesFromRastr);
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

        // Загрузка самого файла rst!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void LoadRstButton_Click(object sender, EventArgs e)
        {
            string RstFilter = "Файл динамики (*.rg2)|*.rg2";
            string shablon = @"../../Resources/режим.rg2";
            LoadInitialFile(RstFilter, RstOpenFileDialog, LoadRstTextBox, _rastrSupplier, shablon);
            RastrSupplier.FillListOfNumbersFromRastr(numbersOfNodesFromRastr, "node", "ny");
        }

        private void LoadSchButton_Click(object sender, EventArgs e)
        {
            string SchFilter = "Файл сечения (*.sch)|*.sch";
            string shablon = @"../../Resources/сечения.sch";
            LoadInitialFile(SchFilter, SchOpenFileDialog, LoadSchTextBox, _rastrSupplier, shablon);
            RastrSupplier.FillListOfNumbersFromRastr(numbersOfSectionsFromRastr, "sechen", "ns");
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
                    MessageBox.Show("Ошибка! Вы загрузили файл неверного формата.\n" +
                        "Попробуйте ещё раз.\n" + exeption.Message);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataGridViewTools.CreateTableForFactors(_factorList, InfluentFactorsDataGridView);
        }

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
        private void SetValue(Action action)
        {
            action.Invoke();
        }

        /// <summary>
        /// Ввод данных о напряжении
        /// </summary>
        /// <returns>Созданный экземпляр класса VoltageFactor</returns>
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
                    RastrSupplier.GetValue("node", "ny", Convert.ToInt32(InfluentFactorNumCombobox.Text), "vras");
                })
            };
            actions.ForEach(SetValue);
            return newVoltageFactor;
        }

        /// <summary>
        /// Ввод данных о перетоке
        /// </summary>
        /// <returns>Созданный экземпляр класса SectionFactor</returns>
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
                    RastrSupplier.GetValue("sechen", "ns", Convert.ToInt32(InfluentFactorNumCombobox.Text), "psech");
                })
            };
            actions.ForEach(SetValue);
            return newSectionFactor;
        }

        /// <summary>
        /// Ввод данных о перетоке
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
                    RastrSupplier.GetValue("node", "ny", Convert.ToInt32(InfluentFactorNumCombobox.Text), "pn");
                })
            };
            actions.ForEach(SetValue);
            return newLoadFactor;
        }

        /// <summary>
        /// Ввод данных о фигурах
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

        private void AddFactorToGridButton_Click(object sender, EventArgs e)
        {
            try
            {
                InsertData();
                InfluentFactorBase.IsMinMaxCorrect(_factor.MinValue, _factor.MaxValue);

                var countOfRows = InfluentFactorsDataGridView.Rows.Count;
                for (int i = 0; i < countOfRows; i++)
                {
                    if(_factor.NumberFromRastr == Convert.ToDouble(InfluentFactorsDataGridView[1, i].Value))
                    {
                        throw new Exception("Этот влияющий фактор уже добавлен в список! Попробуйте ещё раз.");
                    }
                }

                _factorList.Add(_factor);
            }
            catch
            {
                MessageBox.Show("Вы не загрузили исходные файлы или введено некорректное значение!\n" +
                    "Пожалуйста, проверьте исходные данные.",
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                InfluentFactorNumCombobox.Text = "";
                InfluentFactorMinTextBox.Clear();
                InfluentFactorMaxTextbox.Clear();
            }
        }

        private void RemoveFactorFromGridButton_Click(object sender, EventArgs e)
        {
            var countOfRows = InfluentFactorsDataGridView.SelectedRows.Count;
            for (int i = 0; i < countOfRows; i++)
            {
                _factorList.RemoveAt(InfluentFactorsDataGridView.SelectedRows[0].Index);
            }
        }

        private void ClearAllFactorsFromGridButton_Click(object sender, EventArgs e)
        {
            _factorList.Clear();
        }

        private void InfluentFactorNumCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InfluentFactorNumCombobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            InfluentFactorNumCombobox.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
    }
}
