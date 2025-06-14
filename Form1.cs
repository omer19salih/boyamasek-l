using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SekilBoyamaApp
{
    public partial class Form1 : Form
    {
        private Color selectedColor = Color.Gray;
        private Dictionary<string, ShapeInfo> shapes = new Dictionary<string, ShapeInfo>();

        public Form1()
        {
            InitializeComponent();

            // Ağaç
            shapes["govde"] = new ShapeInfo(new Rectangle(230, 180, 40, 100), Color.White, ShapeType.Rectangle);
            shapes["yaprak1"] = new ShapeInfo(new Rectangle(170, 100, 140, 100), Color.White, ShapeType.Triangle);
            shapes["yaprak2"] = new ShapeInfo(new Rectangle(180, 60, 120, 80), Color.White, ShapeType.Triangle);
            shapes["yaprak3"] = new ShapeInfo(new Rectangle(200, 30, 80, 60), Color.White, ShapeType.Triangle);
            shapes["meyve1"] = new ShapeInfo(new Rectangle(210, 140, 20, 20), Color.White, ShapeType.Circle);
            shapes["meyve2"] = new ShapeInfo(new Rectangle(250, 160, 20, 20), Color.White, ShapeType.Circle);
            shapes["meyve3"] = new ShapeInfo(new Rectangle(230, 110, 20, 20), Color.White, ShapeType.Circle);

            // Güneş (daire + çizgiler)
            shapes["gunes"] = new ShapeInfo(new Rectangle(400, 20, 70, 70), Color.White, ShapeType.Circle);

            // Bulut (birkaç daire yan yana)
            shapes["bulut1"] = new ShapeInfo(new Rectangle(50, 30, 50, 40), Color.White, ShapeType.Circle);
            shapes["bulut2"] = new ShapeInfo(new Rectangle(85, 20, 60, 50), Color.White, ShapeType.Circle);
            shapes["bulut3"] = new ShapeInfo(new Rectangle(125, 30, 50, 40), Color.White, ShapeType.Circle);

            // Ev (dikdörtgen + çatı üçgen + kapı + pencere)
            shapes["evGovde"] = new ShapeInfo(new Rectangle(50, 200, 120, 80), Color.White, ShapeType.Rectangle);
            shapes["evCati"] = new ShapeInfo(new Rectangle(50, 160, 120, 50), Color.White, ShapeType.Triangle);
            shapes["evKapi"] = new ShapeInfo(new Rectangle(100, 240, 30, 40), Color.White, ShapeType.Rectangle);
            shapes["evPencere"] = new ShapeInfo(new Rectangle(70, 210, 30, 30), Color.White, ShapeType.Rectangle);

            panel1.Paint += Panel1_Paint;
            panel1.MouseClick += Panel1_MouseClick;
            btnRenkSec.Click += BtnRenkSec_Click;
        }

        private void BtnRenkSec_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
            }
        }

        public void FormuKaydet(string dosyaYolu)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            bmp.Save(dosyaYolu);
            MessageBox.Show("Form görseli başarıyla kaydedildi:\n" + dosyaYolu);
        }
        private void btnFormuKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Resmi|*.png|JPG Resmi|*.jpg";
            sfd.FileName = "FormGoruntusu";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FormuKaydet(sfd.FileName);
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

                        case ShapeType.Triangle:
                            Point[] points =
                            {
                                new Point(shape.Bounds.Left + shape.Bounds.Width / 2, shape.Bounds.Top),
                                new Point(shape.Bounds.Left, shape.Bounds.Bottom),
                                new Point(shape.Bounds.Right, shape.Bounds.Bottom)
                            };
                            g.FillPolygon(b, points);
                            g.DrawPolygon(Pens.Black, points);
                            break;

                        case ShapeType.Circle:
                            g.FillEllipse(b, shape.Bounds);
                            g.DrawEllipse(Pens.Black, shape.Bounds);
                            break;
                    }
                }
            }

            // Güneş ışınlarını çiz (gunes etrafında)
            if (shapes.TryGetValue("gunes", out ShapeInfo gunesShape))
            {
                Point center = new Point(gunesShape.Bounds.Left + gunesShape.Bounds.Width / 2, gunesShape.Bounds.Top + gunesShape.Bounds.Height / 2);
                int radius = gunesShape.Bounds.Width / 2;
                Pen sunRayPen = new Pen(Color.Orange, 2);

                for (int i = 0; i < 12; i++)
                {
                    double angle = i * 30 * Math.PI / 180; // 12 ışın, 30 derece aralık
                    int x1 = center.X + (int)(radius * Math.Cos(angle));
                    int y1 = center.Y + (int)(radius * Math.Sin(angle));
                    int x2 = center.X + (int)((radius + 15) * Math.Cos(angle));
                    int y2 = center.Y + (int)((radius + 15) * Math.Sin(angle));

                    g.DrawLine(sunRayPen, x1, y1, x2, y2);
                }
                sunRayPen.Dispose();
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
                    inflatedBounds.Inflate(3, 3); // Küçük şekillerin tıklanabilirliğini artır
                    if (inflatedBounds.Contains(e.Location))
                    {
                        shape.FillColor = selectedColor;
                        panel1.Invalidate();
                        break;
                    }
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
