using System;
using System.Threading;
using System.Windows.Forms;

namespace SmartTextFunctions
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
			// Check if a instance is already running. Only allow one instance at same time.
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("A instance is already running!", "SmartTextFunctions", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
