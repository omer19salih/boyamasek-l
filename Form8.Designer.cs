namespace SekilBoyamaApp
{
    partial class Form8
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFormuKaydet;
        private System.Windows.Forms.Button button1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFormuKaydet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 480);
            this.panel1.TabIndex = 0;
            // 
            // btnFormuKaydet
            // 
            this.btnFormuKaydet.Location = new System.Drawing.Point(821, 37);
            this.btnFormuKaydet.Name = "btnFormuKaydet";
            this.btnFormuKaydet.Size = new System.Drawing.Size(140, 35);
            this.btnFormuKaydet.TabIndex = 1;
            this.btnFormuKaydet.Text = "Formu Kaydet";
            this.btnFormuKaydet.UseVisualStyleBackColor = true;
            this.btnFormuKaydet.Click += new System.EventHandler(this.btnFormuKaydet_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(821, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Geri";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 502);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFormuKaydet);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Köpek Boyama";
            this.ResumeLayout(false);

        }
    }
}
