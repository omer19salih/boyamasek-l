using System;
using System.Windows.Forms;

namespace SekilBoyamaApp
{
    public class TimerYonetici
    {
        private Timer timer;
        private int progressValue = 0;
        private ProgressBar progressBar;
        private Form aktifForm;
        private Form gidecekForm;

        public TimerYonetici(ProgressBar progressBar, Form aktifForm, Form gidecekForm)
        {
            this.progressBar = progressBar;
            this.aktifForm = aktifForm;
            this.gidecekForm = gidecekForm;

            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressValue += 2;
            if (progressBar != null && progressValue <= 100)
            {
                progressBar.Value = progressValue;
            }

            if (progressValue >= 100)
            {
                timer.Stop();
                if (progressBar != null)
                    progressBar.Visible = false;

                gidecekForm.Show();
                aktifForm.Hide();
            }
        }

        public void Baslat()
        {
            progressValue = 0;
            if (progressBar != null)
            {
                progressBar.Value = 0;
                progressBar.Maximum = 100;
            }
            timer.Start();
        }
    }
}
