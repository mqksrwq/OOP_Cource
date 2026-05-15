namespace OOP_Cource.View.Controls
{
    partial class EditVehicleControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.TextBox DistrictTextBox;
        private System.Windows.Forms.TextBox ModelTextBox;
        private System.Windows.Forms.TextBox CapacityTextBox;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblStatus;

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
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.DistrictTextBox = new System.Windows.Forms.TextBox();
            this.ModelTextBox = new System.Windows.Forms.TextBox();
            this.CapacityTextBox = new System.Windows.Forms.TextBox();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(260, 40);
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(260, 31);
            this.NumberTextBox.TabIndex = 0;
            // 
            // DistrictTextBox
            // 
            this.DistrictTextBox.Location = new System.Drawing.Point(260, 90);
            this.DistrictTextBox.Name = "DistrictTextBox";
            this.DistrictTextBox.Size = new System.Drawing.Size(260, 31);
            this.DistrictTextBox.TabIndex = 1;
            // 
            // ModelTextBox
            // 
            this.ModelTextBox.Location = new System.Drawing.Point(260, 140);
            this.ModelTextBox.Name = "ModelTextBox";
            this.ModelTextBox.Size = new System.Drawing.Size(260, 31);
            this.ModelTextBox.TabIndex = 2;
            // 
            // CapacityTextBox
            // 
            this.CapacityTextBox.Location = new System.Drawing.Point(260, 190);
            this.CapacityTextBox.Name = "CapacityTextBox";
            this.CapacityTextBox.Size = new System.Drawing.Size(260, 31);
            this.CapacityTextBox.TabIndex = 3;
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Items.AddRange(new object[] {
            "Исправен",
            "На ремонте",
            "Резерв"});
            this.StatusComboBox.Location = new System.Drawing.Point(260, 240);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(260, 33);
            this.StatusComboBox.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(420, 300);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 45);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(40, 44);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(189, 25);
            this.lblNumber.TabIndex = 7;
            this.lblNumber.Text = "Гос. номер";
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(40, 94);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(168, 25);
            this.lblDistrict.TabIndex = 8;
            this.lblDistrict.Text = "Район";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(40, 144);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(92, 25);
            this.lblModel.TabIndex = 9;
            this.lblModel.Text = "Модель";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(40, 194);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(134, 25);
            this.lblCapacity.TabIndex = 10;
            this.lblCapacity.Text = "Вместимость";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(40, 244);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 25);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Статус";
            // 
            // EditVehicleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblDistrict);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.StatusComboBox);
            this.Controls.Add(this.CapacityTextBox);
            this.Controls.Add(this.ModelTextBox);
            this.Controls.Add(this.DistrictTextBox);
            this.Controls.Add(this.NumberTextBox);
            this.Name = "EditVehicleControl";
            this.Size = new System.Drawing.Size(720, 400);
            this.Load += new System.EventHandler(this.EditVehicleControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
