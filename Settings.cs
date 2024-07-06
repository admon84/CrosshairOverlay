using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace CrosshairOverlay
{
    public class Settings
    {
        public GlobalSettings GlobalSettings { get; set; } = new GlobalSettings();
        public ShapeSettings DotSettings { get; set; }
        public ShapeSettings CrossSettings { get; set; }
        public ShapeSettings CircleSettings { get; set; }

        private static readonly string SettingsFilePath = "settings.json";
        private static Settings _instance;

        private Settings()
        {
            DotSettings = new ShapeSettings(GlobalSettings);
            CrossSettings = new ShapeSettings(GlobalSettings);
            CircleSettings = new ShapeSettings(GlobalSettings);
        }

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Load();
                }
                return _instance;
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            File.WriteAllText(SettingsFilePath, json);
        }

        public static Settings Load()
        {
            if (!File.Exists(SettingsFilePath))
            {
                return new Settings();
            }

            var json = File.ReadAllText(SettingsFilePath);
            return JsonConvert.DeserializeObject<Settings>(json);
        }
    }

    public class GlobalSettings
    {
        public Color FillColor { get; set; } = Color.FromArgb(2, 238, 238);
        public Color OutlineColor { get; set; } = Color.Black;
        public float FillColorAlpha { get; set; } = 1;
        public float OutlineColorAlpha { get; set; } = .2f;
        public float CrosshairSize { get; set; } = 10;
        public float CrosshairGap { get; set; } = 10;
        public float CrosshairWidth { get; set; } = 1;
        public float CrosshairOutline { get; set; } = 1;
        public Boolean CrosshairDot { get; set; } = true;
        public Boolean CrosshairCross { get; set; } = true;
        public Boolean CrosshairCircle { get; set; } = false;

        public Color GetFillColor()
        {
            return Color.FromArgb(GetFillColorAlpha(), FillColor);
        }

        public Color GetOutlineColor()
        {
            return Color.FromArgb(GetOutlineColorAlpha(), OutlineColor);
        }

        public int GetFillColorAlpha()
        {
            return (int)Math.Round(255 * FillColorAlpha);
        }

        public int GetOutlineColorAlpha()
        {
            return (int)Math.Round(255 * OutlineColorAlpha);
        }
    }

    public class ShapeSettings
    {
        public Color? FillColor { get; set; }
        public Color? OutlineColor { get; set; }
        public float? FillColorAlpha { get; set; }
        public float? OutlineColorAlpha { get; set; }
        public float? CrosshairSize { get; set; }
        public float? CrosshairGap { get; set; }
        public float? CrosshairWidth { get; set; }
        public float? CrosshairOutline { get; set; }

        private GlobalSettings _globalSettings;

        public ShapeSettings(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public Color GetFillColor()
        {
            return Color.FromArgb(GetFillColorAlpha(), FillColor.HasValue ? FillColor.Value : _globalSettings.FillColor);
        }

        public Color GetOutlineColor()
        {
            return Color.FromArgb(GetOutlineColorAlpha(), OutlineColor.HasValue ? OutlineColor.Value : _globalSettings.OutlineColor);
        }

        public int GetFillColorAlpha()
        {
            var fillColorAlpha = FillColorAlpha ?? _globalSettings.FillColorAlpha;
            return (int)Math.Round(255 * fillColorAlpha);
        }

        public int GetOutlineColorAlpha()
        {
            var outlineColorAlpha = OutlineColorAlpha ?? _globalSettings.OutlineColorAlpha;
            return (int)Math.Round(255 * outlineColorAlpha);
        }

        public float GetCrosshairSize()
        {
            return CrosshairSize ?? _globalSettings.CrosshairSize;
        }

        public float GetCrosshairGap()
        {
            return CrosshairGap ?? _globalSettings.CrosshairGap;
        }

        public float GetCrosshairWidth()
        {
            return CrosshairWidth ?? _globalSettings.CrosshairWidth;
        }

        public float GetCrosshairOutline()
        {
            return CrosshairOutline ?? _globalSettings.CrosshairOutline;
        }
    }

    public class ColorJsonConverter : JsonConverter<Color>
    {
        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var colorString = (string)reader.Value;
            return ColorTranslator.FromHtml(colorString);
        }

        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            var colorString = ColorTranslator.ToHtml(value);
            writer.WriteValue(colorString);
        }

        public override bool CanRead => true;
        public override bool CanWrite => true;
    }
}
