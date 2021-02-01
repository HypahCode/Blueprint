using System;
using System.Collections.Generic;
using Blueprint.RenderEngine;
using Blueprint.VectorImagess;
using TrigonometryLib.Primitives;

namespace Blueprint.ImportExport.Wkt.WktLoader
{
    internal class WktReader
    {
        private class ImageProxy
        {
            private LayeredVectorImage image;
            private bool incermental;
            public LayeredVectorImage Image { get { return image; } }
            private Vector2D incVec = new Vector2D(0.0, 0.0);

            public ImageProxy(LayeredVectorImage img, bool inc)
            {
                image = img;
                incermental = inc;

            }
            public Vector2D IncermentVec(Vector2D v)
            {
                if (incermental)
                {
                    v = v + incVec;
                    incVec = new Vector2D(v);
                }
                return v;
            }
        }


		private class WktNumList
		{
			public string label = "";
			public List<double> numbers = new List<double>();

			public WktNumList(string s)
			{
				string[] nums = s.Split(' ');
				for (int i = 0; i < nums.Length; i++)
				{
					double val;
					if (Double.TryParse(nums[i], out val))
					{
						numbers.Add(val);
					}
					else
					{
						label += nums[i];
					}
				}
			}
		}

        private class WktItemReader
        {
            public int bracketCount = 0;
            protected ImageProxy image;
            protected WktReader reader;
            public WktItemReader(ImageProxy img, WktReader reader)
            {
                image = img;
                this.reader = reader;
            }
            public void ReadItem(string s)
            {
                s = s.Trim();
				if (s != "")
				{
					if (s == "NEW LAYER")
					{
						image.Image.Set(image.Image.AddLayer());
					}
					else
					{
						Read(s);
					}
				}
            }

            protected Vector2D GetVector(string s, bool autoAdd)
            {
				WktNumList nums = new WktNumList (s);
				if (nums.numbers.Count >= 2)
                {
					Vector2D v = new Vector2D(nums.numbers[0], nums.numbers[1]);
                    v /= reader.scaleDivider;
                    if (reader.flipYAxis)
                        v.y = -v.y;
                    if (nums.label != "")
                        PrimitiveRenderData.Get(v).Text = nums.label;
                    v = image.IncermentVec(v);
                    if (autoAdd)
                        image.Image.Image.Add(v);
                    return v;
                }
                return null;
            }

            protected virtual void Read(string s) { }
            public virtual void RoundBracketOpen() { bracketCount++; }
            public virtual bool RoundBracketClose()
            {
                bracketCount--;
                return bracketCount == 0;
            }
        }


        private class WktPointReader : WktItemReader
        {
            public WktPointReader(ImageProxy img, WktReader reader) : base(img, reader) { }
            protected override void Read(string s)
            {
                GetVector(s, true);
            }
            public override bool RoundBracketClose()
            {
                return base.RoundBracketClose();
            }
        }

        private class WktLineStringReader : WktItemReader
        {
            private VectorCloud2D line = new VectorCloud2D();
            public WktLineStringReader(ImageProxy img, WktReader reader) : base(img, reader) { }
            protected override void Read(string s)
            {
                Vector2D v = GetVector(s, true);
                if (v != null)
                    line.Add(v);
            }
            public override bool RoundBracketClose()
            {
                for (int i = 0; i < line.Count - 1; i++)
                    image.Image.Image.Add(new Line2D(line[i], line[i + 1]));
                line.Clear();

                return base.RoundBracketClose();
            }
        }

        private class WktPolygonReader : WktItemReader
        {
            private VectorCloud2D polygon = new VectorCloud2D();
            public WktPolygonReader(ImageProxy img, WktReader reader) : base(img, reader) { }
            protected override void Read(string s)
            {
				Vector2D v = GetVector(s, false);
				if (v != null)
					polygon.Add(v);
            }
            public override bool RoundBracketClose()
            {
                image.Image.Image.Add(new Shape2D(polygon));
                polygon.Clear();

                return base.RoundBracketClose();
            }
        }

        public static void ReadFile(LayeredVectorImage img,  string filename, double scaleDiv, bool flipYAxis, bool incermentalLoad)
        {
            WktReader reader = new WktReader(img, filename, scaleDiv, flipYAxis, incermentalLoad);
            string text = System.IO.File.ReadAllText(filename);
            reader.Read(text);
        }

        public static void ReadText(LayeredVectorImage img, string text, double scaleDiv, bool flipYAxis, bool incermentalLoad)
        {
			WktReader reader = new WktReader(img, "Memory", scaleDiv, flipYAxis, incermentalLoad);
            reader.Read(text);
        }

        private WktItemReader wktReader = null;
        private LayeredVectorImage vectorImg;
        private ImageProxy imagePxory;
        private bool flipYAxis;
        private bool incermentalCoordLoad;
        private double scaleDivider;
        private WktReader(LayeredVectorImage vecImg, string fname, double scaleDiv, bool flipY, bool incermentalLoad)
        {
            vectorImg = vecImg;
            scaleDivider = scaleDiv;
            flipYAxis = flipY;
            incermentalCoordLoad = incermentalLoad;
            imagePxory = new ImageProxy(vecImg, incermentalLoad);
        }

        private void Read(string wktStr)
        {
            string s = "";
            for (int i = 0; i < wktStr.Length; i++)
            {
                if (((wktStr[i] == ' ' || wktStr[i] == '\n')) && (wktReader == null))
                {
                    wktReader = BuildReader(s);
                    s = "";
                }
                else if (wktStr[i] == '(')
                {
                    if (wktReader == null) wktReader = BuildReader(s);
                    if (wktReader != null)
                    {
                        wktReader.ReadItem(s);
                        wktReader.RoundBracketOpen();
                    }
					s = "";
                }
                else if ((wktStr[i] == ')') && (wktReader != null))
                {
                    wktReader.ReadItem(s);
                    if (wktReader.RoundBracketClose())
                        wktReader = null;
                    s = "";
                }
                else if ((wktStr[i] == ',') && (wktReader != null))
                {
                    wktReader.ReadItem(s);
                    s = "";
                }
                else
                {
                    s += wktStr[i];
                }
            }
        }

        private WktItemReader BuildReader(string s)
        {
            if (s == "POINT") return new WktPointReader(imagePxory, this);
            if (s == "MULTIPOINT") return new WktPointReader(imagePxory, this);
            if (s == "LINESTRING") return new WktLineStringReader(imagePxory, this);
            if (s == "MULTILINESTRING") return new WktLineStringReader(imagePxory, this);
            if (s == "POLYGON") return new WktPolygonReader(imagePxory, this);
            if (s == "MULTIPOLYGON") return new WktPolygonReader(imagePxory, this);
            return null;
        }
    }
}
