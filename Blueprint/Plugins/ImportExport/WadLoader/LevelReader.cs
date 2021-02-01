using System;
using System.Collections.Generic;
using System.IO;

namespace Blueprint.Plugins.ImportExport.WadLoader
{
    internal class LevelReader
    {
        internal Level levelData;
        internal List<VertexType> vertices = new List<VertexType>();
        internal List<LineDefType> lineDefs = new List<LineDefType>();
        internal List<ThingType> things = new List<ThingType>();
        internal List<SectorType> sectors = new List<SectorType>();
        internal List<SideDefType> sideDefs = new List<SideDefType>();

        internal LevelReader(Level data)
        {
            levelData = data;
        }

        internal void ReadData(BinaryReader reader)
        {
            Console.WriteLine("Start reader level " + levelData.name);
            ReadVertices(reader);
            ReadSideDefs(reader);
            ReadLineDefs(reader);
            ReadSectors(reader);
            ReadThings(reader);
        }

        internal void ReadVertices(BinaryReader reader)
        {
            int count = levelData.vertexEs.SeekAndGetCount(reader, VertexType.Size);
            Console.WriteLine("  Vertex count " + count.ToString());

            for (int i = 0; i < count; i++)
            {
                VertexType v = ByteArrayToType.ByteArrayTo<VertexType>(reader, VertexType.Size);
                vertices.Add(v);
            }
        }

        internal void ReadSideDefs(BinaryReader reader)
        {
            int count = levelData.sideDefs.SeekAndGetCount(reader, SideDefType.Size);
            Console.WriteLine("  Side defs count " + count.ToString());

            for (int i = 0; i < count; i++)
            {
                SideDefType l = ByteArrayToType.ByteArrayTo<SideDefType>(reader, SideDefType.Size);
                sideDefs.Add(l);
            }
        }

        internal void ReadLineDefs(BinaryReader reader)
        {
            int count = levelData.lineDefs.SeekAndGetCount(reader, LineDefType.Size);
            Console.WriteLine("  Line defs count " + count.ToString());

            for (int i = 0; i < count; i++)
            {
                LineDefType l = ByteArrayToType.ByteArrayTo<LineDefType>(reader, LineDefType.Size);
                lineDefs.Add(l);
            }
        }

        private void ReadThings(BinaryReader reader)
        {
            int count = levelData.things.SeekAndGetCount(reader, ThingType.Size);
            Console.WriteLine("  Things count " + count.ToString());

            for (int i = 0; i < count; i++)
            {
                ThingType t = ByteArrayToType.ByteArrayTo<ThingType>(reader, ThingType.Size);
                things.Add(t);
            }
        }

        private void ReadSectors(BinaryReader reader)
        {
            int count = levelData.sectors.SeekAndGetCount(reader, SectorType.Size);
            Console.WriteLine("  Sectors count " + count.ToString());

            for (int i = 0; i < count; i++)
            {
                SectorType s = ByteArrayToType.ByteArrayTo<SectorType>(reader, SectorType.Size);
                sectors.Add(s);
            }
        }
    }
}
