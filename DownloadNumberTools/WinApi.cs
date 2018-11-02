
using System;
using System.Runtime.InteropServices;

namespace DownloadNumberTools
{
    public class WinApi
    {
        /// <summary>
        /// 重绘
        /// </summary>
        public const int WM_PAINT = 0xF;
        /// <summary>
        /// 在即将绘制控件时，不是只读或禁用的编辑控件会将WM_CTLCOLOREDIT消息发送到其父窗口。通过响应此消息，父窗口可以使用指定的设备上下文句柄来设置编辑控件的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLOREDIT = 0x0133;
        /// <summary>
        /// 鼠标移动
        /// </summary>
        public const int WM_MOUSEMOVE = 0x0200;
        /// <summary>
        /// 鼠标移出
        /// </summary>
        public const int WM_MOUSELEAVE = 0x02A3;
        /// <summary>
        /// 设置焦点
        /// </summary>
        public const int WM_SETFOCUS = 0x0007;
        /// <summary>
        /// 停止焦点
        /// </summary>
        public const int WM_KILLFOCUS = 0x0008;
        /// <summary>
        /// 鼠标激活控件
        /// </summary>
        public const int WM_MOUSEACTIVATE = 0x0021;
        /// <summary>
        /// ？
        /// </summary>
        public const int HTCAPTION = 0x0002;
        /// <summary>
        /// 设置文本框水印
        /// </summary>
        public const int EM_SETCUEBANNER = 0x1501;
        /// <summary>
        /// 当用户从“ 窗口”菜单（以前称为系统或控制菜单）中选择命令时，或者当用户选择最大化按钮，最小化按钮，恢复按钮或关闭按钮时，窗口会收到此消息。
        /// </summary>
        public const int WM_SYSCOMMAND = 0x0112;
        /// <summary>
        /// 移动
        /// </summary>
        public const int SC_MOVE = 0xF010;
        /// <summary>
        /// 还原
        /// </summary>
        public const int SC_RESTORE = 0xF120;
        /// <summary>
        /// 最小化
        /// </summary>
        public const int SC_MINIMIZE = 0xF020;
        /// <summary>
        /// 最大化
        /// </summary>
        public const int SC_MAXIMIZE = 0xF030;


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern Int32 SendMessage(IntPtr hwnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        public enum FormWindowState
        {
            /// <summary>
            /// 最大化
            /// </summary>
            MAXIMIZE = 3,
            /// <summary>
            /// 最小化
            /// </summary>
            MINIMIZE = 2,
            /// <summary>
            /// 还原
            /// </summary>
            RESTORE = 1
        }

        /// <summary>
        /// 应用程序可以使用SetParent函数来设置弹出式窗口，层叠窗口或子窗口的父窗口。新的窗口与窗口必须属于同一应用程序。
        /// </summary>
        /// <param name="hWndChild">子窗口句柄。</param>
        /// <param name="hWndNewParent">新的父窗口句柄。如果该参数是NULL，则桌面窗口就成为新的父窗口。在WindowsNT5.0中，如果参数为HWND_MESSAGE,则子窗口成为消息窗口。</param>
        /// <returns></returns>
        [DllImport("user32 ")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("gdi32.dll")]
        public static extern int DeleteObject(IntPtr hObject);
    }
}