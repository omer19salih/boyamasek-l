using System.Drawing;

namespace SekilBoyamaApp
{
    // Şekil tiplerini belirten enum
    public enum ShapeType
    {
        Rectangle,
        Circle,
        Triangle,
        Ellipse
    }

    public class ShapeInfo
    {
        public Rectangle Bounds { get; set; }
        public Color FillColor { get; set; }
        public ShapeType Type { get; set; }  // enum tipinde olacak

        public ShapeInfo(Rectangle bounds, Color fillColor, ShapeType type)
        {
            Bounds = bounds;
            FillColor = fillColor;
            Type = type;
        }
    }
}
