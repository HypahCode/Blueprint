using TrigonometryLib.Primitives;
using TrigonometryLib.Triangulation;

namespace Blueprint.Plugins.Operations
{
    [MenuExtensionUsagesAttribute("Shape", "Traingulate (ear clipping)")]
	public class ShapeTriangulateOperation : OperationsBase
    {
		public void Execute (IVectorImageProvider imageProvider)
		{
			EarClippingTriangulation earClipping = new EarClippingTriangulation();
			foreach (Shape2D p in imageProvider.CurrImage.GetPrimitives<Shape2D>())
			{
				earClipping.AddShape(imageProvider.CurrImage.GetPrimitives<Vector2D>().ToArray());
			}
			earClipping.Triangulate();
            imageProvider.CurrImage.Add(earClipping.GetPrimitives());
		}
	}
}

