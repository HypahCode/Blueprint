using System;
using System.IO;
using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.ImportExport.Wkt
{
    internal sealed class WkbStreamReader : BinaryReader
    {
        bool isReversingBits = false;
        bool isLittleEndian = false;

        public WkbStreamReader(Stream input)
            : base(input)
        {
            Dimension = -1;
            IsLittleEndian = true;
            InvertY = false;
        }

        public bool IsLittleEndian
        {
            get { return isLittleEndian; }
            set
            {
                isLittleEndian = value;
                isReversingBits = !BitConverter.IsLittleEndian == isLittleEndian;
            }
        }
        public int Dimension { get; set; }
        public bool InvertY { get; set; }

        public VectorCloud2D ReadPointCloud(int count)
        {
            VectorCloud2D cloud = new VectorCloud2D();
            for (int i = 0; i < count; i++)
            {
                cloud.Add(ReadPoint());
            }
            return cloud;
        }

        internal void SetByteOrder(byte raw)
        {
            if (raw == 0)
            {
                IsLittleEndian = false;
            }
            else if (raw == 1)
            {
                IsLittleEndian = true;
            }
            else
            {
                throw new Exception("Invalid hex string, could not determin big or little endinan");
            }
        }

        public Vector2D ReadPoint()
        {
            double x = 0.0;
            double y = 0.0;

            if (Dimension > 0) x = ReadDouble(ReadBytes(8));
            if (Dimension > 1) y = ReadDouble(ReadBytes(8));
            if (Dimension > 2) ReadBytes(8);
            if (Dimension > 3) ReadBytes(8);

            if (InvertY)
                y = -y;

            return new Vector2D(x, y);
        }

        public double ReadDouble(byte[] data)
        {
            if (isReversingBits)
                Array.Reverse(data);

            return BitConverter.ToDouble(data, 0);
        }
    }
}
