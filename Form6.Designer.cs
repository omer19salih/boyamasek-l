namespace SekilBoyamaApp
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRenkSec;
        private System.Windows.Forms.Button btnFormuKaydet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.Button btnMusicPlay;
        public System.Windows.Forms.Button btnNextMusic;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRenkSec = new System.Windows.Forms.Button();
            this.btnFormuKaydet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnMusicPlay = new System.Windows.Forms.Button();
            this.btnNextMusic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1308, 601);
            this.panel1.TabIndex = 0;
            // 
            // btnRenkSec
            // 
            this.btnRenkSec.Location = new System.Drawing.Point(1410, 77);
            this.btnRenkSec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRenkSec.Name = "btnRenkSec";
            this.btnRenkSec.Size = new System.Drawing.Size(107, 32);
            this.btnRenkSec.TabIndex = 1;
            this.btnRenkSec.Text = "Renk Seç";
            this.btnRenkSec.UseVisualStyleBackColor = true;
            // 
            // btnFormuKaydet
            // 
            this.btnFormuKaydet.Location = new System.Drawing.Point(1410, 131);
            this.btnFormuKaydet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFormuKaydet.Name = "btnFormuKaydet";
            this.btnFormuKaydet.Size = new System.Drawing.Size(107, 32);
            this.btnFormuKaydet.TabIndex = 2;
            this.btnFormuKaydet.Text = "Formu Kaydet";
            this.btnFormuKaydet.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.Location = new System.Drawing.Point(1410, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Geri";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
          
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 631);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFormuKaydet);
            this.Controls.Add(this.btnRenkSec);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMusicPlay);
            this.Controls.Add(this.btnNextMusic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çiçek Boyama";
            this.ResumeLayout(false);

        }
    }
}
