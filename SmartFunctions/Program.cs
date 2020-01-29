using SmartFunctions.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFunctions
{
    static class Program
    {

        private static String appGuid = "1efb2863-7c53-4bec-9cdf-a0edccc31150";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Instance already running");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (Trayicon ti = new Trayicon())
                {
                    ti.Display();

                    // Make sure the application runs!
                    Application.Run();
                };
            }
        }

    }
}
