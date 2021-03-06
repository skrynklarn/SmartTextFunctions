﻿using SmartTextFunctions.Properties;
using System;
using System.Windows.Forms;

namespace SmartTextFunctions
{
    class Trayicon : IDisposable
    {
        NotifyIcon ni;

        public Trayicon()
        {
            ni = new NotifyIcon();
        }

        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ni.Icon = Resources.fx;
            ni.Text = "SmartTextFunctions";
            ni.Visible = true;

            // Attach a context menu.
            ni.ContextMenuStrip = new TrayContextMenu().Create();
        }

        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            ni.Dispose();
        }
    }
}
