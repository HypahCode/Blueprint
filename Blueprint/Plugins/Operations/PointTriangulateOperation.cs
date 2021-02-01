using TrigonometryLib.Primitives;
using TrigonometryLib.Triangulation;

namespace Blueprint.Plugins.Operations
{
    [MenuExtensionUsagesAttribute("Point", "Traingulate")]
	public class PointTriangulateOperation : OperationsBase
    {
		public void Execute (IVectorImageProvider imageProvider)
		{
			DelaunayTriangulation triangulator = new DelaunayTriangulation(new VectorCloud2D(imageProvider.CurrImage.GetPrimitives<Vector2D>()));
            imageProvider.CurrImage.primitives.AddRange(triangulator.Triangulate());
			/*
			foreach (Shape2D s in image.GetPrimitives<Shape2D>())
			{
				s.RemoveDuplicates();
			}
			*/
		}
	}
}

