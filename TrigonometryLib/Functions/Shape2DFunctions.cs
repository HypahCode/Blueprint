using System;
using System.Collections.Generic;
using TrigonometryLib.Primitives;

namespace TrigonometryLib.Functions
{
    public class Shape2DFunctions
    {
        public static bool IsSelfIntersecting(Shape2D shape)
        {
            return Line2DFunctions.IsIntersecting(shape.GetLines());
        }

        public static Shape2D CreateShapesFromLines(List<Line2D> lineList)
        {
            List<Shape2D> shapes = new List<Shape2D>();
            List<Line2D> tmpLines = new List<Line2D>(lineList);
            while (tmpLines.Count > 0)
            {
                List<Line2D> shapeLineList = ExtractOneLineShape(tmpLines, tmpLines[0]);
                Shape2D shape = new Shape2D(CreateLinkedVectorCloud(shapeLineList));
                shapes.Add(shape);
            }

            InsertHolesIntoShapes(shapes);
            return shapes[0];
        }

        private static VectorCloud2D CreateLinkedVectorCloud(List<Line2D> shapeLineList)
        {
            VectorCloud2D vc = new VectorCloud2D();
            for (int i = 0; i < shapeLineList.Count; i++)
                vc.Add(shapeLineList[i].Start);
            return vc;
        }

        private static void InsertHolesIntoShapes(List<Shape2D> shapes)
        {
            List<Shape2D> tmpList = new List<Shape2D>(shapes);
            for (int i = 0; i < tmpList.Count; i++)
            {
                Shape2D innerShape = tmpList[i];
                Vector2D innerPoint = innerShape.FindMostRightVector();
                for (int x = 0; x < shapes.Count; x++)
                {
                    Shape2D outerShape = shapes[x];
                    if (innerShape != outerShape)
                    {
                        if (outerShape.IsInside(innerPoint))
                        {
                            outerShape.Holes.Add(new Shape2D.Hole(innerShape));
                            shapes.Remove(innerShape);
                            break;
                        }
                    }
                }
            }
        }

        private static List<Line2D> ExtractOneLineShape(List<Line2D> lineList, Line2D line)
        {
            List<Line2D> tmpList = new List<Line2D>();
            Line2D l = null;
            while (line != null)
            {
                l = lineList.Find((x) => x.Start.IsPositionEqual(line.End));
                if (l == null)
                {
                    l = lineList.Find((x) => x.End.IsPositionEqual(line.End));
                    if (l != null)
                        l.Reverse();
                }

                if (l != null)
                {
                    tmpList.Add(l);
                    lineList.Remove(l);
                }
                line = l;
            }
            return tmpList;
        }
    }
}
