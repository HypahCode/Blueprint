using System.Drawing;
using TrigonometryLib.Primitives;

namespace Blueprint.RenderEngine
{
    internal class ScientificRenderer : Renderer
    {
        internal bool IsActive { get; set; }

        internal override void Draw(RenderContext context)
        {
            if (!IsActive)
                return;

            Font font = new Font("Arial", 10);

            double size = context.GridSize * context.DrawScale;
            while (size < 50)
                size += context.GridSize * context.DrawScale;

            double sizeX = size * 2.0f;
            double sizeY = size;

            for (double x = context.Location.x % sizeX; x < context.Panel.Width - 30; x += sizeX)
            {
                if (x > 30)
                {
                    Vector2D v = context.ScreenToPoint(x, 0.0f);
                    context.Graphics.DrawString(v.x.ToString("0"), font, Colors.ScientificText, new Vector2D(x, 4));
                }
            }

            for (double y = context.Location.y % sizeY; y < context.Panel.Height - 30; y += sizeY)
            {
                if (y > 30)
                {
                    Vector2D v = context.ScreenToPoint(0.0f, y);
                    context.Graphics.DrawString(v.y.ToString("0"), font, Colors.ScientificText, new Vector2D(4, y));
                }
            }
        }
    }
}
