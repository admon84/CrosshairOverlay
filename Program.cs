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
        private static Mutex mutex = null;
        private static Overlay overlay;
        private static NotifyIcon trayIcon;
        private static BackgroundWorker worker = new BackgroundWorker();

        [STAThread]
        public static void Main()
        {
            try
            {
                mutex = new Mutex(true, appName, out var createdNew);
                if (!createdNew)
                {
                    MessageBox.Show($"{appName} is already running.", appNameVersion, MessageBoxButtons.OK);
                    return;
                }

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ConfigFile.Load();
                configForm = new ConfigForm();

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

                worker.DoWork += new DoWorkEventHandler(RunOverlay);
                worker.WorkerSupportsCancellation = true;
                worker.RunWorkerAsync();

                Application.Run();
            }
            catch (Exception e)
            {
                HandleException(e);
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

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException((Exception)e.ExceptionObject);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void HandleException(Exception e)
        {
            MessageBox.Show(e.Message, $"Error - {appNameVersion}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private static void TrayExit(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        private static void Dispose()
        {
            if (configForm != null)
            {
                configForm.Dispose();
            }
            overlay.Dispose();
            trayIcon.Dispose();
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }
            mutex.Dispose();
        }
    }
}
