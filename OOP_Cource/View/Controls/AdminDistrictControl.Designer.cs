namespace OOP_Cource.View.Controls
{
    partial class AdminDistrictControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView VehicleDataGridView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.ComboBox CriteriaComboBox;
        private System.Windows.Forms.TextBox CriteriaValueTextBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.VehicleDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnCsv = new System.Windows.Forms.Button();
            this.CriteriaComboBox = new System.Windows.Forms.ComboBox();
            this.CriteriaValueTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.VehicleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VehicleDataGridView
            // 
            this.VehicleDataGridView.AllowUserToAddRows = false;
            this.VehicleDataGridView.AllowUserToDeleteRows = false;
            this.VehicleDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VehicleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VehicleDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.VehicleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VehicleDataGridView.Location = new System.Drawing.Point(20, 85);
            this.VehicleDataGridView.MultiSelect = false;
            this.VehicleDataGridView.Name = "VehicleDataGridView";
            this.VehicleDataGridView.ReadOnly = true;
            this.VehicleDataGridView.RowHeadersVisible = false;
            this.VehicleDataGridView.RowTemplate.Height = 33;
            this.VehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VehicleDataGridView.Size = new System.Drawing.Size(1240, 470);
            this.VehicleDataGridView.TabIndex = 0;
            this.VehicleDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VehicleDataGridView_CellContentClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(20, 585);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(220, 60);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAll.Location = new System.Drawing.Point(275, 585);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(220, 60);
            this.btnDeleteAll.TabIndex = 2;
            this.btnDeleteAll.Text = "Удалить все";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(1040, 585);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(220, 60);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Выход";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(940, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 42);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(1110, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 42);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Сбросить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(530, 585);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(220, 60);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Отчет";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // btnCsv
            // 
            this.btnCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCsv.Location = new System.Drawing.Point(785, 585);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(220, 60);
            this.btnCsv.TabIndex = 9;
            this.btnCsv.Text = "CSV";
            this.btnCsv.UseVisualStyleBackColor = true;
            this.btnCsv.Click += new System.EventHandler(this.CsvButton_Click);
            // 
            // CriteriaComboBox
            // 
            this.CriteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CriteriaComboBox.FormattingEnabled = true;
            this.CriteriaComboBox.Items.AddRange(new object[] {
            "ID",
            "Гос. номер",
            "Модель",
            "Вместимость",
            "Статус"});
            this.CriteriaComboBox.Location = new System.Drawing.Point(20, 20);
            this.CriteriaComboBox.Name = "CriteriaComboBox";
            this.CriteriaComboBox.Size = new System.Drawing.Size(220, 33);
            this.CriteriaComboBox.TabIndex = 4;
            // 
            // CriteriaValueTextBox
            // 
            this.CriteriaValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CriteriaValueTextBox.Location = new System.Drawing.Point(260, 20);
            this.CriteriaValueTextBox.Name = "CriteriaValueTextBox";
            this.CriteriaValueTextBox.Size = new System.Drawing.Size(655, 31);
            this.CriteriaValueTextBox.TabIndex = 5;
            // 
            // AdminDistrictControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.CriteriaValueTextBox);
            this.Controls.Add(this.CriteriaComboBox);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.VehicleDataGridView);
            this.Name = "AdminDistrictControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.AdminDistrictControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VehicleDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
