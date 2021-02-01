using System.IO;
using System.Runtime.InteropServices;

namespace Blueprint.Plugins.ImportExport.WadLoader
{
    internal class LumpFile
    {
        public int pos;
        public int size;
        public string name;

        public void Seek(BinaryReader reader)
        {
            reader.BaseStream.Seek(pos, SeekOrigin.Begin);
        }

        public int SeekAndGetCount(BinaryReader reader, int lumpSize)
        {
            Seek(reader);
            return size / lumpSize;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct VertexType
    {
        public short x;
        public short y;

        public static int Size { get { return 4; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct LineDefType
    {
        public short startVertex;
        public short endVertex;
        public short flags;
        public short special;
        public short sectorTag;
        public short rightSideDef;
        public short leftSideDef;

        public static int Size { get { return 14; } }
        public bool IsTwoSided { get { return (flags & 0x0004) == 0x0004; } }
        public bool IsSecret { get { return (flags & 0x0020) == 0x0020; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ThingType
    {
        public short x;
        public short y;
        public short angleFacing;
        public short doomEdThingType;
        public short flags;

        public static int Size { get { return 10; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SectorType
    {
        public short floorHeight;
        public short ceilingHeight;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] floorTexture;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] ceilingTexture;

        public short lightLevel;
        public short type; // light stuff, pain-zone etc
        public short tagNumber;

        public static int Size { get { return 26; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SideDefType
    {
        public short offsetX;
        public short offsetY;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] upperTexture;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] lowerTexture;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] middleTexture;

        public short sector;

        public static int Size { get { return 30; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct MapTextureType
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] name;

        public int masked;
        public short width;
        public short height;
        public int columndirectory; // Obsolete, ignored by all DOOM versions
        public short patchcount;

        public static int Size { get { return 22; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct MapPatchType
    {
        public short originX;
        public short originY;
        public short patch;
        public short stepdir;
        public short colormap;

        public static int Size { get { return 10; } }
    }

    internal class Level
    {
        public string name;
        public LumpFile things = null;
        public LumpFile lineDefs = null;
        public LumpFile sideDefs = null;
        public LumpFile vertexEs = null;
        public LumpFile segs = null;
        public LumpFile sSectors = null;
        public LumpFile nodes = null;
        public LumpFile sectors = null;
        public LumpFile reject = null;
        public LumpFile blockMap = null;
        public LumpFile behavior = null;

        public override string ToString()
        {
            return name;
        }
    }
}
