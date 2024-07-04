using CrosshairOverlay.Settings;
using System.Collections.Generic;
using GameOverlay.Drawing;
using Color = System.Drawing.Color;

namespace CrosshairOverlay.Helpers
{
    class Drawing
    {
        private Dictionary<(Color, float), SolidBrush> _brushes = new Dictionary<(Color, float), SolidBrush>();

        public void DrawCrosshair(Graphics gfx)
        {
            var (x, y) = (gfx.Width / 2, gfx.Height / 2);
            var brush = CreateBrush(gfx, ConfigFile.Loaded.Color, ConfigFile.Loaded.Opacity);
            var (size, stroke) = (ConfigFile.Loaded.Size, ConfigFile.Loaded.Thickness);

            void DrawCross(float gap = 0)
            {
                var diff = size * .667f;
                var pad = gap * .667f;
                gfx.DrawLine(brush, x - diff - pad, y - diff - pad, x - pad, y - pad, stroke);
                gfx.DrawLine(brush, x + pad, y + pad, x + diff + pad, y + diff + pad, stroke);
                gfx.DrawLine(brush, x - diff - pad, y + diff + pad, x - pad, y + pad, stroke);
                gfx.DrawLine(brush, x + pad, y - pad, x + diff + pad, y - diff - pad, stroke);
            };

            void DrawPlus(float gap = 0)
            {
                gfx.DrawLine(brush, x - size - gap, y, x - gap, y, stroke);
                gfx.DrawLine(brush, x, y + size + gap, x, y + gap, stroke);
                gfx.DrawLine(brush, x + gap, y, x + size + gap, y, stroke);
                gfx.DrawLine(brush, x, y - gap, x, y - size - gap, stroke);
            };

            if (ConfigFile.Loaded.ShowDot)
            {
                gfx.FillEllipse(brush, x, y, stroke, stroke);
            }

            if (ConfigFile.Loaded.ShowCircle)
            {
                gfx.DrawEllipse(brush, x, y, size, size, stroke);
            }

            if (ConfigFile.Loaded.ShowCross)
            {
                DrawCross(ConfigFile.Loaded.Gap);
            }

            if (ConfigFile.Loaded.ShowPlus)
            {
                DrawPlus(ConfigFile.Loaded.Gap);
            }
        }

        private SolidBrush CreateBrush(Graphics gfx, Color color, float opacity = 1)
        {
            var key = (color, opacity);
            if (!_brushes.ContainsKey(key))
            {
                _brushes[key] = gfx.CreateSolidBrush(color.SetOpacity(opacity).ToGameOverlayColor());
            }
            return _brushes[key];
        }

        ~Drawing() => Dispose();

        public void Dispose()
        {
            foreach (var item in _brushes.Values)
            {
                item.Dispose();
            }
        }
    }
}
