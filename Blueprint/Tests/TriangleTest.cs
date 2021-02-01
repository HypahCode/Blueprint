using System.Drawing;
using Blueprint.RenderEngine;
using Blueprint.VectorImagess;
using TrigonometryLib.Primitives;

namespace Blueprint.Tests
{
    internal class TriangleTest
    {
        public static void PointInTriangleTest(VectorImage image)
        {
            Triangle2D t = new Triangle2D(new Vector2D(25, 150), new Vector2D(200, 200), new Vector2D(60, 80));
            image.Add(t);
            VectorCloud2D pc = PointCloudCreator.Create(new Rectangle2D(new Vector2D(10, 10), new Vector2D(300, 300)), 500);

            pc.Add(t.a);
            pc.Add(t.b);
            pc.Add(t.c);

            foreach (Vector2D p in pc)
                p.SetData(new PrimitiveRenderData(t.IsInside(p) ? Color.DarkGreen : Color.DarkRed));

            image.Add(pc);
        }
    }
}
