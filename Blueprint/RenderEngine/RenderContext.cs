using System;
using System.Drawing;
using System.Windows.Forms;
using BlueprintAddon;
using TrigonometryLib.Primitives;

namespace Blueprint.RenderEngine
{
    public sealed class RenderContext : IRenderContext
    {
        internal UserControl Panel { get; set;}
        public int Width { get { return Panel.Width; } }
        public int Height { get { return Panel.Height; } }
        public IRenderProxy Graphics { get; internal set; }

        public Vector2D Location { get; set; }
        public double DrawScale { get; set; }
        public double GridSize { get; set; }

        public bool ShowPoints { get; set; }
        public bool ShowLines { get; set; }
        public bool ShowTriangles { get; set; }
        public bool ShowFilledTriangles { get; set; }
        public bool ShowShapes { get; set; }
        public bool ShowCircles { get; set; }

        internal RenderContext()
        {
            Location = new Vector2D(0.0f, 0.0f);
            DrawScale = 1.0f;
            GridSize = 50.0f;

            ShowPoints = true;
            ShowLines = true;
            ShowTriangles = true;
            ShowFilledTriangles = false;
            ShowShapes = true;
            ShowCircles = true;
        }

        public Vector2D PointToScreen(Vector2D v)
        {
            double xx = (v.x * DrawScale) + Location.x;
            double yy = (v.y * DrawScale) + Location.y;
            return new Vector2D(xx, yy);
        }

        public Vector2D PointToScreen(double x, double y)
        {
            double xx = (x * DrawScale) + Location.x;
            double yy = (y * DrawScale) + Location.y;
            return new Vector2D(xx, yy);
        }

        public Vector2D ScreenToPoint(Vector2D v)
        {
            return new Vector2D((v.x - Location.x) / DrawScale, (v.y - Location.y) / DrawScale);
        }

        public Vector2D ScreenToPoint(double x, double y)
        {
            return new Vector2D((x - Location.x) / DrawScale, (y - Location.y) / DrawScale);
        }

        public Vector2D GridSnap(Vector2D v)
        {
            return new Vector2D(Math.Round(v.x / GridSize) * GridSize, Math.Round(v.y / GridSize) * GridSize);
        }






        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------
        private Point GetPoint(Vector2D v)
        {
            double x = (v.x * DrawScale) + Location.x;
            double y = (v.y * DrawScale) + Location.y;
            return new Point((int)x, (int)y);
        }

        private PointF GetPointF(Vector2D v)
        {
            double x = (v.x * DrawScale) + Location.x;
            double y = (v.y * DrawScale) + Location.y;
            return new PointF((float)x, (float)y);
        }

        private PointF GetPoinF(double x, double y)
        {
            double xx = (x * DrawScale) + Location.x;
            double yy = (y * DrawScale) + Location.y;
            return new PointF((float)xx, (float)yy);
        }

        private Vector2D GetVector(int x, int y)
        {
            return new Vector2D((x - Location.x) / DrawScale, (y - Location.y) / DrawScale);
        }

        internal Vector2D GetVectorFloat(double x, double y)
        {
            return new Vector2D((x - Location.x) / DrawScale, (y - Location.y) / DrawScale);
        }


        private Vector2D TranslateVector(Vector2D v)
        {
            return new Vector2D((v.x - Location.x) / DrawScale, (v.y - Location.y) / DrawScale);
        }
    }
}
