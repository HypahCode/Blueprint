using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.Operations
{
    [MenuExtensionUsages("Shape", "Merge duplicates")]
	public class ShapeMergeOperation : OperationsBase
    {
		public void Execute (IVectorImageProvider imageProvider)
		{
			foreach (Shape2D s in imageProvider.CurrImage.GetPrimitives<Shape2D>())
			{
				s.RemoveDuplicates();
			}
		}
	}
}

