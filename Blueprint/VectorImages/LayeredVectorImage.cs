using System.Collections.Generic;

namespace Blueprint.VectorImagess
{
    public class LayeredVectorImage
    {
        private List<VectorImage> layers = new List<VectorImage>();
        private int selectedLayer = 0;

        internal LayeredVectorImage()
        {
            AddLayer();
        }

        internal VectorImage Get(int index)
        {
            return layers[index];
        }

        internal VectorImage Image
        {
            get { return layers[selectedLayer]; }
        }

        internal void Set(VectorImage img)
        {
            selectedLayer = layers.IndexOf(img);
        }

        internal VectorImage AddLayer()
        {
            VectorImage img = new VectorImage();
            layers.Add(img);
            img.Name = "Layer " + layers.Count;
            return img;
        }

        internal void RemoveLayer(VectorImage img)
        {
            layers.Remove(img);
            if (layers.Count == 0)
                AddLayer();
            if (selectedLayer >= layers.Count)
                selectedLayer = layers.Count - 1;
        }

        internal int Count { get { return layers.Count; } }

    }
}
