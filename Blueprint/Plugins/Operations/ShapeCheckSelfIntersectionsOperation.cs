using System.Collections.Generic;
using TrigonometryLib.Functions;
using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.Operations
{
    [MenuExtensionUsages("Shape", "Check self intersections")]
	public class ShapeCheckSelfIntersectionsOperation : OperationsBase
    {
		public void Execute (IVectorImageProvider imageProvider)
		{
			List<Line2D> lines = new List<Line2D>();
			foreach (Primitive2D p in imageProvider.CurrImage.primitives)
			{
				if (p is Shape2D)
				{
					lines.AddRange(Line2DFunctions.TestLineIntersections((p as Shape2D).GetLines()));
				}
			}
            imageProvider.CurrImage.primitives.AddRange(lines);
		}
	}
}

