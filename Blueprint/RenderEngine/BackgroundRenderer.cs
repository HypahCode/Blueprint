using System.Drawing;
using TrigonometryLib.Primitives;

namespace Blueprint.RenderEngine
{
    internal class BackgroundRenderer : Renderer
    {
        internal enum BackgroundStyle { BlueprintGrid, SolidColor };

        internal BackgroundStyle Style { get; set; }

        internal override void Draw(RenderContext context)
        {
            context.Graphics.FillRectangle(new Rectangle2D(0, 0, context.Panel.Width, context.Panel.Width), Colors.Background);

            if (Style == BackgroundStyle.BlueprintGrid)
            {
                double size = context.GridSize * context.DrawScale;
                if (size > 1)
                {
                    for (double x = context.Location.x % size; x < context.Panel.Width; x += size)
                    {
                        context.Graphics.DrawLine(new Vector2D(x, 0), new Vector2D(x, context.Panel.Height), Colors.Grid, 1);
                    }

                    for (double y = context.Location.y % size; y < context.Panel.Height; y += size)
                    {
                        context.Graphics.DrawLine(new Vector2D(0, y), new Vector2D(context.Panel.Width, y), Colors.Grid, 1);
                    }
                }

                Vector2D center = context.PointToScreen(0.0f, 0.0f);
                context.Graphics.DrawLine(new Vector2D(center.x, 0), new Vector2D(center.x, context.Panel.Height), Colors.GridMidLines, 2);
                context.Graphics.DrawLine(new Vector2D(0, center.y), new Vector2D(context.Panel.Width, center.y), Colors.GridMidLines, 2);
            }
        }
    }
}
