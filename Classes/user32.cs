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
        WDA_EXCLUDEFROMCAPTURE = 0x00000011
    }
    public enum WindowShowStyle : uint
    {
        /// <summary>Hides the window and activates another window.</summary>
        SW_HIDE = 0,

        /// <summary>Activates and displays a window. If the window is minimized
        /// or maximized, the system restores it to its original size and
        /// position. An application should specify this flag when displaying
        /// the window for the first time.</summary>
        SW_SHOWNORMAL = 1,

        /// <summary>Activates the window and displays it as a minimized window.</summary>
        SW_SHOWMINIMIZED = 2,

        /// <summary>Activates the window and displays it as a maximized window.</summary>
        SW_SHOWMAXIMIZED = 3,

        /// <summary>Maximizes the specified window.</summary>
        SW_MAXIMIZE = 3,

        /// <summary>Displays a window in its most recent size and position.
        /// This value is similar to "ShowNormal", except the window is not
        /// actived.</summary>
        SW_SHOWNOACTIVATE = 4,

        /// <summary>Activates the window and displays it in its current size
        /// and position.</summary>
        SW_SHOW = 5,

        /// <summary>Minimizes the specified window and activates the next
        /// top-level window in the Z order.</summary>
        SW_MINIMIZE = 6,

        /// <summary>Displays the window as a minimized window. This value is
        /// similar to "ShowMinimized", except the window is not activated.</summary>
        SW_SHOWMINNOACTIVE = 7,

        /// <summary>Displays the window in its current size and position. This
        /// value is similar to "Show", except the window is not activated.</summary>
        SW_SHOWNA = 8,

        /// <summary>Activates and displays the window. If the window is
        /// minimized or maximized, the system restores it to its original size
        /// and position. An application should specify this flag when restoring
        /// a minimized window.</summary>
        SW_RESTORE = 9,

        /// <summary>Sets the show state based on the SW_ value specified in the
        /// STARTUPINFO structure passed to the CreateProcess function by the
        /// program that started the application.</summary>
        SW_SHOWDEFAULT = 10,

        /// <summary>Windows 2000/XP: Minimizes a window, even if the thread
        /// that owns the window is hung. This flag should only be used when
        /// minimizing windows from a different thread.</summary>
        SW_FORCEMINIMIZE = 11,
    }
    public enum WindowsMessage
    {
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,
        WM_QUIT = 0x0012,
        WM_SHOWWINDOW = 0x0018,
        WM_SETCURSOR = 0x0020
    }

    public delegate bool EnumDesktopsDelegate(string desktop, IntPtr lParam);
    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    public delegate bool EnumWindowStationsDelegate(string windowsStation, IntPtr lParam);
    public struct RECT {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    public class User32
    {
        public const uint SPI_SETDESKWALLPAPER = 0x0014;
        public const uint SPIF_UPDATEINIFILE = 0x01;
        public const uint SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetShellWindow();
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool BlockInput(bool fBlockIt);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool EnableWindow(IntPtr handle, bool fBlockIt);
         
        [DllImport("user32.dll")]
        public static extern bool SetWindowDisplayAffinity(IntPtr WindowHandle, WindowAffinity Affinity);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr handle, StringBuilder lpString, int cch);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out Int32 ProcessId);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern Int32 GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowType uCmd);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT hWndInsertAfter);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, long X, long Y, long cx, long cy, uint uFlags);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hwnd, int show);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool EnumDesktops(IntPtr hwinsta, EnumDesktopsDelegate lpEnumFunc, IntPtr lParam);  
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfoWS(uint uAction, uint uParam, string lpvParam, uint fuWinIni);
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool EnumWindowStationsW(EnumWindowStationsDelegate lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    }
}