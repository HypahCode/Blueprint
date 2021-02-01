using System;
using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.ImportExport.CsvLoader
{
    public class CsvReader
    {
		private enum ReadMode { Absolute, Relative }

		private Vector2D incPoint = new Vector2D(0.0f, 0.0f);
		private VectorCloud2D cloud = new VectorCloud2D ();
		private ReadMode readMode = ReadMode.Absolute;

		public CsvReader (string filename)
		{
			string[] lines = System.IO.File.ReadAllLines (filename);
			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i].Trim();
				if (line.StartsWith("#") || line.StartsWith("//"))
				{
						continue;
				}
				string lineLower = line.ToLower ();
				if (lineLower.StartsWith("abs")) readMode = ReadMode.Absolute;
				if (lineLower.StartsWith("relative")) readMode = ReadMode.Relative;
				if (lineLower.StartsWith("inc")) readMode = ReadMode.Relative;
				if (line.IndexOf (',') > 0)
				{
					ReadPoint(line);
				}
			}
		}

        public VectorCloud2D GetPoints()
		{
			return cloud;
		}

		private void ReadPoint(string s)
		{
			string[] strings = s.Split(',');
			double x = Single.Parse (strings [0].Trim ());
			double y = Single.Parse (strings [1].Trim ());
			Vector2D v = new Vector2D (x, y);
			switch (readMode)
			{
			case ReadMode.Absolute:
				{
					cloud.Add (v);
				}
				break;
			case ReadMode.Relative:
				{
					incPoint.Move (v);
					cloud.Add (new Vector2D (incPoint));
				}
				break;
			}
		}
	}
}

