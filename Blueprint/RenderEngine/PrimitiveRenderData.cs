using System.Drawing;
using TrigonometryLib.Primitives;

namespace Blueprint.RenderEngine
{
    public class PrimitiveRenderData
    {
        public bool isSelected = false;

        private Color color = Color.White;
        private bool isColorSet = false;

        public string Text { get; set; }

        public PrimitiveRenderData() { }

        public static PrimitiveRenderData Get(Primitive2D p)
        {
            PrimitiveRenderData data = p.GetData<PrimitiveRenderData>();
            if (data == null)
            {
                data = new PrimitiveRenderData();
                p.SetData(data);
            }
            return data;
        }

        public PrimitiveRenderData(Color c)
        {
            color = c;
            isColorSet = true;
        }

        public Color Color
        {
            get { return color; }
            set { color = value; isColorSet = true; }
        }

        public Color GetColor(Color defaultColor)
        {
            return isColorSet ? color : defaultColor;
        }
    }
}
