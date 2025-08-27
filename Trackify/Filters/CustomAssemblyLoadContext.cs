using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace Trackify.Web.Filters
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        private static IntPtr _nativeLibrary;

        public static void LoadUnmanagedLibrary(string path)
        {
            _nativeLibrary = NativeLibrary.Load(path);
        }
    }
}
