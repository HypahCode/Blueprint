using System.Collections.Generic;

namespace TrigonometryLib.Primitives
{
    public class Shape2D : Primitive2D, ICompoundPrimitive2D
    {
        public class Hole
        {
            private Shape2D shape = new Shape2D();
            public Hole(Shape2D hole) { shape = hole; }
            public VectorCloud2D VectorCloud {get { return shape.vertices; } }
            public bool IsInside(Vector2D v) { return shape.IsInside(v); }
            public bool IsClockwise() { return shape.IsClockwise(); }
            public Vector2D FindMostRightVector() { return shape.FindMostRightVector(); }
            public List<Line2D> GetLines() { return shape.GetLines(); }
            public Line2D FindClosestIntersectionLine(Line2D intersectionLine) { return shape.FindClosestIntersectionLine(intersectionLine); }
        }

        protected VectorCloud2D vertices = new VectorCloud2D();
        protected Rectangle2D boundingRectangle = new Rectangle2D(new Vector2D(0.0f, 0.0f), new Vector2D(0.0f, 0.0f));

        private List<Hole> holes = new List<Hole>();

        public Shape2D()
        {
        }

        public Shape2D(VectorCloud2D cloud)
        {
            Add(cloud);
        }

        public List<Hole> Holes { get { return holes; } }

        public void Add(Vector2D v)
        {
            if (vertices.Count == 0)
            {
                boundingRectangle.topLeft = new Vector2D(v);
                boundingRectangle.bottomRight = new Vector2D(v);
            }
            boundingRectangle.Expand(v);

            vertices.Add(v);
        }

        public void Add(VectorCloud2D cloud)
        {
            for (int i = 0; i < cloud.Count; i++)
                vertices.Add(cloud[i]);
        }

        public bool IsInside(Vector2D v)
        {
            if (!boundingRectangle.IsInside(v))
                return false;

            Line2D ray = new Line2D(v, v + boundingRectangle.Width + 1.0f);
            List<Line2D> lines = GetLines();
            int counter = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                Vector2D dummy;
                if (ray.Intersect(lines[i], out dummy))
                    counter++;
            }
            return (counter % 2) == 1;
        }

        public bool IsClockwise()
        {
            double sum = 0.0;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vector2D v1 = vertices[i];
                Vector2D v2 = vertices[(i + 1) % vertices.Count];
                sum += (v2.x - v1.x) * (v2.y + v1.y);
            }
            return sum > 0.0;
        }

        public void Rotate()
        {
            vertices.Rotate();
        }

        public List<Line2D> GetLines()
        {
            List<Line2D> lines = new List<Line2D>();
            for (int i = 0; i < vertices.Count; i++)
            {
                int a = i;
                int b = (i + 1 > vertices.Count - 1) ? (i + 1 - vertices.Count) : i + 1;
                lines.Add(new Line2D(vertices[a], vertices[b]));
            }
            return lines;
        }

        public Vector2D FindMostRightVector()
        {
            return vertices.FindMostRightPoint();
        }

        public Line2D FindClosestIntersectionLine(Line2D intersectionLine)
        {
            List<Line2D> lines = GetLines();
            double distance = double.MaxValue;
            Line2D result = null;

            for (int i = 0; i < lines.Count; i++)
            {
                Vector2D location;
                if (intersectionLine.Intersect(lines[i], out location))
                {
                    double dist = (location - intersectionLine.Start).Mag();
                    if (dist < distance)
                    {
                        result = lines[i];
                        distance = dist;
                    }
                }
            }
            return result;
        }

        protected Vector2D GetVector(int idx)
        {
            return vertices[Mod(idx, vertices.Count)];
        }

        protected int Mod(int n, int x)
        {
            return ((n % x) + x) % x;
        }

        public List<Primitive2D> GetPrimitives()
        {
            return new List<Primitive2D>(vertices);
        }

        public List<Vector2D> GetPoints()
        {
            return new List<Vector2D>(vertices);
        }

        public void RemoveDuplicates()
        {
            vertices.RemoveDuplicates();
        }
    }
}
