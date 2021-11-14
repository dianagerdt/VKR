
namespace RustabBot_v1._0
{
    partial class TrajectorySettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrajectorySettingsForm));
            this.GeneratorTypeLabel = new System.Windows.Forms.Label();
            this.ResearchingSchLabel = new System.Windows.Forms.Label();
            this.TrajectoryGeneratorsLabel = new System.Windows.Forms.Label();
            this.ChosenGeneratorsLabel = new System.Windows.Forms.Label();
            this.GeneratorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ResearchingSchComboBox = new System.Windows.Forms.ComboBox();
            this.TrajectoryGeneratorsSearchTextBox = new System.Windows.Forms.TextBox();
            this.TrajectoryGeneratorsSearchButton = new System.Windows.Forms.Button();
            this.GeneratorsFromFileListBox = new System.Windows.Forms.ListBox();
            this.ChosenGeneratorsForTrajectoryData = new System.Windows.Forms.DataGridView();
            this.SetTrajectorySettingsButton = new System.Windows.Forms.Button();
            this.TrajectoryCancelButton = new System.Windows.Forms.Button();
            this.SchInfluentFactorComboBox = new System.Windows.Forms.ComboBox();
            this.SchInfluentFactorLabel = new System.Windows.Forms.Label();
            this.ChooseGenOfResearchingSection = new System.Windows.Forms.Button();
            this.ChooseGenOfInfluentSection = new System.Windows.Forms.Button();
            this.ClearDataGridButton = new System.Windows.Forms.Button();
            this.DropSettings = new System.Windows.Forms.Button();
            this.AddGensToTrajectory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChosenGeneratorsForTrajectoryData)).BeginInit();
            this.SuspendLayout();
            // 
            // GeneratorTypeLabel
            // 
            this.GeneratorTypeLabel.AutoSize = true;
            this.GeneratorTypeLabel.Location = new System.Drawing.Point(14, 14);
            this.GeneratorTypeLabel.Name = "GeneratorTypeLabel";
            this.GeneratorTypeLabel.Size = new System.Drawing.Size(138, 17);
            this.GeneratorTypeLabel.TabIndex = 0;
            this.GeneratorTypeLabel.Text = "Выбор генераторов";
            // 
            // ResearchingSchLabel
            // 
            this.ResearchingSchLabel.AutoSize = true;
            this.ResearchingSchLabel.Location = new System.Drawing.Point(14, 56);
            this.ResearchingSchLabel.Name = "ResearchingSchLabel";
            this.ResearchingSchLabel.Size = new System.Drawing.Size(155, 17);
            this.ResearchingSchLabel.TabIndex = 1;
            this.ResearchingSchLabel.Text = "Исследуемое сечение";
            // 
            // TrajectoryGeneratorsLabel
            // 
            this.TrajectoryGeneratorsLabel.AutoSize = true;
            this.TrajectoryGeneratorsLabel.Location = new System.Drawing.Point(14, 94);
            this.TrajectoryGeneratorsLabel.Name = "TrajectoryGeneratorsLabel";
            this.TrajectoryGeneratorsLabel.Size = new System.Drawing.Size(131, 17);
            this.TrajectoryGeneratorsLabel.TabIndex = 2;
            this.TrajectoryGeneratorsLabel.Text = "Номер генератора";
            // 
            // ChosenGeneratorsLabel
            // 
            this.ChosenGeneratorsLabel.AutoSize = true;
            this.ChosenGeneratorsLabel.Location = new System.Drawing.Point(510, 151);
            this.ChosenGeneratorsLabel.Name = "ChosenGeneratorsLabel";
            this.ChosenGeneratorsLabel.Size = new System.Drawing.Size(170, 17);
            this.ChosenGeneratorsLabel.TabIndex = 3;
            this.ChosenGeneratorsLabel.Text = "Траектория утяжеления";
            // 
            // GeneratorTypeComboBox
            // 
            this.GeneratorTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GeneratorTypeComboBox.FormattingEnabled = true;
            this.GeneratorTypeComboBox.Items.AddRange(new object[] {
            "исследуемой станции",
            "влияющей станции"});
            this.GeneratorTypeComboBox.Location = new System.Drawing.Point(227, 11);
            this.GeneratorTypeComboBox.Name = "GeneratorTypeComboBox";
            this.GeneratorTypeComboBox.Size = new System.Drawing.Size(284, 24);
            this.GeneratorTypeComboBox.TabIndex = 4;
            this.GeneratorTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.GeneratorTypeComboBox_SelectedIndexChanged);
            // 
            // ResearchingSchComboBox
            // 
            this.ResearchingSchComboBox.FormattingEnabled = true;
            this.ResearchingSchComboBox.Location = new System.Drawing.Point(227, 53);
            this.ResearchingSchComboBox.Name = "ResearchingSchComboBox";
            this.ResearchingSchComboBox.Size = new System.Drawing.Size(284, 24);
            this.ResearchingSchComboBox.TabIndex = 5;
            this.ResearchingSchComboBox.SelectedIndexChanged += new System.EventHandler(this.ResearchingSchComboBox_SelectedIndexChanged);
            // 
            // TrajectoryGeneratorsSearchTextBox
            // 
            this.TrajectoryGeneratorsSearchTextBox.Location = new System.Drawing.Point(120, 120);
            this.TrajectoryGeneratorsSearchTextBox.Name = "TrajectoryGeneratorsSearchTextBox";
            this.TrajectoryGeneratorsSearchTextBox.Size = new System.Drawing.Size(215, 22);
            this.TrajectoryGeneratorsSearchTextBox.TabIndex = 6;
            // 
            // TrajectoryGeneratorsSearchButton
            // 
            this.TrajectoryGeneratorsSearchButton.Location = new System.Drawing.Point(17, 118);
            this.TrajectoryGeneratorsSearchButton.Name = "TrajectoryGeneratorsSearchButton";
            this.TrajectoryGeneratorsSearchButton.Size = new System.Drawing.Size(97, 27);
            this.TrajectoryGeneratorsSearchButton.TabIndex = 7;
            this.TrajectoryGeneratorsSearchButton.Text = "Найти";
            this.TrajectoryGeneratorsSearchButton.UseVisualStyleBackColor = true;
            this.TrajectoryGeneratorsSearchButton.Click += new System.EventHandler(this.TrajectoryGeneratorsSearchButton_Click);
            // 
            // GeneratorsFromFileListBox
            // 
            this.GeneratorsFromFileListBox.FormattingEnabled = true;
            this.GeneratorsFromFileListBox.ItemHeight = 16;
            this.GeneratorsFromFileListBox.Location = new System.Drawing.Point(17, 189);
            this.GeneratorsFromFileListBox.Name = "GeneratorsFromFileListBox";
            this.GeneratorsFromFileListBox.Size = new System.Drawing.Size(318, 180);
            this.GeneratorsFromFileListBox.TabIndex = 8;
            // 
            // ChosenGeneratorsForTrajectoryData
            // 
            this.ChosenGeneratorsForTrajectoryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChosenGeneratorsForTrajectoryData.Location = new System.Drawing.Point(356, 173);
            this.ChosenGeneratorsForTrajectoryData.Name = "ChosenGeneratorsForTrajectoryData";
            this.ChosenGeneratorsForTrajectoryData.RowHeadersWidth = 51;
            this.ChosenGeneratorsForTrajectoryData.RowTemplate.Height = 24;
            this.ChosenGeneratorsForTrajectoryData.Size = new System.Drawing.Size(463, 196);
            this.ChosenGeneratorsForTrajectoryData.TabIndex = 9;
            this.ChosenGeneratorsForTrajectoryData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ChosenGeneratorsForTrajectoryData_DataError);
            // 
            // SetTrajectorySettingsButton
            // 
            this.SetTrajectorySettingsButton.Location = new System.Drawing.Point(356, 379);
            this.SetTrajectorySettingsButton.Name = "SetTrajectorySettingsButton";
            this.SetTrajectorySettingsButton.Size = new System.Drawing.Size(119, 27);
            this.SetTrajectorySettingsButton.TabIndex = 12;
            this.SetTrajectorySettingsButton.Text = "ОК";
            this.SetTrajectorySettingsButton.UseVisualStyleBackColor = true;
            this.SetTrajectorySettingsButton.Click += new System.EventHandler(this.SetTrajectorySettingsButton_Click);
            // 
            // TrajectoryCancelButton
            // 
            this.TrajectoryCancelButton.Location = new System.Drawing.Point(700, 379);
            this.TrajectoryCancelButton.Name = "TrajectoryCancelButton";
            this.TrajectoryCancelButton.Size = new System.Drawing.Size(119, 27);
            this.TrajectoryCancelButton.TabIndex = 13;
            this.TrajectoryCancelButton.Text = "Отмена";
            this.TrajectoryCancelButton.UseVisualStyleBackColor = true;
            this.TrajectoryCancelButton.Click += new System.EventHandler(this.TrajectoryCancelButton_Click);
            // 
            // SchInfluentFactorComboBox
            // 
            this.SchInfluentFactorComboBox.FormattingEnabled = true;
            this.SchInfluentFactorComboBox.Location = new System.Drawing.Point(227, 53);
            this.SchInfluentFactorComboBox.Name = "SchInfluentFactorComboBox";
            this.SchInfluentFactorComboBox.Size = new System.Drawing.Size(284, 24);
            this.SchInfluentFactorComboBox.TabIndex = 15;
            this.SchInfluentFactorComboBox.SelectedIndexChanged += new System.EventHandler(this.SchInfluentFactorComboBox_SelectedIndexChanged);
            // 
            // SchInfluentFactorLabel
            // 
            this.SchInfluentFactorLabel.AutoSize = true;
            this.SchInfluentFactorLabel.Location = new System.Drawing.Point(14, 56);
            this.SchInfluentFactorLabel.Name = "SchInfluentFactorLabel";
            this.SchInfluentFactorLabel.Size = new System.Drawing.Size(191, 17);
            this.SchInfluentFactorLabel.TabIndex = 14;
            this.SchInfluentFactorLabel.Text = "Сечение-влияющий фактор";
            // 
            // ChooseGenOfResearchingSection
            // 
            this.ChooseGenOfResearchingSection.Location = new System.Drawing.Point(17, 151);
            this.ChooseGenOfResearchingSection.Name = "ChooseGenOfResearchingSection";
            this.ChooseGenOfResearchingSection.Size = new System.Drawing.Size(318, 27);
            this.ChooseGenOfResearchingSection.TabIndex = 16;
            this.ChooseGenOfResearchingSection.Text = "Генераторы исследуемой станции";
            this.ChooseGenOfResearchingSection.UseVisualStyleBackColor = true;
            this.ChooseGenOfResearchingSection.Click += new System.EventHandler(this.ChooseGenOfResearchingSection_Click);
            // 
            // ChooseGenOfInfluentSection
            // 
            this.ChooseGenOfInfluentSection.Location = new System.Drawing.Point(17, 151);
            this.ChooseGenOfInfluentSection.Name = "ChooseGenOfInfluentSection";
            this.ChooseGenOfInfluentSection.Size = new System.Drawing.Size(318, 27);
            this.ChooseGenOfInfluentSection.TabIndex = 17;
            this.ChooseGenOfInfluentSection.Text = "Генераторы для поддержания перетока";
            this.ChooseGenOfInfluentSection.UseVisualStyleBackColor = true;
            this.ChooseGenOfInfluentSection.Click += new System.EventHandler(this.ChooseGenOfInfluentSection_Click);
            // 
            // ClearDataGridButton
            // 
            this.ClearDataGridButton.Location = new System.Drawing.Point(481, 379);
            this.ClearDataGridButton.Name = "ClearDataGridButton";
            this.ClearDataGridButton.Size = new System.Drawing.Size(119, 27);
            this.ClearDataGridButton.TabIndex = 18;
            this.ClearDataGridButton.Text = "Очистить";
            this.ClearDataGridButton.UseVisualStyleBackColor = true;
            this.ClearDataGridButton.Click += new System.EventHandler(this.ClearDataGridButton_Click);
            // 
            // DropSettings
            // 
            this.DropSettings.Location = new System.Drawing.Point(214, 379);
            this.DropSettings.Name = "DropSettings";
            this.DropSettings.Size = new System.Drawing.Size(121, 27);
            this.DropSettings.TabIndex = 19;
            this.DropSettings.Text = "Сбросить";
            this.DropSettings.UseVisualStyleBackColor = true;
            this.DropSettings.Click += new System.EventHandler(this.DropSettings_Click);
            // 
            // AddGensToTrajectory
            // 
            this.AddGensToTrajectory.Location = new System.Drawing.Point(17, 379);
            this.AddGensToTrajectory.Name = "AddGensToTrajectory";
            this.AddGensToTrajectory.Size = new System.Drawing.Size(191, 27);
            this.AddGensToTrajectory.TabIndex = 20;
            this.AddGensToTrajectory.Text = "Добавить в траекторию";
            this.AddGensToTrajectory.UseVisualStyleBackColor = true;
            this.AddGensToTrajectory.Click += new System.EventHandler(this.AddGensToTrajectory_Click);
            // 
            // TrajectorySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 418);
            this.Controls.Add(this.AddGensToTrajectory);
            this.Controls.Add(this.DropSettings);
            this.Controls.Add(this.ClearDataGridButton);
            this.Controls.Add(this.ChooseGenOfInfluentSection);
            this.Controls.Add(this.ChooseGenOfResearchingSection);
            this.Controls.Add(this.SchInfluentFactorComboBox);
            this.Controls.Add(this.SchInfluentFactorLabel);
            this.Controls.Add(this.TrajectoryCancelButton);
            this.Controls.Add(this.SetTrajectorySettingsButton);
            this.Controls.Add(this.ChosenGeneratorsForTrajectoryData);
            this.Controls.Add(this.GeneratorsFromFileListBox);
            this.Controls.Add(this.TrajectoryGeneratorsSearchButton);
            this.Controls.Add(this.TrajectoryGeneratorsSearchTextBox);
            this.Controls.Add(this.ResearchingSchComboBox);
            this.Controls.Add(this.GeneratorTypeComboBox);
            this.Controls.Add(this.ChosenGeneratorsLabel);
            this.Controls.Add(this.TrajectoryGeneratorsLabel);
            this.Controls.Add(this.ResearchingSchLabel);
            this.Controls.Add(this.GeneratorTypeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrajectorySettingsForm";
            this.Text = "Настройки траектории";
            this.Load += new System.EventHandler(this.TrajectorySettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChosenGeneratorsForTrajectoryData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GeneratorTypeLabel;
        private System.Windows.Forms.Label ResearchingSchLabel;
        private System.Windows.Forms.Label TrajectoryGeneratorsLabel;
        private System.Windows.Forms.Label ChosenGeneratorsLabel;
        private System.Windows.Forms.ComboBox GeneratorTypeComboBox;
        private System.Windows.Forms.ComboBox ResearchingSchComboBox;
        private System.Windows.Forms.TextBox TrajectoryGeneratorsSearchTextBox;
        private System.Windows.Forms.Button TrajectoryGeneratorsSearchButton;
        private System.Windows.Forms.ListBox GeneratorsFromFileListBox;
        private System.Windows.Forms.DataGridView ChosenGeneratorsForTrajectoryData;
        private System.Windows.Forms.Button SetTrajectorySettingsButton;
        private System.Windows.Forms.Button TrajectoryCancelButton;
        private System.Windows.Forms.ComboBox SchInfluentFactorComboBox;
        private System.Windows.Forms.Label SchInfluentFactorLabel;
        private System.Windows.Forms.Button ChooseGenOfResearchingSection;
        private System.Windows.Forms.Button ChooseGenOfInfluentSection;
        private System.Windows.Forms.Button ClearDataGridButton;
        private System.Windows.Forms.Button DropSettings;
        private System.Windows.Forms.Button AddGensToTrajectory;
    }
}