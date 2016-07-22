using System;
using System.Runtime.InteropServices;

namespace Nikita.WinForm.ExtendControl
{
    public static class UIApiCalls
    {
        #region Public Constants

        public const int KEYEVENTF_KEYUP = 0x0002;
        public const int WM_ACTIVATE = 0x006;
        public const int WM_ACTIVATEAPP = 0x01C;
        public const int WM_NCACTIVATE = 0x086;

        #endregion Public Constants

        #region Public Static API Calls

        [DllImport("user32")]
        public extern static void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int PostMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int SendMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

        #endregion Public Static API Calls
    }
}