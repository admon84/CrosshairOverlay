using CrosshairOverlay.Helpers;
using System;
using System.Windows.Forms;
using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace CrosshairOverlay
{
    public class Overlay : IDisposable
    {
        private static readonly object _lock = new object();
        private readonly GraphicsWindow _window;

        private Drawing _drawing = new Drawing();
        private bool _isDisposed = false;
        private bool _isDrawing = false;

        public Overlay()
        {
            GameOverlay.TimerService.EnableHighPrecisionTimers();
            var gfx = new Graphics() { PerPrimitiveAntiAliasing = true };
            _window = new GraphicsWindow(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height, gfx)
            {
                FPS = 60,
                IsTopmost = true,
                IsVisible = true
            };
            _window.DrawGraphics += _window_DrawGraphics;
            _window.DestroyGraphics += _window_DestroyGraphics;
        }

        private void _window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
        {
            if (_isDisposed || _isDrawing) return;

            _isDrawing = true;
            var gfx = e.Graphics;
            lock (_lock)
            {
                gfx.ClearScene();
                _drawing.DrawCrosshair(gfx);
            }
            _isDrawing = false;
        }

        private void _window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
        {
            if (_drawing != null)
            {
                _drawing.Dispose();
            }
            _drawing = null;
        }

        public void Run()
        {
            _window.Create();
            _window.Join();
        }

        ~Overlay() => Dispose();

        public void Dispose()
        {
            lock (_lock)
            {
                if (!_isDisposed)
                {
                    _isDisposed = true;
                    _window.Dispose();
                    if (_drawing != null)
                    {
                        _drawing.Dispose();
                    }
                }
            }
        }
    }
}
