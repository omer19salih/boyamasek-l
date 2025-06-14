namespace SekilBoyamaApp
{
    partial class Form1
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRenkSec;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnFormuKaydet;
        private System.Windows.Forms.Button btnMusicPlay;
        private System.Windows.Forms.Button btnNextMusic;
        /// <summary>
        /// Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        /// <param name="disposing">Yönetilen kaynaklar dispose edilmeliyse true; aksi halde false.</param>
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
        /// Tasarımcı desteği için gerekli metot - içeriği kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRenkSec = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFormuKaydet = new System.Windows.Forms.Button();
            this.btnMusicPlay = new System.Windows.Forms.Button();
            this.btnNextMusic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 535);
            this.panel1.TabIndex = 0;
            // 
            // btnRenkSec
            // 
            this.btnRenkSec.Location = new System.Drawing.Point(12, 551);
            this.btnRenkSec.Name = "btnRenkSec";
            this.btnRenkSec.Size = new System.Drawing.Size(100, 30);
            this.btnRenkSec.TabIndex = 1;
            this.btnRenkSec.Text = "Renk Seç";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.CausesValidation = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(719, 551);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Geri";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFormuKaydet
            // 
            this.btnFormuKaydet.Location = new System.Drawing.Point(570, 551);
            this.btnFormuKaydet.Name = "btnFormuKaydet";
            this.btnFormuKaydet.Size = new System.Drawing.Size(118, 30);
            this.btnFormuKaydet.TabIndex = 3;
            this.btnFormuKaydet.Text = "Formu Kaydet";
            this.btnFormuKaydet.Click += new System.EventHandler(this.btnFormuKaydet_Click);
            // 
         
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(819, 618);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRenkSec);
            this.Controls.Add(this.btnFormuKaydet);
            this.Controls.Add(this.btnMusicPlay);
            this.Controls.Add(this.btnNextMusic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şekil Boyama Uygulaması";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
    }
}
