﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TabPageCalc = new System.Windows.Forms.TabPage();
            this.TransientStabilityAnalysisGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ProtocolListBox = new System.Windows.Forms.ListBox();
            this.InfluentFactorsGroupBox = new System.Windows.Forms.GroupBox();
            this.InfluentFactorsDataGridView = new System.Windows.Forms.DataGridView();
            this.ClearAllFactorsFromGridButton = new System.Windows.Forms.Button();
            this.RemoveFactorFromGridButton = new System.Windows.Forms.Button();
            this.AddFactorToGridButton = new System.Windows.Forms.Button();
            this.InfluentFactorMaxTextbox = new System.Windows.Forms.TextBox();
            this.InfluentFactorMax = new System.Windows.Forms.Label();
            this.InfluentFactorMinTextBox = new System.Windows.Forms.TextBox();
            this.InfluentFactorMinLabel = new System.Windows.Forms.Label();
            this.InfluentFactorNumTextBox = new System.Windows.Forms.TextBox();
            this.InfluentFactorNumLabel = new System.Windows.Forms.Label();
            this.FactorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.FactorTypeLabel = new System.Windows.Forms.Label();
            this.TabPageFiles = new System.Windows.Forms.TabPage();
            this.DBConnectionButton = new System.Windows.Forms.Button();
            this.TrajectoryGroupBox = new System.Windows.Forms.GroupBox();
            this.TrajectorySettingsButton = new System.Windows.Forms.Button();
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
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.TabPageCalc.SuspendLayout();
            this.TransientStabilityAnalysisGroupBox.SuspendLayout();
            this.InfluentFactorsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfluentFactorsDataGridView)).BeginInit();
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
            this.TabPageCalc.Size = new System.Drawing.Size(595, 618);
            this.TabPageCalc.TabIndex = 1;
            this.TabPageCalc.Text = "Расчёты";
            this.TabPageCalc.UseVisualStyleBackColor = true;
            // 
            // TransientStabilityAnalysisGroupBox
            // 
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.button3);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.progressBar1);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.button2);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.button1);
            this.TransientStabilityAnalysisGroupBox.Controls.Add(this.ProtocolListBox);
            this.TransientStabilityAnalysisGroupBox.Location = new System.Drawing.Point(6, 306);
            this.TransientStabilityAnalysisGroupBox.Name = "TransientStabilityAnalysisGroupBox";
            this.TransientStabilityAnalysisGroupBox.Size = new System.Drawing.Size(578, 306);
            this.TransientStabilityAnalysisGroupBox.TabIndex = 1;
            this.TransientStabilityAnalysisGroupBox.TabStop = false;
            this.TransientStabilityAnalysisGroupBox.Text = "Расчёты";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "Начать расчёт";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ProtocolListBox
            // 
            this.ProtocolListBox.FormattingEnabled = true;
            this.ProtocolListBox.ItemHeight = 16;
            this.ProtocolListBox.Location = new System.Drawing.Point(6, 75);
            this.ProtocolListBox.Name = "ProtocolListBox";
            this.ProtocolListBox.Size = new System.Drawing.Size(566, 148);
            this.ProtocolListBox.TabIndex = 0;
            // 
            // InfluentFactorsGroupBox
            // 
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorsDataGridView);
            this.InfluentFactorsGroupBox.Controls.Add(this.ClearAllFactorsFromGridButton);
            this.InfluentFactorsGroupBox.Controls.Add(this.RemoveFactorFromGridButton);
            this.InfluentFactorsGroupBox.Controls.Add(this.AddFactorToGridButton);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorMaxTextbox);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorMax);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorMinTextBox);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorMinLabel);
            this.InfluentFactorsGroupBox.Controls.Add(this.InfluentFactorNumTextBox);
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
            // InfluentFactorsDataGridView
            // 
            this.InfluentFactorsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfluentFactorsDataGridView.Location = new System.Drawing.Point(6, 124);
            this.InfluentFactorsDataGridView.Name = "InfluentFactorsDataGridView";
            this.InfluentFactorsDataGridView.RowHeadersWidth = 51;
            this.InfluentFactorsDataGridView.RowTemplate.Height = 24;
            this.InfluentFactorsDataGridView.Size = new System.Drawing.Size(566, 164);
            this.InfluentFactorsDataGridView.TabIndex = 11;
            // 
            // ClearAllFactorsFromGridButton
            // 
            this.ClearAllFactorsFromGridButton.Location = new System.Drawing.Point(355, 84);
            this.ClearAllFactorsFromGridButton.Name = "ClearAllFactorsFromGridButton";
            this.ClearAllFactorsFromGridButton.Size = new System.Drawing.Size(119, 30);
            this.ClearAllFactorsFromGridButton.TabIndex = 10;
            this.ClearAllFactorsFromGridButton.Text = "Очистить";
            this.ClearAllFactorsFromGridButton.UseVisualStyleBackColor = true;
            // 
            // RemoveFactorFromGridButton
            // 
            this.RemoveFactorFromGridButton.Location = new System.Drawing.Point(230, 84);
            this.RemoveFactorFromGridButton.Name = "RemoveFactorFromGridButton";
            this.RemoveFactorFromGridButton.Size = new System.Drawing.Size(119, 30);
            this.RemoveFactorFromGridButton.TabIndex = 9;
            this.RemoveFactorFromGridButton.Text = "Удалить";
            this.RemoveFactorFromGridButton.UseVisualStyleBackColor = true;
            // 
            // AddFactorToGridButton
            // 
            this.AddFactorToGridButton.Location = new System.Drawing.Point(105, 84);
            this.AddFactorToGridButton.Name = "AddFactorToGridButton";
            this.AddFactorToGridButton.Size = new System.Drawing.Size(119, 30);
            this.AddFactorToGridButton.TabIndex = 8;
            this.AddFactorToGridButton.Text = "Добавить";
            this.AddFactorToGridButton.UseVisualStyleBackColor = true;
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
            this.InfluentFactorMax.Size = new System.Drawing.Size(74, 17);
            this.InfluentFactorMax.TabIndex = 6;
            this.InfluentFactorMax.Text = "Максимум";
            // 
            // InfluentFactorMinTextBox
            // 
            this.InfluentFactorMinTextBox.Location = new System.Drawing.Point(342, 50);
            this.InfluentFactorMinTextBox.Name = "InfluentFactorMinTextBox";
            this.InfluentFactorMinTextBox.Size = new System.Drawing.Size(113, 22);
            this.InfluentFactorMinTextBox.TabIndex = 5;
            // 
            // InfluentFactorMinLabel
            // 
            this.InfluentFactorMinLabel.AutoSize = true;
            this.InfluentFactorMinLabel.Location = new System.Drawing.Point(339, 28);
            this.InfluentFactorMinLabel.Name = "InfluentFactorMinLabel";
            this.InfluentFactorMinLabel.Size = new System.Drawing.Size(68, 17);
            this.InfluentFactorMinLabel.TabIndex = 4;
            this.InfluentFactorMinLabel.Text = "Минимум";
            // 
            // InfluentFactorNumTextBox
            // 
            this.InfluentFactorNumTextBox.Location = new System.Drawing.Point(195, 50);
            this.InfluentFactorNumTextBox.Name = "InfluentFactorNumTextBox";
            this.InfluentFactorNumTextBox.Size = new System.Drawing.Size(141, 22);
            this.InfluentFactorNumTextBox.TabIndex = 3;
            // 
            // InfluentFactorNumLabel
            // 
            this.InfluentFactorNumLabel.AutoSize = true;
            this.InfluentFactorNumLabel.Location = new System.Drawing.Point(192, 28);
            this.InfluentFactorNumLabel.Name = "InfluentFactorNumLabel";
            this.InfluentFactorNumLabel.Size = new System.Drawing.Size(51, 17);
            this.InfluentFactorNumLabel.TabIndex = 2;
            this.InfluentFactorNumLabel.Text = "Номер";
            // 
            // FactorTypeComboBox
            // 
            this.FactorTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FactorTypeComboBox.FormattingEnabled = true;
            this.FactorTypeComboBox.Items.AddRange(new object[] {
            "Напряжение",
            "Переток",
            "Нагрузка"});
            this.FactorTypeComboBox.Location = new System.Drawing.Point(9, 50);
            this.FactorTypeComboBox.Name = "FactorTypeComboBox";
            this.FactorTypeComboBox.Size = new System.Drawing.Size(180, 24);
            this.FactorTypeComboBox.TabIndex = 1;
            // 
            // FactorTypeLabel
            // 
            this.FactorTypeLabel.AutoSize = true;
            this.FactorTypeLabel.Location = new System.Drawing.Point(6, 30);
            this.FactorTypeLabel.Name = "FactorTypeLabel";
            this.FactorTypeLabel.Size = new System.Drawing.Size(94, 17);
            this.FactorTypeLabel.TabIndex = 0;
            this.FactorTypeLabel.Text = "Тип фактора";
            // 
            // TabPageFiles
            // 
            this.TabPageFiles.Controls.Add(this.DBConnectionButton);
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
            this.TabPageFiles.Size = new System.Drawing.Size(595, 601);
            this.TabPageFiles.TabIndex = 0;
            this.TabPageFiles.Text = "Файлы";
            this.TabPageFiles.UseVisualStyleBackColor = true;
            // 
            // DBConnectionButton
            // 
            this.DBConnectionButton.Location = new System.Drawing.Point(27, 426);
            this.DBConnectionButton.Name = "DBConnectionButton";
            this.DBConnectionButton.Size = new System.Drawing.Size(200, 30);
            this.DBConnectionButton.TabIndex = 13;
            this.DBConnectionButton.Text = "Подключение к БД";
            this.DBConnectionButton.UseVisualStyleBackColor = true;
            // 
            // TrajectoryGroupBox
            // 
            this.TrajectoryGroupBox.Controls.Add(this.TrajectorySettingsButton);
            this.TrajectoryGroupBox.Controls.Add(this.LoadTrajectoryTextBox);
            this.TrajectoryGroupBox.Controls.Add(this.FromFileRadioButton);
            this.TrajectoryGroupBox.Controls.Add(this.LoadTrajectoryButton);
            this.TrajectoryGroupBox.Controls.Add(this.ByHandRadioButton);
            this.TrajectoryGroupBox.Controls.Add(this.TrajectorySettingsLabel);
            this.TrajectoryGroupBox.Location = new System.Drawing.Point(18, 299);
            this.TrajectoryGroupBox.Name = "TrajectoryGroupBox";
            this.TrajectoryGroupBox.Size = new System.Drawing.Size(554, 111);
            this.TrajectoryGroupBox.TabIndex = 12;
            this.TrajectoryGroupBox.TabStop = false;
            this.TrajectoryGroupBox.Text = "Траектория утяжеления";
            // 
            // TrajectorySettingsButton
            // 
            this.TrajectorySettingsButton.Location = new System.Drawing.Point(9, 66);
            this.TrajectorySettingsButton.Name = "TrajectorySettingsButton";
            this.TrajectorySettingsButton.Size = new System.Drawing.Size(200, 30);
            this.TrajectorySettingsButton.TabIndex = 14;
            this.TrajectorySettingsButton.Text = "Настройка траектории";
            this.TrajectorySettingsButton.UseVisualStyleBackColor = true;
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
            this.FromFileRadioButton.Size = new System.Drawing.Size(91, 21);
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
            // 
            // ByHandRadioButton
            // 
            this.ByHandRadioButton.AutoSize = true;
            this.ByHandRadioButton.Location = new System.Drawing.Point(275, 33);
            this.ByHandRadioButton.Name = "ByHandRadioButton";
            this.ByHandRadioButton.Size = new System.Drawing.Size(84, 21);
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
            this.TrajectorySettingsLabel.Size = new System.Drawing.Size(138, 17);
            this.TrajectorySettingsLabel.TabIndex = 13;
            this.TrajectorySettingsLabel.Text = "Задать траекторию";
            // 
            // LoadDfwTextBox
            // 
            this.LoadDfwTextBox.Location = new System.Drawing.Point(18, 256);
            this.LoadDfwTextBox.Name = "LoadDfwTextBox";
            this.LoadDfwTextBox.Size = new System.Drawing.Size(437, 22);
            this.LoadDfwTextBox.TabIndex = 11;
            // 
            // LabelDfwPath
            // 
            this.LabelDfwPath.AutoSize = true;
            this.LabelDfwPath.Location = new System.Drawing.Point(15, 226);
            this.LabelDfwPath.Name = "LabelDfwPath";
            this.LabelDfwPath.Size = new System.Drawing.Size(161, 17);
            this.LabelDfwPath.TabIndex = 10;
            this.LabelDfwPath.Text = "Файл автоматики (dfw)";
            // 
            // LoadDfwButton
            // 
            this.LoadDfwButton.Location = new System.Drawing.Point(471, 252);
            this.LoadDfwButton.Name = "LoadDfwButton";
            this.LoadDfwButton.Size = new System.Drawing.Size(91, 30);
            this.LoadDfwButton.TabIndex = 9;
            this.LoadDfwButton.Text = "Загрузить";
            this.LoadDfwButton.UseVisualStyleBackColor = true;
            // 
            // LoadSchTextBox
            // 
            this.LoadSchTextBox.Location = new System.Drawing.Point(18, 184);
            this.LoadSchTextBox.Name = "LoadSchTextBox";
            this.LoadSchTextBox.Size = new System.Drawing.Size(437, 22);
            this.LoadSchTextBox.TabIndex = 8;
            // 
            // LabelSchPath
            // 
            this.LabelSchPath.AutoSize = true;
            this.LabelSchPath.Location = new System.Drawing.Point(15, 154);
            this.LabelSchPath.Name = "LabelSchPath";
            this.LabelSchPath.Size = new System.Drawing.Size(140, 17);
            this.LabelSchPath.TabIndex = 7;
            this.LabelSchPath.Text = "Файл сечения (sch)";
            // 
            // LoadSchButton
            // 
            this.LoadSchButton.Location = new System.Drawing.Point(471, 180);
            this.LoadSchButton.Name = "LoadSchButton";
            this.LoadSchButton.Size = new System.Drawing.Size(91, 30);
            this.LoadSchButton.TabIndex = 6;
            this.LoadSchButton.Text = "Загрузить";
            this.LoadSchButton.UseVisualStyleBackColor = true;
            // 
            // LoadRstTextBox
            // 
            this.LoadRstTextBox.Location = new System.Drawing.Point(18, 112);
            this.LoadRstTextBox.Name = "LoadRstTextBox";
            this.LoadRstTextBox.Size = new System.Drawing.Size(437, 22);
            this.LoadRstTextBox.TabIndex = 5;
            // 
            // LabelRstPath
            // 
            this.LabelRstPath.AutoSize = true;
            this.LabelRstPath.Location = new System.Drawing.Point(15, 82);
            this.LabelRstPath.Name = "LabelRstPath";
            this.LabelRstPath.Size = new System.Drawing.Size(143, 17);
            this.LabelRstPath.TabIndex = 4;
            this.LabelRstPath.Text = "Файл динамики (rst)";
            // 
            // LoadRstButton
            // 
            this.LoadRstButton.Location = new System.Drawing.Point(471, 108);
            this.LoadRstButton.Name = "LoadRstButton";
            this.LoadRstButton.Size = new System.Drawing.Size(91, 30);
            this.LoadRstButton.TabIndex = 3;
            this.LoadRstButton.Text = "Загрузить";
            this.LoadRstButton.UseVisualStyleBackColor = true;
            // 
            // LoadScnTextBox
            // 
            this.LoadScnTextBox.Location = new System.Drawing.Point(18, 45);
            this.LoadScnTextBox.Name = "LoadScnTextBox";
            this.LoadScnTextBox.Size = new System.Drawing.Size(437, 22);
            this.LoadScnTextBox.TabIndex = 2;
            // 
            // LabelScnPath
            // 
            this.LabelScnPath.AutoSize = true;
            this.LabelScnPath.Location = new System.Drawing.Point(15, 15);
            this.LabelScnPath.Name = "LabelScnPath";
            this.LabelScnPath.Size = new System.Drawing.Size(251, 17);
            this.LabelScnPath.TabIndex = 1;
            this.LabelScnPath.Text = "Путь к каталогу со сценариями (scn)";
            // 
            // LoadScnButton
            // 
            this.LoadScnButton.Location = new System.Drawing.Point(471, 41);
            this.LoadScnButton.Name = "LoadScnButton";
            this.LoadScnButton.Size = new System.Drawing.Size(91, 30);
            this.LoadScnButton.TabIndex = 0;
            this.LoadScnButton.Text = "Загрузить";
            this.LoadScnButton.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageFiles);
            this.TabControl.Controls.Add(this.TabPageCalc);
            this.TabControl.Controls.Add(this.TabPageInfo);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(603, 647);
            this.TabControl.TabIndex = 0;
            // 
            // TabPageInfo
            // 
            this.TabPageInfo.Controls.Add(this.label1);
            this.TabPageInfo.Location = new System.Drawing.Point(4, 25);
            this.TabPageInfo.Name = "TabPageInfo";
            this.TabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageInfo.Size = new System.Drawing.Size(595, 601);
            this.TabPageInfo.TabIndex = 2;
            this.TabPageInfo.Text = "О программе";
            this.TabPageInfo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "продам гараж";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "Остановить расчёт";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 229);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(566, 27);
            this.progressBar1.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(453, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "Сохранить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(627, 671);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Расчёты ДУ с коррекцией траектории утяжеления";
            this.TabPageCalc.ResumeLayout(false);
            this.TransientStabilityAnalysisGroupBox.ResumeLayout(false);
            this.InfluentFactorsGroupBox.ResumeLayout(false);
            this.InfluentFactorsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfluentFactorsDataGridView)).EndInit();
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
        private System.Windows.Forms.TextBox LoadScnTextBox;
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
        private System.Windows.Forms.Button DBConnectionButton;
        private System.Windows.Forms.Button TrajectorySettingsButton;
        private System.Windows.Forms.GroupBox InfluentFactorsGroupBox;
        private System.Windows.Forms.ComboBox FactorTypeComboBox;
        private System.Windows.Forms.Label FactorTypeLabel;
        private System.Windows.Forms.Label InfluentFactorNumLabel;
        private System.Windows.Forms.TextBox InfluentFactorMaxTextbox;
        private System.Windows.Forms.Label InfluentFactorMax;
        private System.Windows.Forms.TextBox InfluentFactorMinTextBox;
        private System.Windows.Forms.Label InfluentFactorMinLabel;
        private System.Windows.Forms.TextBox InfluentFactorNumTextBox;
        private System.Windows.Forms.Button ClearAllFactorsFromGridButton;
        private System.Windows.Forms.Button RemoveFactorFromGridButton;
        private System.Windows.Forms.Button AddFactorToGridButton;
        private System.Windows.Forms.DataGridView InfluentFactorsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox TransientStabilityAnalysisGroupBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox ProtocolListBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

