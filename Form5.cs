using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Media;

namespace SekilBoyamaApp
{
    public partial class Form5 : Form
    {
        private Color selectedColor = Color.Gray;
        private Dictionary<string, ShapeInfo> shapes;
        private SoundPlayer soundPlayer;
        private bool isMusicPlaying = false;
        private int currentMusicIndex = 1;

        public Form5()
        {
            InitializeComponent();
            InitializeMusicPlayer();

            shapes = new Dictionary<string, ShapeInfo>();

            // Lokomotif gövdesi
            shapes["lokomotif"] = new ShapeInfo(new Rectangle(50, 150, 100, 60), Color.White, ShapeType.Rectangle);

            // Lokomotif bacası
            shapes["bacasi"] = new ShapeInfo(new Rectangle(80, 110, 20, 40), Color.White, ShapeType.Rectangle);

            // Duman
            shapes["duman1"] = new ShapeInfo(new Rectangle(75, 90, 20, 20), Color.White, ShapeType.Circle);
            shapes["duman2"] = new ShapeInfo(new Rectangle(65, 70, 25, 25), Color.White, ShapeType.Circle);
            shapes["duman3"] = new ShapeInfo(new Rectangle(60, 50, 30, 30), Color.White, ShapeType.Circle);

            // Vagonlar
            shapes["vagon1"] = new ShapeInfo(new Rectangle(160, 150, 100, 60), Color.White, ShapeType.Rectangle);
            shapes["vagon2"] = new ShapeInfo(new Rectangle(270, 150, 100, 60), Color.White, ShapeType.Rectangle);

            // Tekerlekler
            shapes["teker1"] = new ShapeInfo(new Rectangle(60, 200, 30, 30), Color.White, ShapeType.Circle);
            shapes["teker2"] = new ShapeInfo(new Rectangle(100, 200, 30, 30), Color.White, ShapeType.Circle);
            shapes["teker3"] = new ShapeInfo(new Rectangle(170, 200, 30, 30), Color.White, ShapeType.Circle);
            shapes["teker4"] = new ShapeInfo(new Rectangle(210, 200, 30, 30), Color.White, ShapeType.Circle);
            shapes["teker5"] = new ShapeInfo(new Rectangle(280, 200, 30, 30), Color.White, ShapeType.Circle);
            shapes["teker6"] = new ShapeInfo(new Rectangle(320, 200, 30, 30), Color.White, ShapeType.Circle);

            // Pencereler
            shapes["pencere1"] = new ShapeInfo(new Rectangle(180, 160, 20, 20), Color.White, ShapeType.Rectangle);
            shapes["pencere2"] = new ShapeInfo(new Rectangle(290, 160, 20, 20), Color.White, ShapeType.Rectangle);

            // Panel olayları
            panel1.Paint += Panel1_Paint;
            panel1.MouseClick += Panel1_MouseClick;

            // Butonlar
            btnRenkSec.Click += BtnRenkSec_Click;
            btnFormuKaydet.Click += BtnFormuKaydet_Click;
            button1.Click += Button1_Click;
     
        }

        private void InitializeMusicPlayer()
        {
            soundPlayer = new SoundPlayer();
 
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
            sfd.FileName = "FormGoruntusu";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FormuKaydet(sfd.FileName);
            }
        }

        private void FormuKaydet(string dosyaYolu)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            bmp.Save(dosyaYolu);
            MessageBox.Show("Form görseli başarıyla kaydedildi:\n" + dosyaYolu);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var shape in shapes.Values)
            {
                using (Brush brush = new SolidBrush(shape.FillColor))
                {
                    switch (shape.Type)
                    {
                        case ShapeType.Rectangle:
                            g.FillRectangle(brush, shape.Bounds);
                            g.DrawRectangle(Pens.Black, shape.Bounds);
                            break;
                        case ShapeType.Circle:
                            g.FillEllipse(brush, shape.Bounds);
                            g.DrawEllipse(Pens.Black, shape.Bounds);
                            break;
                        case ShapeType.Triangle:
                            Point[] points =
                            {
                                new Point(shape.Bounds.Left + shape.Bounds.Width / 2, shape.Bounds.Top),
                                new Point(shape.Bounds.Left, shape.Bounds.Bottom),
                                new Point(shape.Bounds.Right, shape.Bounds.Bottom)
                            };
                            g.FillPolygon(brush, points);
                            g.DrawPolygon(Pens.Black, points);
                            break;
                    }
                }
            }
        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var shape in shapes.Values)
            {
                if (shape.Type == ShapeType.Triangle)
                {
                    GraphicsPath path = new GraphicsPath();
                    Point[] points =
                    {
                        new Point(shape.Bounds.Left + shape.Bounds.Width / 2, shape.Bounds.Top),
                        new Point(shape.Bounds.Left, shape.Bounds.Bottom),
                        new Point(shape.Bounds.Right, shape.Bounds.Bottom)
                    };
                    path.AddPolygon(points);

                    if (path.IsVisible(e.Location))
                    {
                        shape.FillColor = selectedColor;
                        panel1.Invalidate();
                        break;
                    }
                }
                else
                {
                    Rectangle inflatedBounds = shape.Bounds;
                    inflatedBounds.Inflate(3, 3); // Tıklamayı kolaylaştırmak için biraz büyüt
                    if (inflatedBounds.Contains(e.Location))
                    {
                        shape.FillColor = selectedColor;
                        panel1.Invalidate();
                        break;
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form3 yeniForm = new Form3();
            yeniForm.Show();
            this.Hide();
        }
    }
}
