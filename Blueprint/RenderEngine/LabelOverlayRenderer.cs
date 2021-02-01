using System.Collections.Generic;
using System.Drawing;
using Blueprint.VectorImagess;
using TrigonometryLib.Primitives;

namespace Blueprint.RenderEngine
{
    internal class LabelOverlayRenderer : Renderer
    {
        private class OverlayVector2D
        {
            public Vector2D v;
            public double distance;
            public OverlayVector2D(Vector2D vec, double dist)
            {
                v = vec;
                distance = dist;
            }
        }

        internal LayeredVectorImage layeredImage = null;
        //private int lastRenderCount = 0;
        private List<OverlayVector2D> overlayPoints = new List<OverlayVector2D>();

        public bool IsActive { get; set; }

        public LabelOverlayRenderer()
        {
            IsActive = false;
        }

        internal override void Draw(RenderContext context)
        {
            base.Draw(context);
            if ((context.ShowPoints) && (layeredImage != null) && (IsActive))
            {
                RebuildList(layeredImage.Image);
                DrawOverlay(context);
            }
        }

        private void DrawOverlay(RenderContext context)
        {
            for (int i = 0; i < overlayPoints.Count; i++)
            {
                if (overlayPoints[i].distance * context.DrawScale < 25.0f)
                {
                    break;
                }

                string label = PrimitiveRenderData.Get(overlayPoints[i].v).Text;

                SolidBrush drawBrush = new SolidBrush(Colors.ScientificText);
                Font font = new Font("Arial", 10);

                Vector2D p = context.PointToScreen(overlayPoints[i].v);
                context.Graphics.DrawString(label, font, Colors.ScientificText, p);
            }
        }

        private void RebuildList(VectorImage img)
        {
            overlayPoints.Clear();
            List<Vector2D> vertices = img.GetPrimitives<Vector2D>();
            foreach (Vector2D v in vertices)
            {
                if (PrimitiveRenderData.Get(v).Text != "")
                {
                    double dist = GetClosestDistance(v, vertices);
                    overlayPoints.Add(new OverlayVector2D(v, dist));
                }
            }
            overlayPoints.Sort((a, b) => b.distance.CompareTo(a.distance));
        }

        private double GetClosestDistance(Vector2D vector, List<Vector2D> vertices)
        {
            double distance = double.MaxValue;
            foreach (Vector2D v in vertices)
            {
                double d = (vector - v).Mag();
                if ((vector != v) && (d < distance))
                {
                    distance = d;
                }
            }
            return distance;
        }
    }
}
