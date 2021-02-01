using System.Drawing;
using TrigonometryLib.Primitives;

namespace BlueprintAddon
{
    public interface IRenderProxy
    {
        void DrawPoint(Vector2D center, Color color, int width);
        void FillRectangle(Rectangle2D rect, Color color);
        void DrawLine(Vector2D a, Vector2D b, Color color, int width);
        void DrawEllipse(int x1, int y1, int x2, int y2, Color color, int width);
        void FillPolygon(Vector2D[] point, Color color);
        void DrawEllipse(Rectangle2D rectangle, Color color, int v);
        void DrawString(string text, Font font, Color color, Vector2D location);
        Vector2D MeasureString(string text, Font font);
    }
}
