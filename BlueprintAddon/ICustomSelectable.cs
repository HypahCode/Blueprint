using TrigonometryLib.Primitives;

namespace BlueprintAddon
{
    public interface ICustomSelectable
    {
        bool Select(Vector2D location, double zoomCorrection);
        void Move(Vector2D delta);
    }
}
