using Blueprint.RenderEngine;
using System.Collections.Generic;
using TrigonometryLib.Functions;
using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.Operations
{
    [MenuExtensionUsages("Line", "Check intersections")]
	public class LinesCheckIntersectionsOperation : OperationsBase
    {
		public void Execute (IVectorImageProvider imageProvider)
		{
			List<Line2D> lines = Line2DFunctions.TestLineIntersections(imageProvider.CurrImage.GetPrimitives<Line2D>());
			foreach (Line2D l in lines)
			{
				PrimitiveRenderData.Get(l).Color = Colors.Line2DIntersection;
			}
		}
	}
}

