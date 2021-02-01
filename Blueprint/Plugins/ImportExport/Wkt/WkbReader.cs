using Blueprint.VectorImagess;
using System;
using System.Globalization;
using System.IO;
using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.ImportExport.Wkt
{
    internal class WkbReader
    {
        private byte[] data;

        public WkbReader(string hexString)
        {
            data = ConvertHexStringToByteArray(hexString);
        }
        
        public void LoadIntoImage(VectorImage image, bool invertY)
        {
            using (WkbStreamReader wkbReader = new WkbStreamReader(new MemoryStream(data)))
            {
                wkbReader.InvertY = invertY;
                while (wkbReader.BaseStream.Position < data.Length)
                {
                    wkbReader.SetByteOrder(wkbReader.ReadByte());
                    ReadGeometry(wkbReader, image);
                }
            }
        }

        private void ReadGeometry(WkbStreamReader wkbReader, VectorImage image)
        {
            int geometryType = wkbReader.ReadInt32();
            int dimensionRaw = geometryType / 1000;
            int geoType = geometryType - (dimensionRaw * 1000);

            wkbReader.Dimension = 2;
            if (dimensionRaw == 1) wkbReader.Dimension = 3;
            if (dimensionRaw == 2) wkbReader.Dimension = 3;
            if (dimensionRaw == 3) wkbReader.Dimension = 4;

            int numPoints = -1;

            switch (geoType)
            {
                case 1:
                    image.Add(wkbReader.ReadPoint());
                    break;
                case 2:
                    numPoints = wkbReader.ReadInt32();
                    CreateLinesFromPointCloud(image, wkbReader.ReadPointCloud(numPoints));
                    break;
                case 3:
                    int numRings = wkbReader.ReadInt32();
                    for (int i = 0; i < numRings; i++)
                    {
                        numPoints = wkbReader.ReadInt32();
                        image.Add(new Shape2D(wkbReader.ReadPointCloud(numPoints)));
                    }
                    break;
            }

            /*geoType
            Geometry                 00
            Point                    01
            LineString               02
            Polygon                  03
            MultiPoint               04
            MultiLineString          05
            MultiPolygon             06
            GeometryCollection       07
            CircularString           08
            CompoundCurve            09
            CurvePolygon             10
            MultiCurve               11
            MultiSurface             12
            Curve                    13
            Surface                  14
            PolyhedralSurface        15
            TIN                      16
            Triangle                 17
            */
        }

        private void CreateLinesFromPointCloud(VectorImage image, VectorCloud2D cloud)
        {
            for (int i = 0; i < cloud.Count - 1; i++)
            {
                image.Add(new Line2D(cloud[i], cloud[i + 1]));
            }
        }

        private static byte[] ConvertHexStringToByteArray(string hexString)
        {
            hexString = hexString.Replace("\r", "");
            hexString = hexString.Replace("\n", "");

            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }
    }
}
