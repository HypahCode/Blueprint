using System;
using BlueprintAddon;
using TrigonometryLib.Primitives;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

namespace Blueprint
{
	public class WktRenderer : IRenderProxy
	{
		private StringBuilder wtkString = new StringBuilder ();

		public WktRenderer ()
		{
		}

		public void DrawPoint(Vector2D center, Color color, int width)
		{
			wtkString.Append (Vector2DToText (Vector2DToText (center))).Append(Environment.NewLine);
		}

		public void FillRectangle(Rectangle2D rect, Color color) { }
		void DrawLine(Vector2D a, Vector2D b, Color color, int width) { }
		public void DrawEllipse(int x1, int y1, int x2, int y2, Color color, int width) { }
		public void FillPolygon(Vector2D[] point, Color color) { }
		public void DrawEllipse(Rectangle2D rectangle, Color color, int v) { }
		public void DrawString(string text, Font font, Color color, Vector2D location) { }
		public Vector2D MeasureString(string text, Font font) { return new Vector2D (0.0f, 0.0f); }

		private static string Vector2DToText(Vector2D v)
		{
			return v.x.ToString() + " " + v.y.ToString();
		}

		private static string Line2DToText(Line2D l)
		{
			return Vector2DToText(l.Start) + ", " + Vector2DToText(l.End);
		}

		private static string Polygon2DToText(Shape2D s)
		{
			string result = "";
			List<Vector2D> points = new List<Vector2D>(s.GetPoints());
			for (int i = 0; i < points.Count; i++)
			{
				bool isLastPoint = i == points.Count - 1;
				result += Vector2DToText(points[i]) + (isLastPoint ? "" : ", ");
			}
			return result;
		}
	}
}

