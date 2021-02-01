using System.IO;
using System.Runtime.InteropServices;

namespace Blueprint.Plugins.ImportExport.WadLoader
{
    internal class ByteArrayToType
    {
        public static T ByteArrayTo<T>(BinaryReader reader, int size)
        {
            byte[] bytes = reader.ReadBytes(size);

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return stuff;
        }
    }
}
