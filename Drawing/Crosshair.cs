using CrosshairOverlay.Utils;
using GameOverlay.Drawing;
using System.Collections.Generic;
using Color = System.Drawing.Color;

namespace CrosshairOverlay.Drawing
{
    class Crosshair
    {
        private Settings _settings = Settings.Instance;
        private Dictionary<Color, SolidBrush> _brushes = new Dictionary<Color, SolidBrush>();

        public void DrawCrosshair(Graphics gfx)
        {
            var (x, y) = (gfx.Width / 2f, gfx.Height / 2f);

            if (_settings.GlobalSettings.CrosshairDot) 
                DrawDot(gfx, x, y);

            if (_settings.GlobalSettings.CrosshairCircle)
                DrawCircle(gfx, x, y);

            if (_settings.GlobalSettings.CrosshairCross)
                DrawCross(gfx, x, y);
        }

        private void DrawDot(Graphics gfx, float x, float y)
        {
            var width = _settings.DotSettings.GetCrosshairWidth();
            var outline = _settings.DotSettings.GetCrosshairOutline();

            var fillColor = CreateBrush(gfx, _settings.DotSettings.GetFillColor());
            var outlineColor = CreateBrush(gfx, _settings.DotSettings.GetOutlineColor());

            var halfWidth = width * .5f;

            gfx.DrawRectangle(outlineColor, x - halfWidth, y - halfWidth, x + halfWidth, y + halfWidth, width + outline);
            gfx.DrawRectangle(fillColor, x - halfWidth, y - halfWidth, x + halfWidth, y + halfWidth, width);
        }

        private void DrawCircle(Graphics gfx, float x, float y)
        {
            var width = _settings.CircleSettings.GetCrosshairWidth();
            var outline = _settings.CircleSettings.GetCrosshairOutline();
            var size = _settings.CircleSettings.GetCrosshairSize();
            var gap = _settings.CircleSettings.GetCrosshairGap();

            var circleSize = .5f * size + gap;

            var fillColor = CreateBrush(gfx, _settings.CircleSettings.GetFillColor());
            var outlineColor = CreateBrush(gfx, _settings.CircleSettings.GetOutlineColor());

            gfx.DrawEllipse(outlineColor, x, y, circleSize, circleSize, width + outline);
            gfx.DrawEllipse(fillColor, x, y, circleSize, circleSize, width);
        }

        private void DrawCross(Graphics gfx, float x, float y)
        {
            var width = _settings.CrossSettings.GetCrosshairWidth();
            var outline = _settings.CrossSettings.GetCrosshairOutline();
            var size = _settings.CrossSettings.GetCrosshairSize();
            var gap = _settings.CrossSettings.GetCrosshairGap();

            var fillColor = CreateBrush(gfx, _settings.CrossSettings.GetFillColor());
            var outlineColor = CreateBrush(gfx, _settings.CrossSettings.GetOutlineColor());

            gfx.DrawRectangle(outlineColor, x - size - gap, y, x - gap, y, width + outline);
            gfx.DrawRectangle(outlineColor, x + size + gap, y, x + gap, y, width + outline);
            gfx.DrawRectangle(outlineColor, x, y - size - gap, x, y - gap, width + outline);
            gfx.DrawRectangle(outlineColor, x, y + size + gap, x, y + gap, width + outline);

            gfx.DrawRectangle(fillColor, x - size - gap, y, x - gap, y, width);
            gfx.DrawRectangle(fillColor, x + size + gap, y, x + gap, y, width);
            gfx.DrawRectangle(fillColor, x, y - size - gap, x, y - gap, width);
            gfx.DrawRectangle(fillColor, x, y + size + gap, x, y + gap, width);
        }

        private SolidBrush CreateBrush(Graphics gfx, Color color)
        {
            if (!_brushes.ContainsKey(color))
            {
                _brushes[color] = gfx.CreateSolidBrush(color.ToGameOverlayColor());
            }
            return _brushes[color];
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
