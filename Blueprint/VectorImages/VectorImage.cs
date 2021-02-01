using System.Collections.Generic;
using BlueprintAddon;
using TrigonometryLib.Primitives;

namespace Blueprint.VectorImagess
{
    public class VectorImage
    {
        public List<Primitive2D> primitives = new List<Primitive2D>();
        public string Name { get; set; }

        public void Add(Primitive2D p)
        {
            primitives.Add(p);
        }

        public void Add(List<Primitive2D> list)
        {
            primitives.AddRange(list);
        }

        internal void Add(List<Vector2D> pointCloud)
        {
            primitives.AddRange(pointCloud);
        }

        internal List<T> GetPrimitives<T>() where T : Primitive2D
        {
            List<T> list = new List<T>();
            foreach (Primitive2D primitive in primitives)
            {
                if (primitive is T)
                    list.Add((T)primitive);
            }
            return list;
        }

        internal List<ILinkable> GetLinkablePrimitives()
        {
            List<ILinkable> list = new List<ILinkable>();
            foreach (Primitive2D primitive in primitives)
            {
                if (primitive is ILinkable)
                    list.Add((ILinkable)primitive);
            }
            return list;
        }

        public List<Primitive2D> GetPrimitivesAtLocation(Vector2D loc, double offset)
        {
            List<Primitive2D> result = new List<Primitive2D>();
            result.AddRange(GetPointsAtLoction(loc, offset));
            Line2D l = GetlineAtLocation(loc, offset);
            if (l != null)
                result.Add(l);

            result.AddRange(GetCustomSelectableAtLocation(loc, offset));
            return result;
        }

        public VectorCloud2D GetPointsAtLoction(Vector2D loc, double offset)
        {
            Rectangle2D r = new Rectangle2D(loc - offset, loc + offset);
            VectorCloud2D result = new VectorCloud2D();
            for (int i = 0; i < primitives.Count; i++)
            {
                if (primitives[i] is Vector2D) FillVectorCloud(result, primitives[i] as Vector2D, r);
                else if (primitives[i] is Line2D) FillVectorCloud(result, primitives[i] as Line2D, r);
            }
            result.SortByDistance(loc);
            return result;
        }

        public Line2D GetlineAtLocation(Vector2D loc, double offset)
        {
            Line2D result = null;
            List<Line2D> lines = GetPrimitives<Line2D>();
            double distance = offset;

            foreach (Line2D l in lines)
            {
                Vector2D point = l.ClosestPoint(loc);

                double d = (point - loc).Mag();
                if (d < distance)
                {
                    distance = d;
                    result = l;
                }
            }

            return result;
        }

        public List<Primitive2D> GetCustomSelectableAtLocation(Vector2D loc, double offset)
        {
            List<Primitive2D> result = new List<Primitive2D>();
            foreach (Primitive2D p in primitives)
            {
                if ((p is ICustomSelectable) && (((ICustomSelectable)p).Select(loc, offset)))
                    result.Add(p);
            }
            return result;
        }

        internal Rectangle2D BoundingBox()
        {
            Rectangle2D bb = new Rectangle2D(new Vector2D(double.MaxValue), new Vector2D(double.MinValue));
            foreach (Primitive2D p in primitives)
            {
                if (p is Vector2D)
                    bb.Expand(p as Vector2D);
                else if (p is ICompoundPrimitive2D)
                    bb.Expand(p as ICompoundPrimitive2D);
            }
            if (bb.topLeft.x > bb.bottomRight.x)
                bb = new Rectangle2D(0, 0, 0, 0);
            return bb;
        }

        private void FillVectorCloud(VectorCloud2D cloud, Vector2D v, Rectangle2D bb)
        {
            if (bb.IsInside(v))
                cloud.Add(v);
        }

        private void FillVectorCloud(VectorCloud2D cloud, Line2D l, Rectangle2D bb)
        {
            if (bb.IsInside(l.Start))
                cloud.Add(l.Start);
            if (bb.IsInside(l.End))
                cloud.Add(l.End);
        }
    }
}
