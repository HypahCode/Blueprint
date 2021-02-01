using Blueprint.VectorImagess;

namespace Blueprint.Plugins
{
    public class PluginMenuProxy
	{
		private IVectorImageProvider imgProvider;

        public PluginMenuProxy(IVectorImageProvider imageProvider)
		{
			imgProvider = imageProvider;
        }

		public void Execute(PluginMenuExtension ext) 
		{
            ext.Execute(imgProvider);
		}
	}

	public interface PluginMenuExtension
	{
		void Execute(IVectorImageProvider image); 
	}
}

