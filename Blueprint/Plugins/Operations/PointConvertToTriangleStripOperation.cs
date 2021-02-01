using Blueprint.RenderEngine;
using Blueprint.VectorImagess;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.Operations
{
    [MenuExtensionUsagesAttribute("Point", "Convert to triangle strip")]
	public class PointConvertToTriangleStripOperation : OperationsBase
    {
		public void Execute (IVectorImageProvider imageProvider)
		{
			bool hasIntersections = false;
			VectorCloud2D cloud = new VectorCloud2D(imageProvider.CurrImage.GetPrimitives<Vector2D>());
			for (int i = 0; i < cloud.Count - 2; i++)
			{
				Vector2D v1 = cloud[i];
				Vector2D v2 = cloud[i + 1];
				Vector2D v3 = cloud[i + 2];

				int countEqual = 0;
				if (v1.IsPositionEqual(v2)) countEqual++;
				if (v1.IsPositionEqual(v3)) countEqual++;
				if (v2.IsPositionEqual(v3)) countEqual++;
				bool isJumpLine = countEqual > 0;
				if (isJumpLine)
				{
                    imageProvider.CurrImage.Add(new Line2D(v1, v2));
                    imageProvider.CurrImage.Add(new Line2D(v2, v3));
                    imageProvider.CurrImage.Add(new Line2D(v3, v1));
				}
				else
				{
					Triangle2D t = new Triangle2D(v1, v2, v3);
					if (CheckTriangleListIntersection (imageProvider.CurrImage, t)) 
					{
						hasIntersections = true;
						PrimitiveRenderData.Get (t).Color = Color.Lime;
						PrimitiveRenderData.Get (t.a).Color = Color.Lime;
						PrimitiveRenderData.Get (t.b).Color = Color.Lime;
						PrimitiveRenderData.Get (t.c).Color = Color.Lime;
					}
                    imageProvider.CurrImage.Add(t);
				}
			}
			if (hasIntersections) {
				MessageBox.Show ("Has intersections!!!!!!");
			}

		}

		private bool CheckTriangleListIntersection(VectorImage image, Triangle2D triangle)
		{
			bool isIntersecting = false;
			List<Triangle2D> triList = image.GetPrimitives<Triangle2D>();
			foreach (Triangle2D t in triList) 
			{
				if (t.Intersects (triangle))
				{
					isIntersecting = true;
					PrimitiveRenderData.Get (t).Color = Color.Lime;
					PrimitiveRenderData.Get (t.a).Color = Color.Lime;
					PrimitiveRenderData.Get (t.b).Color = Color.Lime;
					PrimitiveRenderData.Get (t.c).Color = Color.Lime;
				}
			}
			return isIntersecting;
		}
	}
}

