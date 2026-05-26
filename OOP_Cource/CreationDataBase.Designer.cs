namespace KursProject_Boyarkin_OOP
{
    partial class CreationDataBase
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            textBoxName = new System.Windows.Forms.TextBox();
            btnOk = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(14, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(253, 36);
            label1.TabIndex = 0;
            label1.Text = "Имя базы данных:";
            // 
            // textBoxName
            // 
            textBoxName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            textBoxName.Location = new System.Drawing.Point(273, 26);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(176, 41);
            textBoxName.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOk.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnOk.ForeColor = System.Drawing.Color.White;
            btnOk.Location = new System.Drawing.Point(32, 88);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(142, 53);
            btnOk.TabIndex = 2;
            btnOk.Text = "Создать";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(100, 110, 120);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(130, 145, 155);
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(235, 88);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(147, 53);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // CreationDataBase
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(236, 240, 244);
            ClientSize = new System.Drawing.Size(467, 167);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CreationDataBase";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Создание базы данных";
            Load += CreationDataBase_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
