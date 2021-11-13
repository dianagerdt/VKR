
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
            this.ChooseGeneratorForTrajectoryButton = new System.Windows.Forms.Button();
            this.RemoveGeneratorFromTrajectoryButton = new System.Windows.Forms.Button();
            this.SetTrajectorySettingsButton = new System.Windows.Forms.Button();
            this.TrajectoryCancelButton = new System.Windows.Forms.Button();
            this.SchInfluentFactorComboBox = new System.Windows.Forms.ComboBox();
            this.SchInfluentFactorLabel = new System.Windows.Forms.Label();
            this.ChooseGenOfResearchingSection = new System.Windows.Forms.Button();
            this.ChooseGenOfInfluentSection = new System.Windows.Forms.Button();
            this.ClearDataGridButton = new System.Windows.Forms.Button();
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
            this.TrajectoryGeneratorsLabel.Location = new System.Drawing.Point(14, 98);
            this.TrajectoryGeneratorsLabel.Name = "TrajectoryGeneratorsLabel";
            this.TrajectoryGeneratorsLabel.Size = new System.Drawing.Size(131, 17);
            this.TrajectoryGeneratorsLabel.TabIndex = 2;
            this.TrajectoryGeneratorsLabel.Text = "Номер генератора";
            // 
            // ChosenGeneratorsLabel
            // 
            this.ChosenGeneratorsLabel.AutoSize = true;
            this.ChosenGeneratorsLabel.Location = new System.Drawing.Point(368, 138);
            this.ChosenGeneratorsLabel.Name = "ChosenGeneratorsLabel";
            this.ChosenGeneratorsLabel.Size = new System.Drawing.Size(328, 17);
            this.ChosenGeneratorsLabel.TabIndex = 3;
            this.ChosenGeneratorsLabel.Text = "Приращения генераторов исследуемой станции";
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
            this.TrajectoryGeneratorsSearchTextBox.Location = new System.Drawing.Point(17, 130);
            this.TrajectoryGeneratorsSearchTextBox.Name = "TrajectoryGeneratorsSearchTextBox";
            this.TrajectoryGeneratorsSearchTextBox.Size = new System.Drawing.Size(167, 22);
            this.TrajectoryGeneratorsSearchTextBox.TabIndex = 6;
            // 
            // TrajectoryGeneratorsSearchButton
            // 
            this.TrajectoryGeneratorsSearchButton.Location = new System.Drawing.Point(190, 128);
            this.TrajectoryGeneratorsSearchButton.Name = "TrajectoryGeneratorsSearchButton";
            this.TrajectoryGeneratorsSearchButton.Size = new System.Drawing.Size(97, 27);
            this.TrajectoryGeneratorsSearchButton.TabIndex = 7;
            this.TrajectoryGeneratorsSearchButton.Text = "Найти";
            this.TrajectoryGeneratorsSearchButton.UseVisualStyleBackColor = true;
            // 
            // GeneratorsFromFileListBox
            // 
            this.GeneratorsFromFileListBox.FormattingEnabled = true;
            this.GeneratorsFromFileListBox.ItemHeight = 16;
            this.GeneratorsFromFileListBox.Location = new System.Drawing.Point(17, 173);
            this.GeneratorsFromFileListBox.Name = "GeneratorsFromFileListBox";
            this.GeneratorsFromFileListBox.Size = new System.Drawing.Size(296, 196);
            this.GeneratorsFromFileListBox.TabIndex = 8;
            // 
            // ChosenGeneratorsForTrajectoryData
            // 
            this.ChosenGeneratorsForTrajectoryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChosenGeneratorsForTrajectoryData.Location = new System.Drawing.Point(371, 173);
            this.ChosenGeneratorsForTrajectoryData.Name = "ChosenGeneratorsForTrajectoryData";
            this.ChosenGeneratorsForTrajectoryData.RowHeadersWidth = 51;
            this.ChosenGeneratorsForTrajectoryData.RowTemplate.Height = 24;
            this.ChosenGeneratorsForTrajectoryData.Size = new System.Drawing.Size(419, 196);
            this.ChosenGeneratorsForTrajectoryData.TabIndex = 9;
            this.ChosenGeneratorsForTrajectoryData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ChosenGeneratorsForTrajectoryData_DataError);
            // 
            // ChooseGeneratorForTrajectoryButton
            // 
            this.ChooseGeneratorForTrajectoryButton.Location = new System.Drawing.Point(319, 242);
            this.ChooseGeneratorForTrajectoryButton.Name = "ChooseGeneratorForTrajectoryButton";
            this.ChooseGeneratorForTrajectoryButton.Size = new System.Drawing.Size(42, 23);
            this.ChooseGeneratorForTrajectoryButton.TabIndex = 10;
            this.ChooseGeneratorForTrajectoryButton.Text = ">>";
            this.ChooseGeneratorForTrajectoryButton.UseVisualStyleBackColor = true;
            // 
            // RemoveGeneratorFromTrajectoryButton
            // 
            this.RemoveGeneratorFromTrajectoryButton.Location = new System.Drawing.Point(319, 283);
            this.RemoveGeneratorFromTrajectoryButton.Name = "RemoveGeneratorFromTrajectoryButton";
            this.RemoveGeneratorFromTrajectoryButton.Size = new System.Drawing.Size(42, 23);
            this.RemoveGeneratorFromTrajectoryButton.TabIndex = 11;
            this.RemoveGeneratorFromTrajectoryButton.Text = "<<";
            this.RemoveGeneratorFromTrajectoryButton.UseVisualStyleBackColor = true;
            // 
            // SetTrajectorySettingsButton
            // 
            this.SetTrajectorySettingsButton.Location = new System.Drawing.Point(371, 379);
            this.SetTrajectorySettingsButton.Name = "SetTrajectorySettingsButton";
            this.SetTrajectorySettingsButton.Size = new System.Drawing.Size(119, 27);
            this.SetTrajectorySettingsButton.TabIndex = 12;
            this.SetTrajectorySettingsButton.Text = "ОК";
            this.SetTrajectorySettingsButton.UseVisualStyleBackColor = true;
            this.SetTrajectorySettingsButton.Click += new System.EventHandler(this.SetTrajectorySettingsButton_Click);
            // 
            // TrajectoryCancelButton
            // 
            this.TrajectoryCancelButton.Location = new System.Drawing.Point(671, 379);
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
            this.ChooseGenOfResearchingSection.Location = new System.Drawing.Point(17, 379);
            this.ChooseGenOfResearchingSection.Name = "ChooseGenOfResearchingSection";
            this.ChooseGenOfResearchingSection.Size = new System.Drawing.Size(296, 27);
            this.ChooseGenOfResearchingSection.TabIndex = 16;
            this.ChooseGenOfResearchingSection.Text = "Генераторы исследуемой станции";
            this.ChooseGenOfResearchingSection.UseVisualStyleBackColor = true;
            // 
            // ChooseGenOfInfluentSection
            // 
            this.ChooseGenOfInfluentSection.Location = new System.Drawing.Point(17, 379);
            this.ChooseGenOfInfluentSection.Name = "ChooseGenOfInfluentSection";
            this.ChooseGenOfInfluentSection.Size = new System.Drawing.Size(296, 27);
            this.ChooseGenOfInfluentSection.TabIndex = 17;
            this.ChooseGenOfInfluentSection.Text = "Генераторы для поддержания перетока";
            this.ChooseGenOfInfluentSection.UseVisualStyleBackColor = true;
            // 
            // ClearDataGridButton
            // 
            this.ClearDataGridButton.Location = new System.Drawing.Point(496, 379);
            this.ClearDataGridButton.Name = "ClearDataGridButton";
            this.ClearDataGridButton.Size = new System.Drawing.Size(119, 27);
            this.ClearDataGridButton.TabIndex = 18;
            this.ClearDataGridButton.Text = "Очистить";
            this.ClearDataGridButton.UseVisualStyleBackColor = true;
            this.ClearDataGridButton.Click += new System.EventHandler(this.ClearDataGridButton_Click);
            // 
            // TrajectorySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 418);
            this.Controls.Add(this.ClearDataGridButton);
            this.Controls.Add(this.ChooseGenOfInfluentSection);
            this.Controls.Add(this.ChooseGenOfResearchingSection);
            this.Controls.Add(this.SchInfluentFactorComboBox);
            this.Controls.Add(this.SchInfluentFactorLabel);
            this.Controls.Add(this.TrajectoryCancelButton);
            this.Controls.Add(this.SetTrajectorySettingsButton);
            this.Controls.Add(this.RemoveGeneratorFromTrajectoryButton);
            this.Controls.Add(this.ChooseGeneratorForTrajectoryButton);
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
        private System.Windows.Forms.Button ChooseGeneratorForTrajectoryButton;
        private System.Windows.Forms.Button RemoveGeneratorFromTrajectoryButton;
        private System.Windows.Forms.Button SetTrajectorySettingsButton;
        private System.Windows.Forms.Button TrajectoryCancelButton;
        private System.Windows.Forms.ComboBox SchInfluentFactorComboBox;
        private System.Windows.Forms.Label SchInfluentFactorLabel;
        private System.Windows.Forms.Button ChooseGenOfResearchingSection;
        private System.Windows.Forms.Button ChooseGenOfInfluentSection;
        private System.Windows.Forms.Button ClearDataGridButton;
    }
}