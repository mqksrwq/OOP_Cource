namespace OOP_Cource.View.Controls
{
    partial class AdminControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl DistrictTabControl;

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
            this.DistrictTabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // DistrictTabControl
            // 
            this.DistrictTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DistrictTabControl.Location = new System.Drawing.Point(0, 0);
            this.DistrictTabControl.Name = "DistrictTabControl";
            this.DistrictTabControl.SelectedIndex = 0;
            this.DistrictTabControl.Size = new System.Drawing.Size(1280, 720);
            this.DistrictTabControl.TabIndex = 0;
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DistrictTabControl);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.AdminControl_Load);
            this.ResumeLayout(false);
        }
    }
}
