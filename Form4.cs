using System;
using System.Media;
using System.Windows.Forms;

namespace SekilBoyamaApp
{
    public partial class Form4 : Form
    {
        private SoundPlayer sesYonlendirme;
        private TimerYonetici timerYonetici;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Ses dosyasını yükle ve oynat
            try
            {
                sesYonlendirme = new SoundPlayer(Properties.Resources.hadi); // 'hadi.wav' dosyası Resources içinde olmalı
                sesYonlendirme.Load();
                sesYonlendirme.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ses dosyası yüklenemedi: " + ex.Message);
            }

            // Timer yönetimini başlat
            timerYonetici = new TimerYonetici(progressBar1, this, new Form3());
            timerYonetici.Baslat();
        }
    }
}
