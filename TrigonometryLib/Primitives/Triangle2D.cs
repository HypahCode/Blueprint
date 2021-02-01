using System.Collections.Generic;

namespace TrigonometryLib.Primitives
{
    public class Triangle2D : Primitive2D, ICompoundPrimitive2D
    {
        public Vector2D a;
        public Vector2D b;
        public Vector2D c;

        public Triangle2D(Vector2D a, Vector2D b, Vector2D c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Line2D EdgeAB { get { return new Line2D(a, b); } }
        public Line2D EdgeBC { get { return new Line2D(b, c); } }
        public Line2D EdgeCA { get { return new Line2D(c, a); } }

        public Vector2D Center
        {
            get { return (a + b + c) / 3.0f; }
        }

        public Circle2D CircleTroughPoints()
        {
            Line2D perpendicularAB = new Line2D(EdgeAB.Center, (EdgeAB.Direction.Perpendicular) + EdgeAB.Center);
            Line2D perpendicularBC = new Line2D(EdgeBC.Center, (EdgeBC.Direction.Perpendicular) + EdgeBC.Center);

            Vector2D center;
            if (perpendicularAB.IntersectInfinite(perpendicularBC, out center))
            {
                return new Circle2D(center, (a - center).Mag());
            }
            return null;
        }

        public Rectangle2D BoudingRectangle()
        {
            Vector2D min = new Vector2D(Min(Min(a.x, b.x), c.x), Min(Min(a.y, b.y), c.y));
            Vector2D max = new Vector2D(Max(Max(a.x, b.x), c.x), Max(Max(a.y, b.y), c.y));

            return new Rectangle2D(min, max);
        }

        public bool IsInside(Vector2D v)
        {
            bool b1 = Sign(v, a, b) < 0.0f;
            bool b2 = Sign(v, b, c) < 0.0f;
            bool b3 = Sign(v, c, a) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }

        private double Sign(Vector2D p1, Vector2D p2, Vector2D p3)
        {
            return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
        }

        private double Min(double x, double y)
        {
            return (x < y) ? x : y;
        }

        private double Max(double x, double y)
        {
            return (x > y) ? x : y;
        }

        public List<Primitive2D> GetPrimitives()
        {
            return new List<Primitive2D>(new Vector2D[] { a, b, c });
        }

		public bool Intersects(Line2D line)
		{
			return EdgeAB.SafeIntersect(line) || EdgeBC.SafeIntersect(line) || EdgeCA.SafeIntersect(line);
		}

		public bool Intersects(Triangle2D other)
		{
			return Intersects (other.EdgeAB) || Intersects (other.EdgeBC) || Intersects (other.EdgeCA);
		}
    }
}
