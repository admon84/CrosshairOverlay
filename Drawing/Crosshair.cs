using CrosshairOverlay.Utils;
using GameOverlay.Drawing;
using System.Collections.Generic;
using Color = System.Drawing.Color;

namespace CrosshairOverlay.Drawing
{
    class Crosshair
    {
        private Settings _settings = Settings.Instance;
        private Dictionary<(Color, float), SolidBrush> _brushes = new Dictionary<(Color, float), SolidBrush>();

        public void DrawCrosshair(Graphics gfx)
        {
            var (x, y) = (gfx.Width / 2f, gfx.Height / 2f);
            var fillColor = CreateBrush(gfx, _settings.FillColor);
            var outlineColor = CreateBrush(gfx, _settings.OutlineColor);
            var width = _settings.CrosshairWidth;
            var outline = _settings.CrosshairOutline;
            var size = _settings.CrosshairSize;
            var gap = _settings.CrosshairGap;
            var outlineWidth = width + outline;

            if (_settings.CrosshairDot)
            {
                gfx.FillCircle(outlineColor, x, y, outlineWidth);
                gfx.FillCircle(fillColor, x, y, width);
            }

            if (_settings.CrosshairCross)
            {
                gfx.DrawRectangle(outlineColor, x - size - gap, y, x - gap, y, outlineWidth);
                gfx.DrawRectangle(outlineColor, x + size + gap, y, x + gap, y, outlineWidth);

                gfx.DrawRectangle(outlineColor, x, y - size - gap, x, y - gap, outlineWidth);
                gfx.DrawRectangle(outlineColor, x, y + size + gap, x, y + gap, outlineWidth);

                gfx.DrawRectangle(fillColor, x - size - gap, y, x - gap, y, width);
                gfx.DrawRectangle(fillColor, x + size + gap, y, x + gap, y, width);

                gfx.DrawRectangle(fillColor, x, y - size - gap, x, y - gap, width);
                gfx.DrawRectangle(fillColor, x, y + size + gap, x, y + gap, width);
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
