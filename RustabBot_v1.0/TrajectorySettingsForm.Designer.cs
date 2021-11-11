
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
            this.MakeTrajectoryByHandButton = new System.Windows.Forms.Button();
            this.TrajectoryCancelButton = new System.Windows.Forms.Button();
            this.SchInfluentFactorComboBox = new System.Windows.Forms.ComboBox();
            this.SchInfluentFactorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChosenGeneratorsForTrajectoryData)).BeginInit();
            this.SuspendLayout();
            // 
            // GeneratorTypeLabel
            // 
            this.GeneratorTypeLabel.AutoSize = true;
            this.GeneratorTypeLabel.Location = new System.Drawing.Point(24, 23);
            this.GeneratorTypeLabel.Name = "GeneratorTypeLabel";
            this.GeneratorTypeLabel.Size = new System.Drawing.Size(138, 17);
            this.GeneratorTypeLabel.TabIndex = 0;
            this.GeneratorTypeLabel.Text = "Выбор генераторов";
            // 
            // ResearchingSchLabel
            // 
            this.ResearchingSchLabel.AutoSize = true;
            this.ResearchingSchLabel.Location = new System.Drawing.Point(24, 65);
            this.ResearchingSchLabel.Name = "ResearchingSchLabel";
            this.ResearchingSchLabel.Size = new System.Drawing.Size(155, 17);
            this.ResearchingSchLabel.TabIndex = 1;
            this.ResearchingSchLabel.Text = "Исследуемое сечение";
            // 
            // TrajectoryGeneratorsLabel
            // 
            this.TrajectoryGeneratorsLabel.AutoSize = true;
            this.TrajectoryGeneratorsLabel.Location = new System.Drawing.Point(24, 107);
            this.TrajectoryGeneratorsLabel.Name = "TrajectoryGeneratorsLabel";
            this.TrajectoryGeneratorsLabel.Size = new System.Drawing.Size(170, 17);
            this.TrajectoryGeneratorsLabel.TabIndex = 2;
            this.TrajectoryGeneratorsLabel.Text = "Генераторы траектории";
            // 
            // ChosenGeneratorsLabel
            // 
            this.ChosenGeneratorsLabel.AutoSize = true;
            this.ChosenGeneratorsLabel.Location = new System.Drawing.Point(370, 142);
            this.ChosenGeneratorsLabel.Name = "ChosenGeneratorsLabel";
            this.ChosenGeneratorsLabel.Size = new System.Drawing.Size(151, 17);
            this.ChosenGeneratorsLabel.TabIndex = 3;
            this.ChosenGeneratorsLabel.Text = "Выбраны генераторы";
            // 
            // GeneratorTypeComboBox
            // 
            this.GeneratorTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GeneratorTypeComboBox.FormattingEnabled = true;
            this.GeneratorTypeComboBox.Items.AddRange(new object[] {
            "исследуемой станции",
            "влияющей станции"});
            this.GeneratorTypeComboBox.Location = new System.Drawing.Point(237, 20);
            this.GeneratorTypeComboBox.Name = "GeneratorTypeComboBox";
            this.GeneratorTypeComboBox.Size = new System.Drawing.Size(284, 24);
            this.GeneratorTypeComboBox.TabIndex = 4;
            this.GeneratorTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.GeneratorTypeComboBox_SelectedIndexChanged);
            // 
            // ResearchingSchComboBox
            // 
            this.ResearchingSchComboBox.FormattingEnabled = true;
            this.ResearchingSchComboBox.Location = new System.Drawing.Point(237, 62);
            this.ResearchingSchComboBox.Name = "ResearchingSchComboBox";
            this.ResearchingSchComboBox.Size = new System.Drawing.Size(284, 24);
            this.ResearchingSchComboBox.TabIndex = 5;
            // 
            // TrajectoryGeneratorsSearchTextBox
            // 
            this.TrajectoryGeneratorsSearchTextBox.Location = new System.Drawing.Point(27, 139);
            this.TrajectoryGeneratorsSearchTextBox.Name = "TrajectoryGeneratorsSearchTextBox";
            this.TrajectoryGeneratorsSearchTextBox.Size = new System.Drawing.Size(167, 22);
            this.TrajectoryGeneratorsSearchTextBox.TabIndex = 6;
            // 
            // TrajectoryGeneratorsSearchButton
            // 
            this.TrajectoryGeneratorsSearchButton.Location = new System.Drawing.Point(200, 137);
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
            this.GeneratorsFromFileListBox.Location = new System.Drawing.Point(27, 182);
            this.GeneratorsFromFileListBox.Name = "GeneratorsFromFileListBox";
            this.GeneratorsFromFileListBox.Size = new System.Drawing.Size(270, 196);
            this.GeneratorsFromFileListBox.TabIndex = 8;
            // 
            // ChosenGeneratorsForTrajectoryData
            // 
            this.ChosenGeneratorsForTrajectoryData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChosenGeneratorsForTrajectoryData.Location = new System.Drawing.Point(373, 182);
            this.ChosenGeneratorsForTrajectoryData.Name = "ChosenGeneratorsForTrajectoryData";
            this.ChosenGeneratorsForTrajectoryData.RowHeadersWidth = 51;
            this.ChosenGeneratorsForTrajectoryData.RowTemplate.Height = 24;
            this.ChosenGeneratorsForTrajectoryData.Size = new System.Drawing.Size(270, 196);
            this.ChosenGeneratorsForTrajectoryData.TabIndex = 9;
            // 
            // ChooseGeneratorForTrajectoryButton
            // 
            this.ChooseGeneratorForTrajectoryButton.Location = new System.Drawing.Point(314, 247);
            this.ChooseGeneratorForTrajectoryButton.Name = "ChooseGeneratorForTrajectoryButton";
            this.ChooseGeneratorForTrajectoryButton.Size = new System.Drawing.Size(42, 23);
            this.ChooseGeneratorForTrajectoryButton.TabIndex = 10;
            this.ChooseGeneratorForTrajectoryButton.Text = ">>";
            this.ChooseGeneratorForTrajectoryButton.UseVisualStyleBackColor = true;
            // 
            // RemoveGeneratorFromTrajectoryButton
            // 
            this.RemoveGeneratorFromTrajectoryButton.Location = new System.Drawing.Point(314, 287);
            this.RemoveGeneratorFromTrajectoryButton.Name = "RemoveGeneratorFromTrajectoryButton";
            this.RemoveGeneratorFromTrajectoryButton.Size = new System.Drawing.Size(42, 23);
            this.RemoveGeneratorFromTrajectoryButton.TabIndex = 11;
            this.RemoveGeneratorFromTrajectoryButton.Text = "<<";
            this.RemoveGeneratorFromTrajectoryButton.UseVisualStyleBackColor = true;
            // 
            // MakeTrajectoryByHandButton
            // 
            this.MakeTrajectoryByHandButton.Location = new System.Drawing.Point(373, 388);
            this.MakeTrajectoryByHandButton.Name = "MakeTrajectoryByHandButton";
            this.MakeTrajectoryByHandButton.Size = new System.Drawing.Size(121, 27);
            this.MakeTrajectoryByHandButton.TabIndex = 12;
            this.MakeTrajectoryByHandButton.Text = "OK";
            this.MakeTrajectoryByHandButton.UseVisualStyleBackColor = true;
            // 
            // TrajectoryCancelButton
            // 
            this.TrajectoryCancelButton.Location = new System.Drawing.Point(524, 388);
            this.TrajectoryCancelButton.Name = "TrajectoryCancelButton";
            this.TrajectoryCancelButton.Size = new System.Drawing.Size(119, 27);
            this.TrajectoryCancelButton.TabIndex = 13;
            this.TrajectoryCancelButton.Text = "Отмена";
            this.TrajectoryCancelButton.UseVisualStyleBackColor = true;
            this.TrajectoryCancelButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // SchInfluentFactorComboBox
            // 
            this.SchInfluentFactorComboBox.FormattingEnabled = true;
            this.SchInfluentFactorComboBox.Location = new System.Drawing.Point(237, 62);
            this.SchInfluentFactorComboBox.Name = "SchInfluentFactorComboBox";
            this.SchInfluentFactorComboBox.Size = new System.Drawing.Size(284, 24);
            this.SchInfluentFactorComboBox.TabIndex = 15;
            // 
            // SchInfluentFactorLabel
            // 
            this.SchInfluentFactorLabel.AutoSize = true;
            this.SchInfluentFactorLabel.Location = new System.Drawing.Point(24, 65);
            this.SchInfluentFactorLabel.Name = "SchInfluentFactorLabel";
            this.SchInfluentFactorLabel.Size = new System.Drawing.Size(191, 17);
            this.SchInfluentFactorLabel.TabIndex = 14;
            this.SchInfluentFactorLabel.Text = "Сечение-влияющий фактор";
            // 
            // TrajectorySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 427);
            this.Controls.Add(this.SchInfluentFactorComboBox);
            this.Controls.Add(this.SchInfluentFactorLabel);
            this.Controls.Add(this.TrajectoryCancelButton);
            this.Controls.Add(this.MakeTrajectoryByHandButton);
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
            this.Text = "TrajectorySettingsForm";
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
        private System.Windows.Forms.Button MakeTrajectoryByHandButton;
        private System.Windows.Forms.Button TrajectoryCancelButton;
        private System.Windows.Forms.ComboBox SchInfluentFactorComboBox;
        private System.Windows.Forms.Label SchInfluentFactorLabel;
    }
}