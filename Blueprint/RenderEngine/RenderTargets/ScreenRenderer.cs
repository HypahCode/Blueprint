using System;
using System.Drawing;
using BlueprintAddon;
using TrigonometryLib.Primitives;

namespace Blueprint.RenderEngine.RenderTargets
{
    public class ScreenRenderer : IRenderProxy
    {
        private Graphics graphics;

        public ScreenRenderer(Graphics graph)
        {
            graphics = graph;
        }

        public void DrawPoint(Vector2D center, Color color, int width)
        {
            graphics.FillEllipse(new SolidBrush(color), new Rectangle((int)center.x - width, (int)center.y - width, width * 2, width * 2));
        }

        public void DrawEllipse(Rectangle2D rectangle, Color color, int width)
        {
            graphics.DrawEllipse(GetPen(color, width), 
                (float)rectangle.topLeft.x,
                (float)rectangle.topLeft.y,
                (float)rectangle.bottomRight.x,
                (float)rectangle.bottomRight.y);
        }

        public void DrawEllipse(int x1, int y1, int x2, int y2, Color color, int width)
        {
            graphics.DrawEllipse(GetPen(color, width), x1, y1, x2, y2);
        }

        public void DrawLine(Vector2D a, Vector2D b, Color color, int width)
        {
            Point p1 = new Point((int)a.x, (int)a.y);
            Point p2 = new Point((int)b.x, (int)b.y);
            graphics.DrawLine(GetPen(color, width), p1, p2);
        }

        public void FillPolygon(Vector2D[] points, Color color)
        {
            Point[] pointArray = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
                pointArray[i] = new Point((int)points[i].x, (int)points[i].y);
            graphics.FillPolygon(new SolidBrush(color), pointArray);
        }

        public void FillRectangle(Rectangle2D rect, Color color)
        {
            graphics.FillRectangle(new SolidBrush(color),
                (float)rect.topLeft.x,
                (float)rect.topLeft.y,
                (float)rect.bottomRight.x,
                (float)rect.bottomRight.y);
        }

        public void DrawString(string text, Font font, Color color, Vector2D location)
        {
            graphics.DrawString(text, font, new SolidBrush(color), new PointF((float)location.x, (float)location.y));
        }

        public Vector2D MeasureString(string text, Font font)
        {
            SizeF s = graphics.MeasureString(text, font);
            return new Vector2D(s.Width, s.Height);
        }

        private Pen GetPen(Color color, int width)
        {
            Pen pen = new Pen(color);
            pen.Width = width;
            return pen;
        }
    }
}
