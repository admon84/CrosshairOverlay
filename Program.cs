using CrosshairOverlay.Helpers;
using CrosshairOverlay.Settings;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace CrosshairOverlay
{
    public static class Program
    {
        private static readonly string appName = "CrosshairOverlay";
        private static readonly string appVersion = $"v{typeof(Program).Assembly.GetName().Version}";
        private static readonly string appNameVersion = $"{appName} {appVersion}";

        private static ConfigForm configForm;
        private static NotifyIcon trayIcon;
        private static Overlay overlay;
        private static BackgroundWorker backWorkOverlay = new BackgroundWorker();
        private static Mutex mutex = null;

        [STAThread]
        public static void Main()
        {
            try
            {
                bool createdNew;
                mutex = new Mutex(true, appName, out createdNew);

                if (!createdNew)
                {
                    MessageBox.Show($"{appName} is already running." + (new Random().NextDouble() < 0.05 ? " Better go catch it!" : ""), appNameVersion, MessageBoxButtons.OK);
                    return;
                }

                ConfigFile.Load();

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var contextMenu = new ContextMenuStrip();

                contextMenu.Items.AddRange(new ToolStripItem[]
                {
                    new ToolStripMenuItem("Config", null, ShowConfigForm),
                    new ToolStripSeparator(),
                    new ToolStripMenuItem("Exit", null, TrayExit)
                });

                trayIcon = new NotifyIcon()
                {
                    Icon = Properties.Resources.Icon,
                    ContextMenuStrip = contextMenu,
                    Text = appNameVersion,
                    Visible = true
                };

                configForm = new ConfigForm();
                backWorkOverlay.DoWork += new DoWorkEventHandler(RunOverlay);
                backWorkOverlay.WorkerSupportsCancellation = true;
                backWorkOverlay.RunWorkerAsync();

                Application.Run();
            }
            catch (Exception e)
            {
                ProcessException(e);
            }
        }

        private static void RunOverlay(object sender, DoWorkEventArgs e)
        {
            using (overlay = new Overlay())
            {
                overlay.Run();
            }
        }

        private static void ShowConfigForm(object sender, EventArgs e)
        {
            if (configForm.Visible)
            {
                configForm.Activate();
            }
            else
            {
                configForm.ShowDialog();
            }
        }

        private static void TrayExit(object sender, EventArgs e)
        {
            Dispose();

            Application.Exit();
        }

        private static void ProcessException(Exception e)
        {
            MessageBox.Show(e.Message, $"Error - {appNameVersion}", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ProcessException((Exception)e.ExceptionObject);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ProcessException(e.Exception);
        }

        private static void Dispose()
        {
            if (configForm != null)
            {
                configForm.Dispose();
            }

            overlay.Dispose();

            trayIcon.Dispose();

            if (backWorkOverlay.IsBusy)
            {
                backWorkOverlay.CancelAsync();
            }

            mutex.Dispose();
        }
    }
}
