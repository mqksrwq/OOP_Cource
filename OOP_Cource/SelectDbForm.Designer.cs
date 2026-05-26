namespace KursProject_Boyarkin_OOP
{
    partial class SelectDbForm
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
            labelTitle = new System.Windows.Forms.Label();
            btnCreate = new System.Windows.Forms.Button();
            btnConnect = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(40, 55, 71);
            labelTitle.Location = new System.Drawing.Point(110, 18);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(499, 37);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "Выберите действие с базой данных:";
            // 
            // btnCreate
            // 
            btnCreate.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCreate.ForeColor = System.Drawing.Color.White;
            btnCreate.Location = new System.Drawing.Point(150, 58);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(420, 52);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Создать базу данных";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click_1;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = System.Drawing.Color.FromArgb(40, 55, 71);
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConnect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnConnect.ForeColor = System.Drawing.Color.White;
            btnConnect.Location = new System.Drawing.Point(95, 127);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(523, 52);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Подключиться к существующей";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click_1;
            // 
            // SelectDbForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(236, 240, 244);
            ClientSize = new System.Drawing.Size(730, 200);
            Controls.Add(labelTitle);
            Controls.Add(btnConnect);
            Controls.Add(btnCreate);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SelectDbForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Автобусный парк — выбор базы данных";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnConnect;
    }
}
