using System.Text.RegularExpressions;
using Color = GameOverlay.Drawing.Color;
using SystemColor = System.Drawing.Color;

namespace CrosshairOverlay.Helpers
{
    public static class Extensions
    {
        public static SystemColor SetOpacity(this SystemColor color, float opacity)
        {
            return SystemColor.FromArgb((int)(color.A * opacity), color.R, color.G, color.B);
        }

        public static Color ToGameOverlayColor(this SystemColor color)
        {
            return new Color(color.R, color.G, color.B, color.A);
        }

        public static string ToProperCase(this string text)
        {
            return Regex.Replace(text, "(\\B[A-Z])", " $1");
        }

        public static string ToPascalCase(this string text)
        {
            return text.Replace(" ", "");
        }
    }
}
