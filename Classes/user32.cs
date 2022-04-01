using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Pinvoke
{
    public enum GetWindowType : uint
    {
        /// <summary>
        /// The retrieved handle identifies the window of the same type that is highest in the Z order.
        /// <para/>
        /// If the specified window is a topmost window, the handle identifies a topmost window.
        /// If the specified window is a top-level window, the handle identifies a top-level window.
        /// If the specified window is a child window, the handle identifies a sibling window.
        /// </summary>
        GW_HWNDFIRST = 0,
        /// <summary>
        /// The retrieved handle identifies the window of the same type that is lowest in the Z order.
        /// <para />
        /// If the specified window is a topmost window, the handle identifies a topmost window.
        /// If the specified window is a top-level window, the handle identifies a top-level window.
        /// If the specified window is a child window, the handle identifies a sibling window.
        /// </summary>
        GW_HWNDLAST = 1,
        /// <summary>
        /// The retrieved handle identifies the window below the specified window in the Z order.
        /// <para />
        /// If the specified window is a topmost window, the handle identifies a topmost window.
        /// If the specified window is a top-level window, the handle identifies a top-level window.
        /// If the specified window is a child window, the handle identifies a sibling window.
        /// </summary>
        GW_HWNDNEXT = 2,
        /// <summary>
        /// The retrieved handle identifies the window above the specified window in the Z order.
        /// <para />
        /// If the specified window is a topmost window, the handle identifies a topmost window.
        /// If the specified window is a top-level window, the handle identifies a top-level window.
        /// If the specified window is a child window, the handle identifies a sibling window.
        /// </summary>
        GW_HWNDPREV = 3,
        /// <summary>
        /// The retrieved handle identifies the specified window's owner window, if any.
        /// </summary>
        GW_OWNER = 4,
        /// <summary>
        /// The retrieved handle identifies the child window at the top of the Z order,
        /// if the specified window is a parent window; otherwise, the retrieved handle is NULL.
        /// The function examines only child windows of the specified window. It does not examine descendant windows.
        /// </summary>
        GW_CHILD = 5,
        /// <summary>
        /// The retrieved handle identifies the enabled popup window owned by the specified window (the
        /// search uses the first such window found using GW_HWNDNEXT); otherwise, if there are no enabled
        /// popup windows, the retrieved handle is that of the specified window.
        /// </summary>
        GW_ENABLEDPOPUP = 6
    }
    public enum zOrderOptions : int
    {      
        HWND_BOTTOM = 1,
        HWND_NOTOPMOST = -2,
        HWND_TOP = 0,     
        HWND_TOPMOST = -1
    }
    public enum WindowOptions : uint
    {
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_SHOWWINDOW = 0x0040
    }
    public enum WindowAffinity : uint
    {
        //Imposes no restrictions on where the window can be displayed.
        WDA_NONE = 0x00000000,
        //The window content is displayed only on a monitor. Everywhere else, the window appears with no content.
        WDA_MONITOR = 0x00000001,
        //The window is displayed only on a monitor. Everywhere else, the window does not appear at all. One use for this affinity is for windows that show video recording controls, so that the controls are not included in the capture.
        WDA_EXCLUDEFROMCAPTURE  = 0x00000011
    }

    public class User32 
    {
        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        public static extern IntPtr GetShellWindow();
        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        public static extern bool BlockInput(bool fBlockIt);
        [DllImport("user32.dll")]
        public static extern bool SetWindowDisplayAffinity(IntPtr WindowHandle, WindowAffinity Affinity);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr handle,StringBuilder lpString, int cch);

        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out Int32 ProcessId);

        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        public static extern Int32 GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowType uCmd);
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


// Call this way:
//SetWindowPos(theWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        
        /*
        [DllImport("user32.dll")]
        public static extern bool EnumDesktops(IntPtr hwinsta, EnumDesktopsDelegate lpEnumFunc, IntPtr lParam);

        public delegate bool EnumDesktopsDelegate(string desktop, IntPtr lParam);
        public static bool _enumDesktopCallback( string desktop, IntPtr lParam )
        {
            GCHandle gch       = GCHandle.FromIntPtr( lParam );
            IList<string> list = gch.Target as List<string>;

            if ( null == list ) {
            return (false);
            }

            list.Add( desktop );

            return (true);
        }

        public static int _doEnumDesktops()
        {
            IList<string> list       = new List<string>();
            GCHandle gch         = GCHandle.Alloc( list );
            EnumDesktopsDelegate childProc = _enumDesktopCallback;

            if (!EnumDesktops(IntPtr.Zero, childProc, GCHandle.ToIntPtr( gch ) ))
            {
            int e = Marshal.GetLastWin32Error();
            WriteLine( "EnumDesktops errno={0}",  e );
            return 1;
            }

            foreach ( string a in list ) {
            Console.WriteLine( a );
            }

            return 0;
        }  
        */
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc,GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
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