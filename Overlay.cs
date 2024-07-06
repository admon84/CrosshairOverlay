using CrosshairOverlay.Drawing;
using System;
using System.Threading;
using System.Windows.Forms;
using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace CrosshairOverlay
{
    public class Overlay : IDisposable
    {
        private bool _isRunning;
        private bool _isPaused;
        private static readonly object _pauseLock = new object();
        private static readonly object _drawLock = new object();
        private readonly GraphicsWindow _window;

        private Crosshair _crosshair = new Crosshair();
        private bool _isDisposed = false;
        private bool _isDrawing = false;

        public Overlay()
        {
            GameOverlay.TimerService.EnableHighPrecisionTimers();
            var gfx = new Graphics()
            {
                PerPrimitiveAntiAliasing = false
            };
            _window = new GraphicsWindow(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height, gfx)
            {
                FPS = 60,
                IsTopmost = true,
                IsVisible = true,
            };
            _window.DestroyGraphics += Window_DestroyGraphics;
            _window.DrawGraphics += Window_DrawGraphics;
        }

        private void Window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
        {
            if (_isDisposed || _isDrawing) return;

            _isDrawing = true;
            var gfx = e.Graphics;
            lock (_drawLock)
            {
                gfx.ClearScene();

                if (!_isPaused)
                {
                    _crosshair.DrawCrosshair(gfx);
                }
            }
            _isDrawing = false;
        }

        private void Window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
        {
            _crosshair?.Dispose();
            _crosshair = null;
        }

        public void Run()
        {
            _isRunning = true;
            _window.Create();
            while (_isRunning)
            {
                lock (_pauseLock)
                {
                    if (_isPaused)
                    {
                        Monitor.Wait(_pauseLock);
                    }
                }
                Thread.Sleep(10);
            }
            _window.Join();
        }

        public void Pause()
        {
            lock (_pauseLock)
            {
                _isPaused = true;
            }
        }

        public void Unpause()
        {
            lock (_pauseLock)
            {
                _isPaused = false;
                Monitor.Pulse(_pauseLock);
            }
        }

        public void Stop()
        {
            _isRunning = false;
            Unpause();
        }

        ~Overlay() => Dispose();

        public void Dispose()
        {
            Stop();

            lock (_drawLock)
            {
                if (!_isDisposed)
                {
                    _isDisposed = true;
                    _window.Dispose();
                    _crosshair?.Dispose();
                }
            }
        }
    }
}
