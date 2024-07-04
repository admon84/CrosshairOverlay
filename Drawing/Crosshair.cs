using CrosshairOverlay.Settings;
using CrosshairOverlay.Utils;
using GameOverlay.Drawing;
using System.Collections.Generic;
using Color = System.Drawing.Color;

namespace CrosshairOverlay.Drawing
{
    class Crosshair
    {
        private Dictionary<(Color, float), SolidBrush> _brushes = new Dictionary<(Color, float), SolidBrush>();

        public void DrawCrosshair(Graphics gfx)
        {
            var (x, y) = (gfx.Width / 2, gfx.Height / 2);
            var brush = CreateBrush(gfx, Config.Current.Color, Config.Current.Opacity);
            var (gap, size, stroke) = (Config.Current.Gap, Config.Current.Size, Config.Current.Thickness);

            if (Config.Current.ShowDot)
            {
                gfx.FillEllipse(brush, x, y, stroke, stroke);
            }

            if (Config.Current.ShowCircle)
            {
                gfx.DrawEllipse(brush, x, y, size, size, stroke);
            }

            if (Config.Current.ShowCross)
            {
                var scale = .707f;
                var diff = scale * size;
                var pad = scale * gap;
                gfx.DrawLine(brush, x - diff - pad, y - diff - pad, x - pad, y - pad, stroke);
                gfx.DrawLine(brush, x + pad, y + pad, x + diff + pad, y + diff + pad, stroke);
                gfx.DrawLine(brush, x - diff - pad, y + diff + pad, x - pad, y + pad, stroke);
                gfx.DrawLine(brush, x + pad, y - pad, x + diff + pad, y - diff - pad, stroke);
            }

            if (Config.Current.ShowPlus)
            {
                gfx.DrawLine(brush, x - size - gap, y, x - gap, y, stroke);
                gfx.DrawLine(brush, x, y + size + gap, x, y + gap, stroke);
                gfx.DrawLine(brush, x + gap, y, x + size + gap, y, stroke);
                gfx.DrawLine(brush, x, y - gap, x, y - size - gap, stroke);
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

        ~Crosshair() => Dispose();

        public void Dispose()
        {
            foreach (var item in _brushes.Values)
            {
                item.Dispose();
            }
        }
    }
}
