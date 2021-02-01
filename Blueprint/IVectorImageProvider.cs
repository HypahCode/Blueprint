using System;
using Blueprint.VectorImagess;

namespace Blueprint
{
	public interface IVectorImageProvider
	{
		VectorImage CurrImage { get; }
		LayeredVectorImage LayeredVectorImage { get; }
	}
}

