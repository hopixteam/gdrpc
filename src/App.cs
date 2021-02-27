﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GDRPC
{
    public class AppRunner
    {
        #region App Control
        public static void MessageBox(string title, string text, long icon, long button)
        {
            WinApi.MessageBox.Show((int)Process.GetCurrentProcess().MainWindowHandle, text, title, (uint)(icon | button));
        }

        //with close app
        public class MSG
        {
            public static void Error(string text)
            {
                MessageBox("GDRPC", text, MB.Icon.Error, MB.Buttons.Ok);
                Environment.Exit(5);
                return;
            }
        }
        #endregion

        public static DateTime StartApp;

        /// <summary>
        /// Run wihout console
        /// </summary>
        public static void Run() => Main(null);

        /// <summary>
        /// Stop wihout console
        /// </summary>
        public static void Stop() => App.App.Stop();

        /// <summary>
        /// Run with console
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            StartApp = DateTime.UtcNow;
            if (WinApi.Consoler.IsConsole())
            {
#if DEBUG
                Console.Title = "GDRPC";
#endif
                Console.WriteLine("Geometry Dash Rich Presence");
                App.App.Run().ConfigureAwait(false);
                while (true) { Console.ReadKey(true); }
            }
            App.App.Run().ConfigureAwait(false);
        }
    }
}