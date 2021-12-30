
namespace RustabBot_v1._0
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TabPageCalc = new System.Windows.Forms.TabPage();
            this.TransientStabilityAnalysisGroupBox = new System.Windows.Forms.GroupBox();
            this.ProtocolDataGrid = new System.Windows.Forms.DataGridView();
            this.ClearProtocolStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ClearProtocolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearProtocol = new System.Windows.Forms.Button();
            this.SaveResultsButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StopCalcButton = new System.Windows.Forms.Button();
            this.StartCalcButton = new System.Windows.Forms.Button();
            this.InfluentFactorsGroupBox = new System.Windows.Forms.GroupBox();
            this.InfluentFactorNumCombobox = new System.Windows.Forms.ComboBox();
            this.InfluentFactorsDataGridView = new System.Windows.Forms.DataGridView();
            this.FactorsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LoadFactorsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFactorsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearAllFactorsFromGridButton = new System.Windows.Forms.Button();
            this.RemoveFactorFromGridButton = new System.Windows.Forms.Button();
            this.AddFactorToGridButton = new System.Windows.Forms.Button();
            this.InfluentFactorMaxTextbox = new System.Windows.Forms.TextBox();
            this.InfluentFactorMax = new System.Windows.Forms.Label();
            this.InfluentFactorMinTextBox = new System.Windows.Forms.TextBox();
            this.InfluentFactorMinLabel = new System.Windows.Forms.Label();
            this.InfluentFactorNumLabel = new System.Windows.Forms.Label();
            this.FactorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.FactorTypeLabel = new System.Windows.Forms.Label();
            this.TabPageFiles = new System.Windows.Forms.TabPage();
            this.RememberFilesPaths = new System.Windows.Forms.CheckBox();
            this.TrajectorySettingsButton = new System.Windows.Forms.Button();
            this.LoadScnListBox = new System.Windows.Forms.ListBox();
            this.TrajectoryGroupBox = new System.Windows.Forms.GroupBox();
            this.InfoAboutTrajectoryLabel2 = new System.Windows.Forms.Label();
            this.InfoAboutTrajectoryLabel = new System.Windows.Forms.Label();
            this.LoadTrajectoryTextBox = new System.Windows.Forms.TextBox();
            this.FromFileRadioButton = new System.Windows.Forms.RadioButton();
            this.LoadTrajectoryButton = new System.Windows.Forms.Button();
            this.ByHandRadioButton = new System.Windows.Forms.RadioButton();
            this.TrajectorySettingsLabel = new System.Windows.Forms.Label();
            this.LoadDfwTextBox = new System.Windows.Forms.TextBox();
            this.LabelDfwPath = new System.Windows.Forms.Label();
            this.LoadDfwButton = new System.Windows.Forms.Button();
            this.LoadSchTextBox = new System.Windows.Forms.TextBox();
            this.LabelSchPath = new System.Windows.Forms.Label();
            this.LoadSchButton = new System.Windows.Forms.Button();
            this.LoadRstTextBox = new System.Windows.Forms.TextBox();
            this.LabelRstPath = new System.Windows.Forms.Label();
            this.LoadRstButton = new System.Windows.Forms.Button();
            this.LoadScnTextBox = new System.Windows.Forms.TextBox();
            this.LabelScnPath = new System.Windows.Forms.Label();
            this.LoadScnButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPageInfo = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.RstOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SchOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DfwOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Ut2OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ScnOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TabPageCalc.SuspendLayout();
            this.TransientStabilityAnalysisGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolDataGrid)).BeginInit();
            this.ClearProtocolStrip.SuspendLayout();
            this.InfluentFactorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfluentFactorsDataGridView)).BeginInit();
            this.FactorsMenuStrip.SuspendLayout();
            this.TabPageFiles.SuspendLayout();
            this.TrajectoryGroupBox.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabPageInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPageCalc
            // 
            this.TabPageCalc.Controls.Add(this.TransientStabilityAnalysisGroupBox);
            this.TabPageCalc.Controls.Add(this.InfluentFactorsGroupBox);
            this.TabPageCalc.Location = new System.Drawing.Point(4, 25);
            this.TabPageCalc.Name = "TabPageCalc";
            this.TabPageCalc.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCalc.Size = new System.Drawing.Size(595, 688);
            this.TabPageCalc.TabIndex = 1;
            this.TabPageCalc.Text = "Расчёты";
            this.TabPageCalc.UseVisualStyleBackColor = true;
            // 
            // TransientStabilityAnalysisGroupBox
            // 
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.ProtocolDataGrid);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.ClearProtocol);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.SaveResultsButton);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.ProgressBar);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.StopCalcButton);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.StartCalcButton);
            this.TransientStabilityAnalysisGroupBox.Location = new System.Drawing.Point(6, 306);
            this.TransientStabilityAnalysisGroupBox.Name = "TransientStabilityAnalysisGroupBox";
            this.TransientStabilityAnalysisGroupBox.Size = new System.Drawing.Size(578, 376);
            this.TransientStabilityAnalysisGroupBox.TabIndex = 1;
            this.TransientStabilityAnalysisGroupBox.TabStop = false;
            this.TransientStabilityAnalysisGroupBox.Text = "Расчёты";
            // 
            // ProtocolDataGrid
            // 
            this.ProtocolDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProtocolDataGrid.ContextMenuStrip = this.ClearProtocolStrip;
            this.ProtocolDataGrid.Location = new System.Drawing.Point(6, 66);
            this.ProtocolDataGrid.Name = "ProtocolDataGrid";
            this.ProtocolDataGrid.RowHeadersWidth = 51;
            this.ProtocolDataGrid.RowTemplate.Height = 24;
            this.ProtocolDataGrid.Size = new System.Drawing.Size(566, 235);
            this.ProtocolDataGrid.TabIndex = 16;
            this.ProtocolDataGrid.SelectionChanged += new System.EventHandler(this.ProtocolDataGrid_SelectionChanged);
            // 
            // ClearProtocolStrip
            // 
            this.ClearProtocolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ClearProtocolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearProtocolMenuItem});
            this.ClearProtocolStrip.Name = "ClearProtocolStrip";
            this.ClearProtocolStrip.Size = new System.Drawing.Size(213, 28);
            // 
            // ClearProtocolMenuItem
            // 
            this.ClearProtocolMenuItem.Name = "ClearProtocolMenuItem";
            this.ClearProtocolMenuItem.Size = new System.Drawing.Size(212, 24);
            this.ClearProtocolMenuItem.Text = "Очистить протокол";
            this.ClearProtocolMenuItem.Click += new System.EventHandler(this.ClearProtocolMenuItem_Click);
            // 
            // ClearProtocol
            // 
            this.ClearProtocol.Location = new System.Drawing.Point(401, 30);
            this.ClearProtocol.Name = "ClearProtocol";
            this.ClearProtocol.Size = new System.Drawing.Size(171, 30);
            this.ClearProtocol.TabIndex = 15;
            this.ClearProtocol.Text = "Очистить протокол";
            this.ClearProtocol.UseVisualStyleBackColor = true;
            this.ClearProtocol.Click += new System.EventHandler(this.ClearProtocol_Click);
            // 
            // SaveResultsButton
            // 
            this.SaveResultsButton.Location = new System.Drawing.Point(469, 339);
            this.SaveResultsButton.Name = "SaveResultsButton";
            this.SaveResultsButton.Size = new System.Drawing.Size(103, 30);
            this.SaveResultsButton.TabIndex = 12;
            this.SaveResultsButton.Text = "Сохранить";
            this.SaveResultsButton.UseVisualStyleBackColor = true;
            this.SaveResultsButton.Click += new System.EventHandler(this.SaveResultsButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(6, 307);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(566, 27);
            this.ProgressBar.TabIndex = 14;
            // 
            // StopCalcButton
            // 
            this.StopCalcButton.Location = new System.Drawing.Point(204, 30);
            this.StopCalcButton.Name = "StopCalcButton";
            this.StopCalcButton.Size = new System.Drawing.Size(171, 30);
            this.StopCalcButton.TabIndex = 13;
            this.StopCalcButton.Text = "Остановить расчёт";
            this.StopCalcButton.UseVisualStyleBackColor = true;
            this.StopCalcButton.Click += new System.EventHandler(this.StopCalcButton_Click);
            // 
            // StartCalcButton
            // 
            this.StartCalcButton.Location = new System.Drawing.Point(6, 30);
            this.StartCalcButton.Name = "StartCalcButton";
            this.StartCalcButton.Size = new System.Drawing.Size(171, 30);
            this.StartCalcButton.TabIndex = 12;
            this.StartCalcButton.Text = "Начать расчёт";
            this.StartCalcButton.UseVisualStyleBackColor = true;
            this.StartCalcButton.Click += new System.EventHandler(this.StartCalcButton_Click);
            // 
            // InfluentFactorsGroupBox
            // 
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorNumCombobox);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorsDataGridView);
            this.InfluentFactorsGroupBox.Controls.Add(this.ClearAllFactorsFromGridButton);
            this.InfluentFactorsGroupBox.Controls.Add(this.RemoveFactorFromGridButton);
            this.InfluentFactorsGroupBox.Controls.Add(this.AddFactorToGridButton);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorMaxTextbox);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorMax);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorMinTextBox);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorMinLabel);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorNumLabel);
            this.InfluentFactorsGroupBox.Controls.Add(this.FactorTypeComboBox);
            this.InfluentFactorsGroupBox.Controls.Add(this.FactorTypeLabel);
            this.InfluentFactorsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.InfluentFactorsGroupBox.Name = "InfluentFactorsGroupBox";
            this.InfluentFactorsGroupBox.Size = new System.Drawing.Size(578, 294);
            this.InfluentFactorsGroupBox.TabIndex = 0;
            this.InfluentFactorsGroupBox.TabStop = false;
            this.InfluentFactorsGroupBox.Text = "Влияющие факторы";
            // 
            // InfluentFactorNumCombobox
            // 
            this.InfluentFactorNumCombobox.FormattingEnabled = true;
            this.InfluentFactorNumCombobox.Location = new System.Drawing.Point(194, 50);
            this.InfluentFactorNumCombobox.Name = "InfluentFactorNumCombobox";
            this.InfluentFactorNumCombobox.Size = new System.Drawing.Size(145, 24);
            this.InfluentFactorNumCombobox.TabIndex = 12;
            this.InfluentFactorNumCombobox.SelectedIndexChanged += new System.EventHandler(this.InfluentFactorNumCombobox_SelectedIndexChanged);
            // 
            // InfluentFactorsDataGridView
            // 
            this.InfluentFactorsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfluentFactorsDataGridView.ContextMenuStrip = this.FactorsMenuStrip;
            this.InfluentFactorsDataGridView.Location = new System.Drawing.Point(6, 124);
            this.InfluentFactorsDataGridView.Name = "InfluentFactorsDataGridView";
            this.InfluentFactorsDataGridView.RowHeadersWidth = 51;
            this.InfluentFactorsDataGridView.RowTemplate.Height = 24;
            this.InfluentFactorsDataGridView.Size = new System.Drawing.Size(566, 164);
            this.InfluentFactorsDataGridView.TabIndex = 11;
            // 
            // FactorsMenuStrip
            // 
            this.FactorsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FactorsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFactorsStripMenuItem,
            this.SaveFactorsStripMenuItem});
            this.FactorsMenuStrip.Name = "FactorsMenuStrip";
            this.FactorsMenuStrip.Size = new System.Drawing.Size(153, 52);
            // 
            // LoadFactorsStripMenuItem
            // 
            this.LoadFactorsStripMenuItem.Name = "LoadFactorsStripMenuItem";
            this.LoadFactorsStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.LoadFactorsStripMenuItem.Text = "Загрузить";
            this.LoadFactorsStripMenuItem.Click += new System.EventHandler(this.LoadFactorsStripMenuItem_Click);
            // 
            // SaveFactorsStripMenuItem
            // 
            this.SaveFactorsStripMenuItem.Name = "SaveFactorsStripMenuItem";
            this.SaveFactorsStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.SaveFactorsStripMenuItem.Text = "Сохранить";
            this.SaveFactorsStripMenuItem.Click += new System.EventHandler(this.SaveFactorsStripMenuItem_Click);
            // 
            // ClearAllFactorsFromGridButton
            // 
            this.ClearAllFactorsFromGridButton.Location = new System.Drawing.Point(355, 84);
            this.ClearAllFactorsFromGridButton.Name = "ClearAllFactorsFromGridButton";
            this.ClearAllFactorsFromGridButton.Size = new System.Drawing.Size(119, 30);
            this.ClearAllFactorsFromGridButton.TabIndex = 10;
            this.ClearAllFactorsFromGridButton.Text = "Очистить";
            this.ClearAllFactorsFromGridButton.UseVisualStyleBackColor = true;
            this.ClearAllFactorsFromGridButton.Click += new System.EventHandler(this.ClearAllFactorsFromGridButton_Click);
            // 
            // RemoveFactorFromGridButton
            // 
            this.RemoveFactorFromGridButton.Location = new System.Drawing.Point(230, 84);
            this.RemoveFactorFromGridButton.Name = "RemoveFactorFromGridButton";
            this.RemoveFactorFromGridButton.Size = new System.Drawing.Size(119, 30);
            this.RemoveFactorFromGridButton.TabIndex = 9;
            this.RemoveFactorFromGridButton.Text = "Удалить";
            this.RemoveFactorFromGridButton.UseVisualStyleBackColor = true;
            this.RemoveFactorFromGridButton.Click += new System.EventHandler(this.RemoveFactorFromGridButton_Click);
            // 
            // AddFactorToGridButton
            // 
            this.AddFactorToGridButton.Location = new System.Drawing.Point(105, 84);
            this.AddFactorToGridButton.Name = "AddFactorToGridButton";
            this.AddFactorToGridButton.Size = new System.Drawing.Size(119, 30);
            this.AddFactorToGridButton.TabIndex = 8;
            this.AddFactorToGridButton.Text = "Добавить";
            this.AddFactorToGridButton.UseVisualStyleBackColor = true;
            this.AddFactorToGridButton.Click += new System.EventHandler(this.AddFactorToGridButton_Click);
            // 
            // InfluentFactorMaxTextbox
            // 
            this.InfluentFactorMaxTextbox.Location = new System.Drawing.Point(461, 50);
            this.InfluentFactorMaxTextbox.Name = "InfluentFactorMaxTextbox";
            this.InfluentFactorMaxTextbox.Size = new System.Drawing.Size(111, 22);
            this.InfluentFactorMaxTextbox.TabIndex = 7;
            // 
            // InfluentFactorMax
            // 
            this.InfluentFactorMax.AutoSize = true;
            this.InfluentFactorMax.Location = new System.Drawing.Point(458, 28);
            this.InfluentFactorMax.Name = "InfluentFactorMax";
            this.InfluentFactorMax.Size = new System.Drawing.Size(74, 16);
            this.InfluentFactorMax.TabIndex = 6;
            this.InfluentFactorMax.Text = "Максимум";
            // 
            // InfluentFactorMinTextBox
            // 
            this.InfluentFactorMinTextBox.Location = new System.Drawing.Point(343, 50);
            this.InfluentFactorMinTextBox.Name = "InfluentFactorMinTextBox";
            this.InfluentFactorMinTextBox.Size = new System.Drawing.Size(113, 22);
            this.InfluentFactorMinTextBox.TabIndex = 5;
            // 
            // InfluentFactorMinLabel
            // 
            this.InfluentFactorMinLabel.AutoSize = true;
            this.InfluentFactorMinLabel.Location = new System.Drawing.Point(339, 28);
            this.InfluentFactorMinLabel.Name = "InfluentFactorMinLabel";
            this.InfluentFactorMinLabel.Size = new System.Drawing.Size(68, 16);
            this.InfluentFactorMinLabel.TabIndex = 4;
            this.InfluentFactorMinLabel.Text = "Минимум";
            // 
            // InfluentFactorNumLabel
            // 
            this.InfluentFactorNumLabel.AutoSize = true;
            this.InfluentFactorNumLabel.Location = new System.Drawing.Point(192, 28);
            this.InfluentFactorNumLabel.Name = "InfluentFactorNumLabel";
            this.InfluentFactorNumLabel.Size = new System.Drawing.Size(50, 16);
            this.InfluentFactorNumLabel.TabIndex = 2;
            this.InfluentFactorNumLabel.Text = "Номер";
            // 
            // FactorTypeComboBox
            // 
            this.FactorTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FactorTypeComboBox.FormattingEnabled = true;
            this.FactorTypeComboBox.Items.AddRange(new object[] {
            "Напряжение",
            "Переток"});
            this.FactorTypeComboBox.Location = new System.Drawing.Point(9, 50);
            this.FactorTypeComboBox.Name = "FactorTypeComboBox";
            this.FactorTypeComboBox.Size = new System.Drawing.Size(180, 24);
            this.FactorTypeComboBox.TabIndex = 1;
            this.FactorTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.FactorTypeComboBox_SelectedIndexChanged);
            // 
            // FactorTypeLabel
            // 
            this.FactorTypeLabel.AutoSize = true;
            this.FactorTypeLabel.Location = new System.Drawing.Point(6, 30);
            this.FactorTypeLabel.Name = "FactorTypeLabel";
            this.FactorTypeLabel.Size = new System.Drawing.Size(92, 16);
            this.FactorTypeLabel.TabIndex = 0;
            this.FactorTypeLabel.Text = "Тип фактора";
            // 
            // TabPageFiles
            // 
            this.TabPageFiles.Controls.Add(this.RememberFilesPaths);
            this.TabPageFiles.Controls.Add(this.TrajectorySettingsButton);
            this.TabPageFiles.Controls.Add(this.LoadScnListBox);
            this.TabPageFiles.Controls.Add(this.TrajectoryGroupBox);
            this.TabPageFiles.Controls.Add(this.LoadDfwTextBox);
            this.TabPageFiles.Controls.Add(this.LabelDfwPath);
            this.TabPageFiles.Controls.Add(this.LoadDfwButton);
            this.TabPageFiles.Controls.Add(this.LoadSchTextBox);
            this.TabPageFiles.Controls.Add(this.LabelSchPath);
            this.TabPageFiles.Controls.Add(this.LoadSchButton);
            this.TabPageFiles.Controls.Add(this.LoadRstTextBox);
            this.TabPageFiles.Controls.Add(this.LabelRstPath);
            this.TabPageFiles.Controls.Add(this.LoadRstButton);
            this.TabPageFiles.Controls.Add(this.LoadScnTextBox);
            this.TabPageFiles.Controls.Add(this.LabelScnPath);
            this.TabPageFiles.Controls.Add(this.LoadScnButton);
            this.TabPageFiles.Location = new System.Drawing.Point(4, 25);
            this.TabPageFiles.Name = "TabPageFiles";
            this.TabPageFiles.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageFiles.Size = new System.Drawing.Size(595, 688);
            this.TabPageFiles.TabIndex = 0;
            this.TabPageFiles.Text = "Файлы";
            this.TabPageFiles.UseVisualStyleBackColor = true;
            // 
            // RememberFilesPaths
            // 
            this.RememberFilesPaths.AutoSize = true;
            this.RememberFilesPaths.Location = new System.Drawing.Point(18, 653);
            this.RememberFilesPaths.Name = "RememberFilesPaths";
            this.RememberFilesPaths.Size = new System.Drawing.Size(278, 20);
            this.RememberFilesPaths.TabIndex = 16;
            this.RememberFilesPaths.Text = "Запомнить пути загруженных файлов";
            this.RememberFilesPaths.UseVisualStyleBackColor = true;
            // 
            // TrajectorySettingsButton
            // 
            this.TrajectorySettingsButton.Location = new System.Drawing.Point(18, 356);
            this.TrajectorySettingsButton.Name = "TrajectorySettingsButton";
            this.TrajectorySettingsButton.Size = new System.Drawing.Size(200, 30);
            this.TrajectorySettingsButton.TabIndex = 14;
            this.TrajectorySettingsButton.Text = "Настройка траектории";
            this.TrajectorySettingsButton.UseVisualStyleBackColor = true;
            this.TrajectorySettingsButton.Click += new System.EventHandler(this.TrajectorySettingsButton_Click);
            // 
            // LoadScnListBox
            // 
            this.LoadScnListBox.FormattingEnabled = true;
            this.LoadScnListBox.HorizontalScrollbar = true;
            this.LoadScnListBox.ItemHeight = 16;
            this.LoadScnListBox.Location = new System.Drawing.Point(18, 429);
            this.LoadScnListBox.Name = "LoadScnListBox";
            this.LoadScnListBox.Size = new System.Drawing.Size(437, 212);
            this.LoadScnListBox.TabIndex = 14;
            // 
            // TrajectoryGroupBox
            // 
            this.TrajectoryGroupBox.Controls.Add(this.InfoAboutTrajectoryLabel2);
            this.TrajectoryGroupBox.Controls.Add(this.InfoAboutTrajectoryLabel);
            this.TrajectoryGroupBox.Controls.Add(this.LoadTrajectoryTextBox);
            this.TrajectoryGroupBox.Controls.Add(this.FromFileRadioButton);
            this.TrajectoryGroupBox.Controls.Add(this.LoadTrajectoryButton);
            this.TrajectoryGroupBox.Controls.Add(this.ByHandRadioButton);
            this.TrajectoryGroupBox.Controls.Add(this.TrajectorySettingsLabel);
            this.TrajectoryGroupBox.Location = new System.Drawing.Point(18, 233);
            this.TrajectoryGroupBox.Name = "TrajectoryGroupBox";
            this.TrajectoryGroupBox.Size = new System.Drawing.Size(554, 111);
            this.TrajectoryGroupBox.TabIndex = 12;
            this.TrajectoryGroupBox.TabStop = false;
            this.TrajectoryGroupBox.Text = "Траектория утяжеления";
            // 
            // InfoAboutTrajectoryLabel2
            // 
            this.InfoAboutTrajectoryLabel2.AutoSize = true;
            this.InfoAboutTrajectoryLabel2.Location = new System.Drawing.Point(15, 79);
            this.InfoAboutTrajectoryLabel2.Name = "InfoAboutTrajectoryLabel2";
            this.InfoAboutTrajectoryLabel2.Size = new System.Drawing.Size(255, 16);
            this.InfoAboutTrajectoryLabel2.TabIndex = 17;
            this.InfoAboutTrajectoryLabel2.Text = "выберите опцию загрузки \"из файла\"";
            // 
            // InfoAboutTrajectoryLabel
            // 
            this.InfoAboutTrajectoryLabel.AutoSize = true;
            this.InfoAboutTrajectoryLabel.Location = new System.Drawing.Point(15, 60);
            this.InfoAboutTrajectoryLabel.Name = "InfoAboutTrajectoryLabel";
            this.InfoAboutTrajectoryLabel.Size = new System.Drawing.Size(475, 16);
            this.InfoAboutTrajectoryLabel.TabIndex = 16;
            this.InfoAboutTrajectoryLabel.Text = "Выполните настройку вручную (нажмите \"Настройка траектории\") или ";
            // 
            // LoadTrajectoryTextBox
            // 
            this.LoadTrajectoryTextBox.Location = new System.Drawing.Point(9, 70);
            this.LoadTrajectoryTextBox.Name = "LoadTrajectoryTextBox";
            this.LoadTrajectoryTextBox.Size = new System.Drawing.Size(428, 22);
            this.LoadTrajectoryTextBox.TabIndex = 14;
            // 
            // FromFileRadioButton
            // 
            this.FromFileRadioButton.AutoSize = true;
            this.FromFileRadioButton.Location = new System.Drawing.Point(166, 33);
            this.FromFileRadioButton.Name = "FromFileRadioButton";
            this.FromFileRadioButton.Size = new System.Drawing.Size(90, 20);
            this.FromFileRadioButton.TabIndex = 15;
            this.FromFileRadioButton.TabStop = true;
            this.FromFileRadioButton.Text = "из файла";
            this.FromFileRadioButton.UseVisualStyleBackColor = true;
            this.FromFileRadioButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FromFileRadioButton_MouseClick);
            // 
            // LoadTrajectoryButton
            // 
            this.LoadTrajectoryButton.Location = new System.Drawing.Point(453, 66);
            this.LoadTrajectoryButton.Name = "LoadTrajectoryButton";
            this.LoadTrajectoryButton.Size = new System.Drawing.Size(91, 30);
            this.LoadTrajectoryButton.TabIndex = 13;
            this.LoadTrajectoryButton.Text = "Загрузить";
            this.LoadTrajectoryButton.UseVisualStyleBackColor = true;
            this.LoadTrajectoryButton.Click += new System.EventHandler(this.LoadTrajectoryButton_Click);
            // 
            // ByHandRadioButton
            // 
            this.ByHandRadioButton.AutoSize = true;
            this.ByHandRadioButton.Location = new System.Drawing.Point(275, 33);
            this.ByHandRadioButton.Name = "ByHandRadioButton";
            this.ByHandRadioButton.Size = new System.Drawing.Size(86, 20);
            this.ByHandRadioButton.TabIndex = 14;
            this.ByHandRadioButton.TabStop = true;
            this.ByHandRadioButton.Text = "вручную";
            this.ByHandRadioButton.UseVisualStyleBackColor = true;
            this.ByHandRadioButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ByHandRadioButton_MouseClick);
            // 
            // TrajectorySettingsLabel
            // 
            this.TrajectorySettingsLabel.AutoSize = true;
            this.TrajectorySettingsLabel.Location = new System.Drawing.Point(15, 33);
            this.TrajectorySettingsLabel.Name = "TrajectorySettingsLabel";
            this.TrajectorySettingsLabel.Size = new System.Drawing.Size(136, 16);
            this.TrajectorySettingsLabel.TabIndex = 13;
            this.TrajectorySettingsLabel.Text = "Задать траекторию";
            // 
            // LoadDfwTextBox
            // 
            this.LoadDfwTextBox.Location = new System.Drawing.Point(18, 190);
            this.LoadDfwTextBox.Name = "LoadDfwTextBox";
            this.LoadDfwTextBox.Size = new System.Drawing.Size(437, 22);
            this.LoadDfwTextBox.TabIndex = 11;
            // 
            // LabelDfwPath
            // 
            this.LabelDfwPath.AutoSize = true;
            this.LabelDfwPath.Location = new System.Drawing.Point(15, 160);
            this.LabelDfwPath.Name = "LabelDfwPath";
            this.LabelDfwPath.Size = new System.Drawing.Size(154, 16);
            this.LabelDfwPath.TabIndex = 10;
            this.LabelDfwPath.Text = "Файл автоматики (dfw)";
            // 
            // LoadDfwButton
            // 
            this.LoadDfwButton.Location = new System.Drawing.Point(471, 186);
            this.LoadDfwButton.Name = "LoadDfwButton";
            this.LoadDfwButton.Size = new System.Drawing.Size(91, 30);
            this.LoadDfwButton.TabIndex = 9;
            this.LoadDfwButton.Text = "Загрузить";
            this.LoadDfwButton.UseVisualStyleBackColor = true;
            this.LoadDfwButton.Click += new System.EventHandler(this.LoadDfwButton_Click);
            // 
            // LoadSchTextBox
            // 
            this.LoadSchTextBox.Location = new System.Drawing.Point(18, 118);
            this.LoadSchTextBox.Name = "LoadSchTextBox";
            this.LoadSchTextBox.Size = new System.Drawing.Size(437, 22);
            this.LoadSchTextBox.TabIndex = 8;
            // 
            // LabelSchPath
            // 
            this.LabelSchPath.AutoSize = true;
            this.LabelSchPath.Location = new System.Drawing.Point(15, 88);
            this.LabelSchPath.Name = "LabelSchPath";
            this.LabelSchPath.Size = new System.Drawing.Size(131, 16);
            this.LabelSchPath.TabIndex = 7;
            this.LabelSchPath.Text = "Файл сечения (sch)";
            // 
            // LoadSchButton
            // 
            this.LoadSchButton.Location = new System.Drawing.Point(471, 114);
            this.LoadSchButton.Name = "LoadSchButton";
            this.LoadSchButton.Size = new System.Drawing.Size(91, 30);
            this.LoadSchButton.TabIndex = 6;
            this.LoadSchButton.Text = "Загрузить";
            this.LoadSchButton.UseVisualStyleBackColor = true;
            this.LoadSchButton.Click += new System.EventHandler(this.LoadSchButton_Click);
            // 
            // LoadRstTextBox
            // 
            this.LoadRstTextBox.Location = new System.Drawing.Point(18, 46);
            this.LoadRstTextBox.Name = "LoadRstTextBox";
            this.LoadRstTextBox.Size = new System.Drawing.Size(437, 22);
            this.LoadRstTextBox.TabIndex = 5;
            // 
            // LabelRstPath
            // 
            this.LabelRstPath.AutoSize = true;
            this.LabelRstPath.Location = new System.Drawing.Point(15, 16);
            this.LabelRstPath.Name = "LabelRstPath";
            this.LabelRstPath.Size = new System.Drawing.Size(134, 16);
            this.LabelRstPath.TabIndex = 4;
            this.LabelRstPath.Text = "Файл динамики (rst)";
            // 
            // LoadRstButton
            // 
            this.LoadRstButton.Location = new System.Drawing.Point(471, 42);
            this.LoadRstButton.Name = "LoadRstButton";
            this.LoadRstButton.Size = new System.Drawing.Size(91, 30);
            this.LoadRstButton.TabIndex = 3;
            this.LoadRstButton.Text = "Загрузить";
            this.LoadRstButton.UseVisualStyleBackColor = true;
            this.LoadRstButton.Click += new System.EventHandler(this.LoadRstButton_Click);
            // 
            // LoadScnTextBox
            // 
            this.LoadScnTextBox.Location = new System.Drawing.Point(18, 45);
            this.LoadScnTextBox.Name = "LoadScnTextBox";
            this.LoadScnTextBox.Size = new System.Drawing.Size(437, 22);
            this.LoadScnTextBox.TabIndex = 2;
            this.LoadScnTextBox.Visible = false;
            // 
            // LabelScnPath
            // 
            this.LabelScnPath.AutoSize = true;
            this.LabelScnPath.Location = new System.Drawing.Point(15, 399);
            this.LabelScnPath.Name = "LabelScnPath";
            this.LabelScnPath.Size = new System.Drawing.Size(279, 16);
            this.LabelScnPath.TabIndex = 1;
            this.LabelScnPath.Text = "Cценарии нормативных возмущений (scn)";
            // 
            // LoadScnButton
            // 
            this.LoadScnButton.Location = new System.Drawing.Point(471, 429);
            this.LoadScnButton.Name = "LoadScnButton";
            this.LoadScnButton.Size = new System.Drawing.Size(91, 30);
            this.LoadScnButton.TabIndex = 0;
            this.LoadScnButton.Text = "Загрузить";
            this.LoadScnButton.UseVisualStyleBackColor = true;
            this.LoadScnButton.Click += new System.EventHandler(this.LoadScnButton_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageFiles);
            this.TabControl.Controls.Add(this.TabPageCalc);
            this.TabControl.Controls.Add(this.TabPageInfo);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(603, 717);
            this.TabControl.TabIndex = 0;
            // 
            // TabPageInfo
            // 
            this.TabPageInfo.Controls.Add(this.label1);
            this.TabPageInfo.Location = new System.Drawing.Point(4, 25);
            this.TabPageInfo.Name = "TabPageInfo";
            this.TabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageInfo.Size = new System.Drawing.Size(595, 688);
            this.TabPageInfo.TabIndex = 2;
            this.TabPageInfo.Text = "О программе";
            this.TabPageInfo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "продам гараж";
            // 
            // RstOpenFileDialog
            // 
            this.RstOpenFileDialog.FileName = "RstOpenFileDialog";
            // 
            // SchOpenFileDialog
            // 
            this.SchOpenFileDialog.FileName = "SchOpenFileDialog";
            // 
            // DfwOpenFileDialog
            // 
            this.DfwOpenFileDialog.FileName = "DfwOpenFileDialog";
            // 
            // Ut2OpenFileDialog
            // 
            this.Ut2OpenFileDialog.FileName = "Ut2OpenFileDialog";
            // 
            // ScnOpenFileDialog
            // 
            this.ScnOpenFileDialog.FileName = "ScnOpenFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(627, 741);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Расчёты ДУ с коррекцией траектории утяжеления";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabPageCalc.ResumeLayout(false);
            this.TransientStabilityAnalysisGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProtocolDataGrid)).EndInit();
            this.ClearProtocolStrip.ResumeLayout(false);
            this.InfluentFactorsGroupBox.ResumeLayout(false);
            this.InfluentFactorsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfluentFactorsDataGridView)).EndInit();
            this.FactorsMenuStrip.ResumeLayout(false);
            this.TabPageFiles.ResumeLayout(false);
            this.TabPageFiles.PerformLayout();
            this.TrajectoryGroupBox.ResumeLayout(false);
            this.TrajectoryGroupBox.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TabPageInfo.ResumeLayout(false);
            this.TabPageInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabPageCalc;
        private System.Windows.Forms.TabPage TabPageFiles;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPageInfo;
        private System.Windows.Forms.Label LabelScnPath;
        private System.Windows.Forms.Button LoadScnButton;
        private System.Windows.Forms.TextBox LoadRstTextBox;
        private System.Windows.Forms.Label LabelRstPath;
        private System.Windows.Forms.Button LoadRstButton;
        private System.Windows.Forms.TextBox LoadSchTextBox;
        private System.Windows.Forms.Label LabelSchPath;
        private System.Windows.Forms.Button LoadSchButton;
        private System.Windows.Forms.TextBox LoadDfwTextBox;
        private System.Windows.Forms.Label LabelDfwPath;
        private System.Windows.Forms.Button LoadDfwButton;
        private System.Windows.Forms.GroupBox TrajectoryGroupBox;
        private System.Windows.Forms.TextBox LoadTrajectoryTextBox;
        private System.Windows.Forms.RadioButton FromFileRadioButton;
        private System.Windows.Forms.Button LoadTrajectoryButton;
        private System.Windows.Forms.RadioButton ByHandRadioButton;
        private System.Windows.Forms.Label TrajectorySettingsLabel;
        private System.Windows.Forms.Button TrajectorySettingsButton;
        private System.Windows.Forms.GroupBox InfluentFactorsGroupBox;
        private System.Windows.Forms.ComboBox FactorTypeComboBox;
        private System.Windows.Forms.Label FactorTypeLabel;
        private System.Windows.Forms.Label InfluentFactorNumLabel;
        private System.Windows.Forms.TextBox InfluentFactorMaxTextbox;
        private System.Windows.Forms.Label InfluentFactorMax;
        private System.Windows.Forms.TextBox InfluentFactorMinTextBox;
        private System.Windows.Forms.Label InfluentFactorMinLabel;
        private System.Windows.Forms.Button ClearAllFactorsFromGridButton;
        private System.Windows.Forms.Button RemoveFactorFromGridButton;
        private System.Windows.Forms.Button AddFactorToGridButton;
        private System.Windows.Forms.DataGridView InfluentFactorsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox TransientStabilityAnalysisGroupBox;
        private System.Windows.Forms.Button StartCalcButton;
        private System.Windows.Forms.Button StopCalcButton;
        private System.Windows.Forms.Button SaveResultsButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.OpenFileDialog RstOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog SchOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog DfwOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog Ut2OpenFileDialog;
        private System.Windows.Forms.OpenFileDialog ScnOpenFileDialog;
        private System.Windows.Forms.TextBox LoadScnTextBox;
        private System.Windows.Forms.ListBox LoadScnListBox;
        private System.Windows.Forms.ComboBox InfluentFactorNumCombobox;
        private System.Windows.Forms.Label InfoAboutTrajectoryLabel;
        private System.Windows.Forms.Label InfoAboutTrajectoryLabel2;
        private System.Windows.Forms.Button ClearProtocol;
        private System.Windows.Forms.DataGridView ProtocolDataGrid;
        private System.Windows.Forms.CheckBox RememberFilesPaths;
        private System.Windows.Forms.ContextMenuStrip ClearProtocolStrip;
        private System.Windows.Forms.ToolStripMenuItem ClearProtocolMenuItem;
        private System.Windows.Forms.ContextMenuStrip FactorsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem LoadFactorsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFactorsStripMenuItem;
    }
}

