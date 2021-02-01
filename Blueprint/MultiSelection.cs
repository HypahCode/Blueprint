using System.Collections.Generic;
using Blueprint.RenderEngine;
using Blueprint.VectorImagess;
using BlueprintAddon;
using TrigonometryLib.Primitives;

namespace Blueprint
{
    internal class MultiSelection
    {
        public List<Primitive2D> primitives = new List<Primitive2D>();

        internal void Add(Primitive2D p)
        {
            PrimitiveRenderData.Get(p).isSelected = true;
            primitives.Add(p);
        }

        internal void TogglePrimitive(Primitive2D p)
        {
            int idx = primitives.IndexOf(p);
            if (idx != -1)
            {
                PrimitiveRenderData.Get(primitives[idx]).isSelected = false;
                primitives.RemoveAt(idx);
            }
            else
            {
                Add(p);
            }
        }

        internal void Clear()
        {
            for (int i = 0; i < primitives.Count; i++)
            {
                PrimitiveRenderData.Get(primitives[i]).isSelected = false;
            }
            primitives.Clear();
        }

        internal void Move(Vector2D delta)
        {
            foreach (Primitive2D p in primitives)
            {
                if (p is Vector2D)
                    ((Vector2D)p).Move(delta);
                else if (p is ICompoundPrimitive2D)
                {
                    MoveCompoundPrimitive((ICompoundPrimitive2D)p, delta);
                }
                else if (p is ICustomSelectable)
                {
                    ((ICustomSelectable)p).Move(delta);
                }
            }
        }

        private void MoveCompoundPrimitive(ICompoundPrimitive2D primitive, Vector2D delta)
        {
            foreach (Primitive2D p in primitive.GetPrimitives())
            {
                if (p is Vector2D)
                {
                    if (primitives.IndexOf(p) == -1)
                        ((Vector2D)p).Move(delta);
                }
                else if (p is ICompoundPrimitive2D)
                {
                    MoveCompoundPrimitive((ICompoundPrimitive2D)p, delta);
                }
            }
        }

        internal void RemoveFromImage(VectorImage img)
        {
            for (int i = 0; i < primitives.Count; i++)
            {
                PrimitiveRenderData.Get(primitives[i]).isSelected = false;
                img.primitives.Remove(primitives[i]);
            }

            primitives.Clear();
        }
    }
}
