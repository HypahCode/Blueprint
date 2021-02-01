using TrigonometryLib.Primitives;

namespace BlueprintAddon
{
    public interface ILinkable
    {
        object StartLink(Vector2D location);
        bool EndLink(Vector2D location, object linkObject);
    }
}
