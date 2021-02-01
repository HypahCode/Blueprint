using System.Collections.Generic;
using TrigonometryLib.Primitives;

namespace TrigonometryLib.Triangulation
{
    public class DelaunayTriangulation
    {
        private class Triangle
        {
            internal int a;
            internal int b;
            internal int c;
            public Triangle(int aa, int bb, int cc)
            {
                a = aa;
                b = bb;
                c = cc;
            }
        }

        private VectorCloud2D originalPointCloud = new VectorCloud2D();

        private VectorCloud2D pointCloud = new VectorCloud2D();
        List<Triangle> triangles = new List<Triangle>();
        List<Triangle> invalidTriangles = new List<Triangle>();
        //private List<Contstraint> constraints = new List<Contstraint>();

        public DelaunayTriangulation(VectorCloud2D originalPointCloud)
        {
            this.originalPointCloud = originalPointCloud;
            pointCloud.AddRange(originalPointCloud);
            pointCloud.Sort((a, b) => (a.x != b.x) ? a.x.CompareTo(b.x) : a.y.CompareTo(b.y));
        }

        public List<Triangle2D> Triangulate()
        {
            triangles.Clear();

            for (int a = 0; a < pointCloud.Count - 2; a++)
            {
                for (int b = a + 1; b < pointCloud.Count - 1; b++)
                {
                    for (int c = b + 1; c < pointCloud.Count; c++)
                    {
                        if ((a != b) && (b != c) && c != a)
                        {
                            Triangle t = CreateSortedTriangle(a, b, c);
                            AddTriangle(t);
                        }
                    }
                }
            }
            return CreateTiangle2DList();
        }

        private List<Triangle2D> CreateTiangle2DList()
        {
            List<Triangle2D> triList = new List<Triangle2D>();
            foreach (Triangle t in triangles)
            {
                triList.Add(new Triangle2D(pointCloud[t.a], pointCloud[t.b], pointCloud[t.c]));
            }
            return triList;
        }

        private void AddTriangle(Triangle t)
        {
            if (triangles.Find((x) => (x.a == t.a) && (x.b == t.b) && (x.c == t.c)) != null)
                return;

            Triangle2D tri = new Triangle2D(pointCloud[t.a], pointCloud[t.b], pointCloud[t.c]);
            Circle2D circle = tri.CircleTroughPoints();
            if ((circle != null) && (NoPointsInCircle(pointCloud, circle, t)))
            {
                triangles.Add(t);
            }
        }

        private Triangle CreateSortedTriangle(int a, int b, int c)
        {
            // Bluntly sort triangle points
            int tmp;
            if (a > b) { tmp = a; a = b; b = tmp; }
            if (b > c) { tmp = b; b = c; c = tmp; }
            if (a > b) { tmp = a; a = b; b = tmp; }
            return new Triangle(a, b, c);
        }

        private bool NoPointsInCircle(List<Vector2D> pointCloud, Circle2D circle, Triangle t)
        {
            Rectangle2D boundingRect = new Rectangle2D(circle);
            for (int i = 0; i < pointCloud.Count; i++)
            {
                if (boundingRect.IsInside(pointCloud[i]))
                {
                    if ((t.a != i) && (t.b != i) && (t.c != i) && (circle.IsInside(pointCloud[i])))
                        return false;
                }
            }
            return true;
        }
    }

}
