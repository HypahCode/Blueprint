using System;
using System.Collections.Generic;
using TrigonometryLib.Primitives;

namespace TrigonometryLib.Triangulation
{
    internal class EarClippingShape : Shape2D
    {
        private List<int> points = new List<int>();
        private List<int> convexVertices = new List<int>();
        private List<int> reflexVertices = new List<int>();

        private List<Triangle2D> triangles = new List<Triangle2D>();

        public List<EarClippingShape> childShapes = new List<EarClippingShape>();

        public EarClippingShape()
            : base()
        { }

        public void Triangulate()
        {
            FinalizeShape();
            PrepareForTriangulation();
            int counter = 100;
            while (points.Count > 2 && counter > 0)
            {
                RemovePoint();
                PrepareForTriangulation();

                counter--;
            }
            points.Clear();
        }

        public List<Triangle2D> GetTriangles()
        {
            return triangles;
        }

        private void FinalizeShape()
        {
            if (!IsClockwise())
                Rotate();

            for (int i = 0; i < vertices.Count; i++)
                points.Add(i);
        }

        private void PrepareForTriangulation()
        {
            convexVertices.Clear();
            reflexVertices.Clear();
            for (int i = 0; i < points.Count; i++)
            {
                double angle = CalcAngleForPoint(i);
                if (angle < Math.PI)
                {
                    Console.WriteLine("Convex: " + i + " - " + angle * 57.2958);
                    convexVertices.Add(i);
                }
                else
                {
                    Console.WriteLine("Reflex: " + i + " - " + angle * 57.2958);
                    reflexVertices.Add(i);
                }
            }
        }

        public void RemovePoint()
        {
            for (int i = 0; i < convexVertices.Count; i++)
            {
                int pIdx = convexVertices[i];
                int a = points[Mod(pIdx - 1, points.Count)];
                int b = points[pIdx];
                int c = points[Mod(pIdx + 1, points.Count)];

                Triangle2D t = new Triangle2D(GetVector(a), GetVector(b), GetVector(c));
                if (!IsReflexPointInsideTriangle(t, a, b, c))
                {
                    triangles.Add(t);
                    points.RemoveAt(pIdx);
                    break;
                }
            }
        }

        private bool IsReflexPointInsideTriangle(Triangle2D t, int a, int b, int c)
        {
            for (int i = 0; i < reflexVertices.Count; i++)
            {
                Vector2D p = GetPoint(reflexVertices[i]);
                if (t.IsInside(p))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsValid()
        {
            return points.Count >= 3;
        }

        public void MergeShapeTree()
        {
            for (int i = 0; i < childShapes.Count; i++)
            {
                childShapes[i].MergeShapeTree();

                if (IsClockwise() == childShapes[i].IsClockwise())
                    childShapes[i].Rotate();
            }

            for (int i = 0; i < childShapes.Count; i++)
            {
                Vector2D testVec = childShapes[i].FindMostRightVector();
                Line2D ray = new Line2D(testVec, testVec + new Vector2D(boundingRectangle.Width + 1.0f, 0.0f));

                Line2D l = FindClosestIntersectionLine(ray);
                int idx = vertices.IndexOf(l.Start);
                vertices.InsertRange(idx, childShapes[i].vertices);
            }
            childShapes.Clear();
        }

        private double CalcAngleForPoint(int i)
        {
            Line2D l1 = new Line2D(GetPoint(i - 1), GetPoint(i));
            Line2D l2 = new Line2D(GetPoint(i), GetPoint(i + 1));
            double a = l1.Angle(l2);
            if (a < 0.0f)
                a += (Math.PI * 2.0);

            return a;
        }

        private Vector2D GetPoint(int index)
        {
            int newIdx = Mod(index, points.Count);
            return vertices[points[newIdx]];
        }
    }
}
