using TrigonometryLib.Primitives;

namespace BlueprintAddon
{
    public interface IRenderContext
    {
        int Width { get; }
        int Height { get; }
        IRenderProxy Graphics { get; }

        Vector2D Location { get; set; }
        double DrawScale { get; set; }
        double GridSize { get; set; }

        bool ShowPoints { get; set; }
        bool ShowLines { get; set; }
        bool ShowTriangles { get; set; }
        bool ShowFilledTriangles { get; set; }
        bool ShowShapes { get; set; }
        bool ShowCircles { get; set; }

        Vector2D PointToScreen(Vector2D v);
        Vector2D PointToScreen(double x, double y);
        Vector2D ScreenToPoint(Vector2D v);
        Vector2D ScreenToPoint(double x, double y);
        Vector2D GridSnap(Vector2D v);
    }
}
