using System.Collections.Generic;
using TrigonometryLib.Primitives;

namespace BlueprintAddon
{
    internal class ObjectLinker
    {
        internal static object StartLinkingObjects(List<ILinkable> list, Vector2D location)
        {
            foreach (ILinkable l in list)
            {
                object o = l.StartLink(location);
                if (o != null)
                    return o;
            }
            return null;
        }

        internal static void EndLinkingObjects(List<ILinkable> list, Vector2D location, object linkObject)
        {
            foreach (ILinkable l in list)
            {
                if (l.EndLink(location, linkObject))
                    return;
            }
        }
    }
}
