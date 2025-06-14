namespace SekilBoyamaApp
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRenkSec;
        private System.Windows.Forms.Button btnFormuKaydet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;

        /// <summary>
        /// Temizleme işlemi için
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRenkSec = new System.Windows.Forms.Button();
            this.btnFormuKaydet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 391);
            this.panel1.TabIndex = 0;
            // 
            // btnRenkSec
            // 
            this.btnRenkSec.Location = new System.Drawing.Point(804, 38);
            this.btnRenkSec.Name = "btnRenkSec";
            this.btnRenkSec.Size = new System.Drawing.Size(110, 35);
            this.btnRenkSec.TabIndex = 1;
            this.btnRenkSec.Text = "Renk Seç";
            this.btnRenkSec.UseVisualStyleBackColor = true;
            // 
            // btnFormuKaydet
            // 
            this.btnFormuKaydet.Location = new System.Drawing.Point(804, 79);
            this.btnFormuKaydet.Name = "btnFormuKaydet";
            this.btnFormuKaydet.Size = new System.Drawing.Size(110, 35);
            this.btnFormuKaydet.TabIndex = 2;
            this.btnFormuKaydet.Text = "Formu Kaydet";
            this.btnFormuKaydet.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(804, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Geri";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRenkSec);
            this.Controls.Add(this.btnFormuKaydet);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şekil Boyama";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
