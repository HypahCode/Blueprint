using System.Collections.Generic;

namespace TrigonometryLib.Primitives
{
    public class Rectangle2D : Primitive2D, ICompoundPrimitive2D
    {
        public Vector2D topLeft;
        public Vector2D bottomRight;


        public Rectangle2D(Rectangle2D r)
            : this(r.topLeft.x, r.topLeft.y, r.bottomRight.x, r.bottomRight.y)
        { }

        public Rectangle2D(double left, double top, double right, double bottom)
            : this(new Vector2D(left, top), new Vector2D(right, bottom))
        { }

        public Rectangle2D(Vector2D v)
            : this(new Vector2D(v), new Vector2D(v))
        { }

        public Rectangle2D(ICompoundPrimitive2D v)
            : this(new Vector2D(double.MaxValue), new Vector2D(double.MinValue))
        {
            v.GetPrimitives();
        }

        public Rectangle2D(Vector2D tl, Vector2D br)
        {
            topLeft = tl;
            bottomRight = br;
        }

        public double Width { get { return bottomRight.x - topLeft.x; } }
        public double Height { get { return bottomRight.y - topLeft.y; } }
        public Vector2D Size {  get { return bottomRight - topLeft; } }
        public Vector2D MidPoint { get { return (topLeft + bottomRight) / 2.0f; } }

        public Rectangle2D(Circle2D circle)
        {
            topLeft = circle.center - circle.radius;
            bottomRight = circle.center + circle.radius;
        }

        public bool IsInside(Vector2D v)
        {
            return ((v.x > topLeft.x) && (v.x <= bottomRight.x) &&
                    (v.y > topLeft.y) && (v.y <= bottomRight.y));
        }

        public void Expand(Vector2D v)
        {
            if (v.x < topLeft.x) topLeft.x = v.x;
            if (v.y < topLeft.y) topLeft.y = v.y;
            if (v.x > bottomRight.x) bottomRight.x = v.x;
            if (v.y > bottomRight.y) bottomRight.y = v.y;
        }

        public void Expand(ICompoundPrimitive2D primitive)
        {
            foreach (Primitive2D p in primitive.GetPrimitives())
            {
                if (p is Vector2D)
                {
                    Expand(p as Vector2D);
                }
            }
        }

        public void Move(Vector2D delta)
        {
            topLeft += delta;
            bottomRight += delta;
        }

        public List<Primitive2D> GetPrimitives()
        {
            return new List<Primitive2D>(new Primitive2D[] { topLeft, bottomRight });
        }
    }
}
