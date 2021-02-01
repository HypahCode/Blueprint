using System.Collections.Generic;
using TrigonometryLib.Primitives;

namespace Blueprint.VectorImages
{
    public class CompoundPrimitive : List<Primitive2D>, ICompoundPrimitive2D
    {
        public CompoundPrimitive()
            : base()
        { }

        public List<Primitive2D> GetPrimitives()
        {
            return this;
        }
    }
}
