using System.Collections.Generic;
using System.IO;

namespace Blueprint.Plugins.ImportExport.WadLoader
{
    internal class WadReader
    {
        private int lumpCount = 0;
        private int infoTableOfs = 0;

        internal List<LumpFile> fileList = new List<LumpFile>();
        internal List<Level> levels = new List<Level>();

        internal void ReadLumps(BinaryReader reader)
        {
            if (!ReadIWADHeader(reader)) return;
            ReadLumpCount(reader);
            ReadInfoTableOfs(reader);
            ReadDirectory(reader);
            DetectLevels();
        }

        /*
        internal void WriteTextureBitmaps(BinaryReader reader, string outputDir)
        {
            TextureReader tr = new TextureReader();

            LumpFile textures = fileList.Find((x) => x.name == "TEXTURE1");
            tr.ReadTextures(reader, textures);
        }
        */
        internal void DumpLumpNames()
        {
            foreach (LumpFile f in fileList)
                System.Console.WriteLine("Wad loader " + f.name);
        }

        private bool ReadIWADHeader(BinaryReader reader)
        {
            string wad = ReadString(reader, 4);
            if (wad == "IWAD")
                System.Console.WriteLine("File is IWAD");
            else if (wad == "PWAD")
                System.Console.WriteLine("File is PWAD");
            else
                return false;
            return true;
        }

        private void ReadLumpCount(BinaryReader reader)
        {
            lumpCount = reader.ReadInt32();
            System.Console.WriteLine("Lump count is " + lumpCount.ToString());
        }

        private void ReadInfoTableOfs(BinaryReader reader)
        {
            infoTableOfs = reader.ReadInt32();
            System.Console.WriteLine("InfoTableOfs is " + infoTableOfs.ToString());
        }

        private void ReadDirectory(BinaryReader reader)
        {
            reader.BaseStream.Seek(infoTableOfs, 0);

            for (int i = 0; i < lumpCount; i++)
            {
                LumpFile f = new LumpFile();
                f.pos = reader.ReadInt32();
                f.size = reader.ReadInt32();
                f.name = ReadString(reader, 8);

                fileList.Add(f);
            }
        }

        private void DetectLevels()
        {
            Level l = null;
            for (int i = 0; i < fileList.Count - 1; i++)
            {
                if (fileList[i].size == 0)
                {
                    if (fileList[i + 1].name == "THINGS")
                    {
                        System.Console.WriteLine("Level found: " + fileList[i].name);

                        if (l != null)
                            levels.Add(l);
                        l = new Level();
                        l.name = fileList[i].name;
                    }
                }
                if (fileList[i].name == "THINGS") l.things = fileList[i];
                if (fileList[i].name == "LINEDEFS") l.lineDefs = fileList[i];
                if (fileList[i].name == "SIDEDEFS") l.sideDefs = fileList[i];
                if (fileList[i].name == "VERTEXES") l.vertexEs = fileList[i];
                if (fileList[i].name == "SEGS") l.segs = fileList[i];
                if (fileList[i].name == "SSECTORS") l.sSectors = fileList[i];
                if (fileList[i].name == "NODES") l.nodes = fileList[i];
                if (fileList[i].name == "SECTORS") l.sectors = fileList[i];
                if (fileList[i].name == "REJECT") l.reject = fileList[i];
                if (fileList[i].name == "BLOCKMAP") l.blockMap = fileList[i];
                if (fileList[i].name == "BEHAVIOR") l.behavior = fileList[i];
            }
            if (l != null)
            {
                levels.Add(l);
            }
        }

        private string ReadString(BinaryReader reader, int maxSize)
        {
            string s = "";
            bool isEndOfString = false;
            for (int i = 0; i < maxSize; i++)
            {
                byte b = reader.ReadByte();
                if (b == 0)
                    isEndOfString = true;

                if (!isEndOfString)
                    s += (char)b;
            }
            return s;
        }
    }
}
