using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using CrosshairOverlay.Utils;

namespace CrosshairOverlay
{
    public static class Program
    {
        private static readonly BackgroundWorker _worker = new BackgroundWorker();
        private static Mutex _mutex = null;
        private static SettingsForm _settingsForm;
        private static Overlay _overlay;
        private static NotifyIcon _trayIcon;
        private static bool _isPaused = false;

        [STAThread]
        public static void Main()
        {
            try
            {
                _mutex = new Mutex(true, AppInfo.AppName, out var createdNew);
                if (!createdNew)
                {
                    MessageBox.Show($"{AppInfo.AppName} is already running.", AppInfo.AppNameVersion, MessageBoxButtons.OK);
                    return;
                }

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                Application.SetCompatibleTextRenderingDefault(false);
                Application.EnableVisualStyles();

                var contextMenu = new ContextMenuStrip();

                contextMenu.Items.Add(new ToolStripMenuItem("Settings", null, ShowSettingsForm));

                if (Screen.AllScreens.Length > 1)
                {
                    var monitorItems = new ToolStripMenuItem("Monitor");
                    foreach (var screen in Screen.AllScreens)
                    {
                        var menuItem = new ToolStripMenuItem(screen.DeviceName.Replace("\\\\.\\DISPLAY", "Monitor "))
                        {
                            Tag = screen,
                            Checked = screen == Screen.PrimaryScreen
                        };
                        menuItem.Click += MonitorMenuItem_Click;
                        monitorItems.DropDownItems.Add(menuItem);
                    }
                    contextMenu.Items.Add(monitorItems);
                }

                contextMenu.Items.AddRange(new ToolStripItem[]
                {
                    new ToolStripSeparator(),
                    new ToolStripMenuItem("Pause", null, TrayPause),
                    new ToolStripMenuItem("Exit", null, TrayExit)
                });

                _trayIcon = new NotifyIcon()
                {
                    Icon = Properties.Resources.Icon,
                    ContextMenuStrip = contextMenu,
                    Text = AppInfo.AppNameVersion,
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

        private static void MonitorMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is Screen selectedScreen)
            {
                var bounds = selectedScreen.Bounds;
                _overlay.SetBounds(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
                _overlay.Refresh();

                foreach (ToolStripMenuItem item in menuItem.GetCurrentParent().Items)
                {
                    item.Checked = item == menuItem;
                }
            }
        }

        private static void ShowSettingsForm(object sender, EventArgs e)
        {
            if (_settingsForm == null || _settingsForm.IsDisposed)
            {
                _settingsForm = new SettingsForm(AppInfo.AppNameVersion);
            }

            if (_settingsForm.Visible)
            {
                _settingsForm.Activate();
            }
            else
            {
                _settingsForm.ShowDialog();
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
            MessageBox.Show(e.Message, $"Error - {AppInfo.AppNameVersion}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        private static void TrayExit(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        private static void TrayPause(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            if (_isPaused)
            {
                _isPaused = false;
                _overlay.Resume();
                menuItem.Checked = false;
            }
            else
            {
                _isPaused = true;
                _overlay.Pause();
                menuItem.Checked = true;
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyName = new AssemblyName(args.Name).Name;
            string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lib", assemblyName + ".dll");
            if (File.Exists(assemblyPath))
            {
                return Assembly.LoadFrom(assemblyPath);
            }
            return null;
        }

        private static void Dispose()
        {
            _overlay.Dispose();
            _settingsForm?.Dispose();
            _trayIcon.Dispose();
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
            }
            _mutex.Dispose();
        }
    }
}
