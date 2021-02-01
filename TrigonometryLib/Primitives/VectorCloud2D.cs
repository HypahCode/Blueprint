using System;
using System.Collections.Generic;

namespace TrigonometryLib.Primitives
{
    public class VectorCloud2D : List<Vector2D>
    {
        public VectorCloud2D()
            : base()
        { }

        public VectorCloud2D(IEnumerable<Vector2D> collection)
            : base(collection)
        { }

        public void SortByDistance(Vector2D origin)
        {
            Sort((a, b) => (a - origin).Mag().CompareTo((b - origin).Mag()));
        }

        public void SortByX()
        {
            Sort((a, b) => (a.x != b.x) ? a.x.CompareTo(b.x) : a.y.CompareTo(b.y));
        }

        public void SortByY()
        {
            Sort((a, b) => (a.y != b.y) ? a.y.CompareTo(b.y) : a.x.CompareTo(b.x));
        }

        public void Rotate()
        {
            Reverse();
        }

        public Vector2D FindMostRightPoint()
        {
            if (Count == 0)
                return null;

            Vector2D result = this[0];
            foreach (Vector2D v in this)
            {
                if (v.x > result.x)
                {
                    result = v;
                }
            }
            return result;
        }

        public void RemoveDuplicates()
        {
            List<int> duplicates = new List<int>();
            for (int x = 0; x < Count; x++)
            {
                for (int y = x; y < Count; y++)
                {
                    duplicates.Add(y);
                }
            }
            duplicates.Sort();
            for (int i = duplicates.Count -1; i >= 0; i--)
            {
                RemoveAt(duplicates[i]);
            }
        }
    }
}
