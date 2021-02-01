using System.Collections.Generic;
using System.Drawing;
using Blueprint.RenderEngine;
using Blueprint.VectorImagess;
using TrigonometryLib.Functions;
using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.ImportExport.WadLoader
{
    internal class LevelBuilder
    {
        internal static void BuildImage(VectorImage image, LevelReader level, double scale)
        {
            VectorCloud2D vc = new VectorCloud2D();
            for (int i = 0; i < level.vertices.Count; i++)
                vc.Add(new Vector2D(level.vertices[i].x, level.vertices[i].y));

            Dictionary<int, List<Line2D>> sectors = new Dictionary<int, List<Line2D>>();
            List<Line2D> lines = new List<Line2D>();
            foreach (LineDefType l in level.lineDefs)
            {
                Line2D line = new Line2D(vc[l.startVertex], vc[l.endVertex]);

                if (l.IsSecret) PrimitiveRenderData.Get(line).Color = Color.Yellow;
                else if (l.IsTwoSided) PrimitiveRenderData.Get(line).Color = Color.SandyBrown;
                else PrimitiveRenderData.Get(line).Color = Color.Red;

                lines.Add(line);

                AddLineToSector(sectors, level, l.rightSideDef, line);
                AddLineToSector(sectors, level, l.leftSideDef, line);
            }

            image.primitives.AddRange(vc);
            image.primitives.AddRange(lines);

            MakeShapesFromSectors(image, sectors);
        }

        private static void AddLineToSector(Dictionary<int, List<Line2D>> sectors, LevelReader level, int sideDefIndex, Line2D line)
        {
            if (sideDefIndex == -1)
                return;
                     
            int sectorIndex = level.sideDefs[sideDefIndex].sector;
            if (!sectors.ContainsKey(sectorIndex))
            {
                sectors[sectorIndex] = new List<Line2D>();
            }
            sectors[sectorIndex].Add(line);
        }

        private static void MakeShapesFromSectors(VectorImage image, Dictionary<int, List<Line2D>> sectors)
        {
            foreach (KeyValuePair<int, List<Line2D>> lines in sectors)
            {
                Shape2D shape = Shape2DFunctions.CreateShapesFromLines(lines.Value);
                PrimitiveRenderData.Get(shape).Text = "Sector: " + lines.Key;
                image.Add(shape);
            }
        }
    }
}
