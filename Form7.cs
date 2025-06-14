using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Media;

namespace SekilBoyamaApp
{
    public partial class Form7 : Form
    {
        private string selectedShapeType = null;
        private Color selectedColor = Color.Gray;
        private List<ShapeInfo> shapes = new List<ShapeInfo>();
        private SoundPlayer soundPlayer;
        private bool isMusicPlaying = false;
        private int currentMusicIndex = 1;

        public Form7()
        {
            InitializeComponent();
          

            // Kedi şekli
            shapes.Add(new ShapeInfo(new Rectangle(200, 200, 100, 100), Color.White, "circle"));      // Kafa
            shapes.Add(new ShapeInfo(new Rectangle(180, 170, 30, 30), Color.White, "triangle"));      // Sol kulak
            shapes.Add(new ShapeInfo(new Rectangle(290, 170, 30, 30), Color.White, "triangle"));      // Sağ kulak
            shapes.Add(new ShapeInfo(new Rectangle(190, 300, 120, 80), Color.White, "rectangle"));    // Gövde
            shapes.Add(new ShapeInfo(new Rectangle(190, 380, 20, 60), Color.White, "rectangle"));     // Sol bacak
            shapes.Add(new ShapeInfo(new Rectangle(290, 380, 20, 60), Color.White, "rectangle"));     // Sağ bacak

            // Renk seçim şekilleri
            shapes.Add(new ShapeInfo(new Rectangle(10, 10, 30, 30), Color.Orange, "circle"));         // Turuncu daire
            shapes.Add(new ShapeInfo(new Rectangle(50, 10, 30, 30), Color.Black, "triangle"));        // Siyah üçgen
            shapes.Add(new ShapeInfo(new Rectangle(90, 10, 30, 30), Color.Gray, "rectangle"));        // Gri dikdörtgen

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
                        case "circle":
                            e.Graphics.FillEllipse(b, shape.Bounds);
                            e.Graphics.DrawEllipse(Pens.Black, shape.Bounds);
                            break;

                        case "rectangle":
                            e.Graphics.FillRectangle(b, shape.Bounds);
                            e.Graphics.DrawRectangle(Pens.Black, shape.Bounds);
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

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var shape in shapes)
            {
                if (shape.Bounds.Contains(e.Location) && shape.Bounds.Y < 50)
                {
                    selectedColor = shape.FillColor;
                    selectedShapeType = shape.Type;
                    return;
                }
            }

            foreach (var shape in shapes)
            {
                if (shape.Bounds.Y < 50)
                    continue;

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
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 yeniForm = new Form3();
            yeniForm.Show();
            this.Hide();
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

        private void btnFormuKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Resmi|*.png|JPG Resmi|*.jpg";
            sfd.FileName = "KediCizimi";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                bmp.Save(sfd.FileName);
                MessageBox.Show("Kedi görseli başarıyla kaydedildi:\n" + sfd.FileName);
            }
        }
    }
}
