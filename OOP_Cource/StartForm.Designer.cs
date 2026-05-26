namespace KursProject_Boyarkin_OOP
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            label1 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.BackColor = System.Drawing.Color.FromArgb(40, 55, 71);
            label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(500, 320);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            button1.ForeColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(358, 348);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(130, 44);
            button1.TabIndex = 1;
            button1.Text = "Начать";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // StartForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(40, 55, 71);
            ClientSize = new System.Drawing.Size(500, 410);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StartForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "О программе";
            Load += StartForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
