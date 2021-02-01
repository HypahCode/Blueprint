using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrigonometryLib.Primitives
{
    public class Primitive2D
    {
        private object data;

        public T GetData<T>()
        {
            return (T)data;
        }

        public void SetData(object d)
        {
            data = d;
        }
    }
}
