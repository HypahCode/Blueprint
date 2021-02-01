using System.Collections.Generic;
using TrigonometryLib.Primitives;

namespace TrigonometryLib.Triangulation
{
    public class EarClippingTriangulation
    {
        // https://www.geometrictools.com/Documentation/TriangulationByEarClipping.pdf
        private List<EarClippingShape> shapes = new List<EarClippingShape>();

        public void AddShape(Vector2D[] v)
        {
            EarClippingShape s = new EarClippingShape();
            for (int i = 0; i < v.Length; i++)
            {
                s.Add(v[i]);
            }
            shapes.Add(s);
        }

        public void Triangulate()
        {
            //MergeShapes();
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes[i].Triangulate();
            }
        }

        public List<Primitive2D> GetPrimitives()
        {
            List<Primitive2D> primList = new List<Primitive2D>();
            foreach (EarClippingShape s in shapes)
            {
                foreach (Triangle2D t in s.GetTriangles())
                {
                    primList.Add(t);
                }
                primList.Add(s);
            }
            return primList;
        }

        private void MergeShapes()
        {
            BuildShapeTree();
            MergeShapeTree();
        }

        private void MergeShapeTree()
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes[i].MergeShapeTree();
            }
        }

        private void BuildShapeTree()
        {
            throw new System.Exception("DOES NOT WORK");
            List<EarClippingShape> shapeList = new List<EarClippingShape>(shapes);
            List<EarClippingShape> shapeList2 = new List<EarClippingShape>(shapes);
            shapes.Clear();

            foreach (EarClippingShape shape in shapeList2)
            {
                Vector2D testVec = shape.FindMostRightVector();
                for (int i = 0; i < shapeList.Count; i++)
                {
                    if (shapeList[i].IsInside(testVec))
                    {
                        shapeList[i].childShapes.Add(shape);
                    }
                    else
                    {
                        shapes.Add(shapeList[0]);
                    }
                }
            }
        }
    }
}
