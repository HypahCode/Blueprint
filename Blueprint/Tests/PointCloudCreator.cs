using System;
using TrigonometryLib.Primitives;

namespace Blueprint.Tests
{
    internal class PointCloudCreator
    {
        public static VectorCloud2D Create(Rectangle2D rect, int count)
        {
            VectorCloud2D pointCloud = new VectorCloud2D();
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                pointCloud.Add(RandVec2D(rect, r));
            }
            return pointCloud;
        }

        public static VectorCloud2D CreatSquareCloud(int rowCount, int columnCount)
        {
            VectorCloud2D pointCloud = new VectorCloud2D();
            Random r = new Random();
            for (int yy = 0; yy < rowCount; yy++)
                for (int xx = 0; xx < columnCount; xx++)
                {
                    pointCloud.Add(new Vector2D(xx * 10, yy * 10));
                }
            return pointCloud;
        }

        public static VectorCloud2D CreateCirulairCloud(Circle2D c, int count)
        {
            VectorCloud2D pointCloud = new VectorCloud2D();
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                pointCloud.Add((RandVec2D(r).Normal() * c.radius) + c.center);
            }
            pointCloud.Add(c.center);
            return pointCloud;
        }

        private static Vector2D RandVec2D(Random r)
        {
            return new Vector2D((r.NextDouble() - 0.5f) * 2.0f, (r.NextDouble() - 0.5f) * 2.0f);
        }

        private static Vector2D RandVec2D(Rectangle2D rect, Random r)
        {
            double x = rect.topLeft.x + (rect.bottomRight.x - rect.topLeft.x) * r.NextDouble();
            double y = rect.topLeft.y + (rect.bottomRight.y - rect.topLeft.y) * r.NextDouble();
            return new Vector2D(x, y);
        }
    }
}
