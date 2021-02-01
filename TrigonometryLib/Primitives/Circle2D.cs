
namespace TrigonometryLib.Primitives
{
    public class Circle2D : Primitive2D
    {
        public Vector2D center;
        public double radius;

        public Circle2D(double x, double y, double r)
            : this(new Vector2D(x, y), r)
        { }

        public Circle2D(Vector2D c, double r)
        {
            center = c;
            radius = r;
        }

        public bool IsInside(Vector2D v)
        {
            return (v - center).Mag() < radius;
        }
    }
}
