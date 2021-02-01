using TrigonometryLib.Primitives;

namespace Blueprint.Plugins.Operations
{
    [MenuExtensionUsages("Generate", "Random point cloud")]
	public class RandomPointCloudOperation : OperationsBase
    {
		public void Execute(IVectorImageProvider imageProvider)
		{
            imageProvider.CurrImage.Add(Tests.PointCloudCreator.Create(new Rectangle2D(-200, -200, 200, 200), 50));
		}
	}
}

