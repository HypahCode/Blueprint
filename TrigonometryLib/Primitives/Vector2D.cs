using System;

namespace TrigonometryLib.Primitives
{
    public class Vector2D : Primitive2D
    {
        public double x;
		public double y;

        public Vector2D()
            : this(0.0f)
        { }

        public Vector2D(double xy)
            : this(xy, xy)
        { }

        public Vector2D(double  x, double  y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2D(Vector2D v)
            : this(v.x, v.y)
        { }

        public Vector2D Perpendicular {  get { return new Vector2D(y, -x); } }// Loodrecht

        public void Move(Vector2D delta)
        {
            x += delta.x;
            y += delta.y;
        }

        static public Vector2D operator +(Vector2D A, Vector2D B)
        {
            return new Vector2D(A.x + B.x, A.y + B.y);
        }

        static public Vector2D operator +(Vector2D A, double  B)
        {
            return new Vector2D(A.x + B, A.y + B);
        }

        static public Vector2D operator -(Vector2D A, Vector2D B)
        {
            return new Vector2D(A.x - B.x, A.y - B.y);
        }

        static public Vector2D operator -(Vector2D A, double  B)
        {
            return new Vector2D(A.x - B, A.y - B);
        }

        static public Vector2D operator -(Vector2D A)
        {
            return new Vector2D(-A.x, -A.y);
        }

        public bool IsPositionEqual(Vector2D other)
        {
            return (x == other.x) && (y == other.y);
        }

        static public Vector2D operator *(Vector2D A, Vector2D B)
        {
            return new Vector2D(A.x * B.x, A.y * B.y);
        }

        static public Vector2D operator *(Vector2D A, double  scale)
        {
            return new Vector2D(A.x * scale, A.y * scale);
        }

        static public Vector2D operator /(Vector2D A, Vector2D B)
        {
            return new Vector2D(A.x / B.x, A.y / B.y);
        }

        static public Vector2D operator /(Vector2D A, double  B)
        {
            return new Vector2D(A.x / B, A.y / B);
        }

        static public Vector2D operator /(double  A, Vector2D B)
        {
            return new Vector2D(A / B.x, A / B.y);
        }

        public double  Mag()
        {
            return (double )Math.Sqrt((double)((x * x) + (y * y)));
        }

        public double  LengthSquared()
        {
            return (x * x) + (y * y);
        }

        static public Vector2D Lerp(Vector2D A, Vector2D B, double  t)
        {
            return new Vector2D(A.x + (B.x - A.x) * t,
                               A.y + (B.y - A.y) * t);
        }

        static public double  Angle(Vector2D v1, Vector2D v2)
        {
            //double  DotProduct = Dot(Normalize(v1), Normalize(v2));
            //return Math.ArcCos(DotProduct);

            return (double )Math.Atan2((double)v1.y, (double)v1.x) - (double )Math.Atan2((double)v2.y, (double)v2.x);
        }

        public static double  Dot(Vector2D v1, Vector2D v2)
        {
            return ((v1.x * v2.x) + (v1.y * v2.y));
        }

        public static Vector2D Normalize(Vector2D v)
        {
            double  l = (double )Math.Sqrt((double)((v.x * v.x) + (v.y * v.y)));
            return new Vector2D(v.x / l, v.y / l);
        }

        public Vector2D Normal()
        {
            double  l = Mag();
            return new Vector2D(x / l, y / l);
        }

        public override string ToString()
        {
            return x.ToString() + ", " + y.ToString();
        }
    }
}
