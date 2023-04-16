using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using Pinvoke;

namespace Pinvoke.Logic
{
    public class UserDesktopLogic
    {

        private static bool _enumDesktopCallback(string desktop, IntPtr lParam)
        {
            GCHandle gch = GCHandle.FromIntPtr(lParam);
            IList<string> list = gch.Target as List<string>;
            if (null == list)
            {
                return (false);
            }

            list.Add(desktop);

            return (true);
        }
        private static int _doEnumDesktops()
        {
            IList<string> list = new List<string>();
            GCHandle gch = GCHandle.Alloc(list);
            EnumDesktopsDelegate childProc = _enumDesktopCallback;

            if (!User32.EnumDesktops(IntPtr.Zero, childProc, GCHandle.ToIntPtr(gch)))
            {
                int e = Marshal.GetLastWin32Error();
                return 1;
            }

            return 0;
        }

        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                User32.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        public static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }
    }
}