using System.Collections.Generic;
using TrigonometryLib.Primitives;

namespace TrigonometryLib.Functions
{
    public class Line2DFunctions
    {
        public static List<Line2D> TestLineIntersections(List<Line2D> lines)
        {
            List<Line2D> intersectingLines = new List<Line2D>();
            Vector2D dummy;
            for (int i = 0; i < lines.Count; i++)
            {
                Line2D line = lines[i];
                for (int j = i + 1; j < lines.Count; j++)
                {
                    if ((line.Start != lines[j].End) && (line.End != lines[j].Start))
                    {
                        if (line.SafeIntersect(lines[j], out dummy))
                        {
                            if (intersectingLines.Find((x) => x == line) == null) intersectingLines.Add(line);
                            if (intersectingLines.Find((x) => x == lines[j]) == null) intersectingLines.Add(lines[j]);
                        }
                    }
                }
            }
            return intersectingLines;
        }

        public static bool IsIntersecting(List<Line2D> lines)
        {
            Vector2D dummy;
            for (int i = 0; i < lines.Count; i++)
            {
                Line2D line = lines[i];
                for (int j = i + 1; j < lines.Count; j++)
                {
                    if ((line.Start != lines[j].End) && (line.End != lines[j].Start))
                    {
                        if (line.Intersect(lines[j], out dummy))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
