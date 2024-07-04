using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace CrosshairOverlay
{
    public static class Program
    {
        private static readonly string _appName = "CrosshairOverlay";
        private static readonly string _appVersion = $"v{typeof(Program).Assembly.GetName().Version}";
        private static readonly string _appNameVersion = $"{_appName} {_appVersion}";

        private static SettingsForm settingsForm;
        private static Mutex _mutex = null;
        private static Overlay _overlay;
        private static NotifyIcon _trayIcon;
        private static BackgroundWorker _worker = new BackgroundWorker();
        private static bool _isPaused = false;

        [STAThread]
        public static void Main()
        {
            try
            {
                _mutex = new Mutex(true, _appName, out var createdNew);
                if (!createdNew)
                {
                    MessageBox.Show($"{_appName} is already running.", _appNameVersion, MessageBoxButtons.OK);
                    return;
                }

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.AddRange(new ToolStripItem[]
                {
                    new ToolStripMenuItem("Settings", null, ShowSettingsForm),
                    new ToolStripSeparator(),
                    new ToolStripMenuItem("Pause", null, TrayPause),
                    new ToolStripMenuItem("Exit", null, TrayExit)
                });

                _trayIcon = new NotifyIcon()
                {
                    Icon = Properties.Resources.Icon,
                    ContextMenuStrip = contextMenu,
                    Text = _appNameVersion,
                    Visible = true
                };

                _worker.DoWork += new DoWorkEventHandler(RunOverlay);
                _worker.WorkerSupportsCancellation = true;
                _worker.RunWorkerAsync();

                Application.Run();
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        private static void ShowSettingsForm(object sender, EventArgs e)
        {
            if (settingsForm == null || settingsForm.IsDisposed)
            {
                settingsForm = new SettingsForm();
            }

            if (settingsForm.Visible)
            {
                settingsForm.Activate();
            }
            else
            {
                settingsForm.ShowDialog();
            }
        }

        private static void RunOverlay(object sender, DoWorkEventArgs e)
        {
            using (_overlay = new Overlay())
            {
                _overlay.Run();
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
            MessageBox.Show(e.Message, $"Error - {_appNameVersion}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private static void TrayExit(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        private static void TrayPause(object sender, EventArgs e)
        {
            if (_isPaused)
            {
                _overlay.Unpause();
                _isPaused = false;
                ((ToolStripMenuItem)sender).Text = "Pause";
            }
            else
            {
                _overlay.Pause();
                _isPaused = true;
                ((ToolStripMenuItem)sender).Text = "Unpause";
            }
        }

        private static void Dispose()
        {
            if (settingsForm != null)
            {
                settingsForm.Dispose();
            }
            _overlay.Dispose();
            _trayIcon.Dispose();
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
            }
            _mutex.Dispose();
        }
    }
}
