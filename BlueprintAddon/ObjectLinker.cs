using System.Collections.Generic;
using BlueprintAddon;
using TrigonometryLib.Primitives;

namespace Blueprint
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
    }
}
