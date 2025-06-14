using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace SekilBoyamaApp
{
    public partial class Form2 : Form
    {
        private string selectedShapeType = null;
        private Color selectedColor = Color.Gray;
        private List<ShapeInfo> shapes = new List<ShapeInfo>();
   

        public Form2()
        {
            InitializeComponent();
          

            // Şekilleri tanımla (ev, ağaç, bulut gibi)
            shapes.Add(new ShapeInfo(new Rectangle(50, 250, 100, 100), Color.White, "square"));     // Ev
            shapes.Add(new ShapeInfo(new Rectangle(200, 250, 100, 50), Color.White, "rectangle"));  // Kapı
            shapes.Add(new ShapeInfo(new Rectangle(400, 250, 100, 100), Color.White, "circle"));    // Bulut
            shapes.Add(new ShapeInfo(new Rectangle(300, 100, 100, 100), Color.White, "triangle"));  // Ağaç yaprağı
            shapes.Add(new ShapeInfo(new Rectangle(300, 200, 30, 100), Color.White, "rectangle"));  // Ağaç gövdesi

            // Seçim şekilleri: Sadece şekil + renk seçtirmek için
            shapes.Add(new ShapeInfo(new Rectangle(10, 10, 30, 30), Color.Green, "triangle"));      // yeşil üçgen
            shapes.Add(new ShapeInfo(new Rectangle(50, 10, 30, 30), Color.Black, "square"));        // siyah kare
            shapes.Add(new ShapeInfo(new Rectangle(90, 10, 30, 30), Color.Blue, "circle"));         // mavi daire
            shapes.Add(new ShapeInfo(new Rectangle(130, 10, 40, 25), Color.Brown, "rectangle"));    // kahverengi dikdörtgen

            panel1.Paint += Panel1_Paint;
            panel1.MouseClick += Panel1_MouseClick;
        }

      

        

       

      

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                using (Brush b = new SolidBrush(shape.FillColor))
                {
                    switch (shape.Type)
                    {
                        case "square":
                            e.Graphics.FillRectangle(b, shape.Bounds);
                            e.Graphics.DrawRectangle(Pens.Black, shape.Bounds);
                            break;

                        case "rectangle":
                            e.Graphics.FillRectangle(b, shape.Bounds);
                            e.Graphics.DrawRectangle(Pens.Black, shape.Bounds);
                            break;

                        case "circle":
                            e.Graphics.FillEllipse(b, shape.Bounds);
                            e.Graphics.DrawEllipse(Pens.Black, shape.Bounds);
                            break;

                        case "triangle":
                            Point[] trianglePoints =
                            {
                                new Point(shape.Bounds.Left + shape.Bounds.Width / 2, shape.Bounds.Top),
                                new Point(shape.Bounds.Left, shape.Bounds.Bottom),
                                new Point(shape.Bounds.Right, shape.Bounds.Bottom)
                            };
                            e.Graphics.FillPolygon(b, trianglePoints);
                            e.Graphics.DrawPolygon(Pens.Black, trianglePoints);
                            break;
                    }
                }
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
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            // Önce: Renk seçme butonlarına tıklama kontrolü
            foreach (var shape in shapes)
            {
                if (shape.Bounds.Contains(e.Location) && shape.Bounds.Y < 50)
                {
                    selectedColor = shape.FillColor;
                    selectedShapeType = shape.Type;
                    return;
                }
            }

            // Sonra: Şekilleri boyama kontrolü
            foreach (var shape in shapes)
            {
                if (shape.Bounds.Y < 50)
                    continue; // Renk seçim butonlarını boyama

                if (shape.Type != selectedShapeType)
                    continue;

                bool isInside = false;

                if (shape.Type == "triangle")
                {
                    GraphicsPath path = new GraphicsPath();
                    Point[] points =
                    {
                        new Point(shape.Bounds.Left + shape.Bounds.Width / 2, shape.Bounds.Top),
                        new Point(shape.Bounds.Left, shape.Bounds.Bottom),
                        new Point(shape.Bounds.Right, shape.Bounds.Bottom)
                    };
                    path.AddPolygon(points);
                    isInside = path.IsVisible(e.Location);
                }
                else
                {
                    isInside = shape.Bounds.Contains(e.Location);
                }

                if (isInside)
                {
                    shape.FillColor = selectedColor;
                    panel1.Invalidate();
                    break;
                }
            }
        }

        public class ShapeInfo
        {
            public Rectangle Bounds { get; set; }
            public Color FillColor { get; set; }
            public string Type { get; set; }

            public ShapeInfo(Rectangle bounds, Color fillColor, string type)
            {
                Bounds = bounds;
                FillColor = fillColor;
                Type = type;
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
