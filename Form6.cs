using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Media;

namespace SekilBoyamaApp
{
    public partial class Form6 : Form
    {
        private Color selectedColor = Color.Gray;
        private Dictionary<string, ShapeInfo> shapes = new Dictionary<string, ShapeInfo>();
        private SoundPlayer soundPlayer;
        private bool isMusicPlaying = false;
        private int currentMusicIndex = 1;

        public Form6()
        {
            InitializeComponent();
            InitializeMusicPlayer();

            // Çiçek yapısı
            shapes["govde"] = new ShapeInfo(new Rectangle(250, 190, 30, 110), Color.White, ShapeType.Rectangle); // Gövde
            shapes["yaprak1"] = new ShapeInfo(new Rectangle(210, 170, 70, 60), Color.White, ShapeType.Ellipse); // Sol yaprak
            shapes["yaprak2"] = new ShapeInfo(new Rectangle(270, 170, 60, 50), Color.White, ShapeType.Ellipse); // Sağ yaprak
            shapes["cicekGovde"] = new ShapeInfo(new Rectangle(240, 110, 70, 70), Color.White, ShapeType.Circle); // Çiçek ortası


            // Çiçek yaprakları (8 adet, dairesel etrafında)
            int centerX = 260;
            int centerY = 130;
            int petalRadius = 30;
            for (int i = 0; i < 8; i++)
            {
                double angle = i * 45 * Math.PI / 180; // 8 yaprak, 45 derece aralık
                int x = centerX + (int)(petalRadius * Math.Cos(angle)) - 20;
                int y = centerY + (int)(petalRadius * Math.Sin(angle)) - 20;
                shapes[$"yaprak_cicek_{i + 1}"] = new ShapeInfo(new Rectangle(x, y, 40, 40), Color.White, ShapeType.Ellipse);
            }

            panel1.Paint += Panel1_Paint;
            panel1.MouseClick += Panel1_MouseClick;
            btnRenkSec.Click += BtnRenkSec_Click;
            btnFormuKaydet.Click += BtnFormuKaydet_Click;
           
        }

        private void InitializeMusicPlayer()
        {
            soundPlayer = new SoundPlayer();
            
        }

        

       

        

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (soundPlayer != null)
            {
                soundPlayer.Stop();
                soundPlayer.Dispose();
            }
        }

        private void BtnRenkSec_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
            }
        }

        private void BtnFormuKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Resmi|*.png|JPG Resmi|*.jpg";
            sfd.FileName = "CicekBoyama";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                bmp.Save(sfd.FileName);
                MessageBox.Show("Form görseli başarıyla kaydedildi:\n" + sfd.FileName);
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var shape in shapes.Values)
            {
                using (Brush b = new SolidBrush(shape.FillColor))
                {
                    switch (shape.Type)
                    {
                        case ShapeType.Rectangle:
                            g.FillRectangle(b, shape.Bounds);
                            g.DrawRectangle(Pens.Black, shape.Bounds);
                            break;

                        case ShapeType.Ellipse:
                            g.FillEllipse(b, shape.Bounds);
                            g.DrawEllipse(Pens.Black, shape.Bounds);
                            break;

                        case ShapeType.Circle:
                            g.FillEllipse(b, shape.Bounds);
                            g.DrawEllipse(Pens.Black, shape.Bounds);
                            break;
                    }
                }
            }
        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var shape in shapes.Values)
            {
                Rectangle inflatedBounds = shape.Bounds;
                inflatedBounds.Inflate(5, 5); // Daha kolay tıklanabilirlik için büyüt

                if (inflatedBounds.Contains(e.Location))
                {
                    shape.FillColor = selectedColor;
                    panel1.Invalidate();
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 yeniForm = new Form3();
            yeniForm.Show();
            this.Hide();
        }
    }
}
