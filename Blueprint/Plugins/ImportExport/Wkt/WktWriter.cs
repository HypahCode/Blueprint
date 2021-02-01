using System;
using System.Collections.Generic;
using System.Text;
using Blueprint.VectorImagess;
using TrigonometryLib.Primitives;

namespace Blueprint.ImportExport.Wkt.WktLoader
{
    public class WktWriter
    {
        private WktWriter() { }

        internal static string ImageToText(LayeredVectorImage img)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Primitive2D p in img.Image.primitives)
            {
                if (p is Vector2D) sb.Append("POINT (" + Vector2DToText(p as Vector2D) + ")\n").Append(Environment.NewLine);
                if (p is Line2D) sb.Append("LINESTRING  (" + Line2DToText(p as Line2D) + ")\n").Append(Environment.NewLine);
                if (p is Shape2D) sb.Append("POLYGON  (" + Polygon2DToText(p as Shape2D) + ")\n").Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private static string Vector2DToText(Vector2D v)
        {
            return v.x.ToString() + " " + v.y.ToString();
        }

        private static string Line2DToText(Line2D l)
        {
            return Vector2DToText(l.Start) + ", " + Vector2DToText(l.End);
        }

        private static string Polygon2DToText(Shape2D s)
        {
            string result = "";
            List<Vector2D> points = new List<Vector2D>(s.GetPoints());
            for (int i = 0; i < points.Count; i++)
            {
                bool isLastPoint = i == points.Count - 1;
                result += Vector2DToText(points[i]) + (isLastPoint ? "" : ", ");
            }
            return result;
        }
    }
}
