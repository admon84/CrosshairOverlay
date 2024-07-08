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

        private static readonly string _filename = "Settings.json";
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
            File.WriteAllText(_filename, json);
        }

        public static Settings Load()
        {
            if (!File.Exists(_filename))
            {
                return new Settings();
            }

            var json = File.ReadAllText(_filename);
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

        public Color GetFillColor() => Color.FromArgb(GetFillColorAlpha(), FillColor);
        public Color GetOutlineColor() => Color.FromArgb(GetOutlineColorAlpha(), OutlineColor);
        public int GetFillColorAlpha() => (int)Math.Round(255 * FillColorAlpha);
        public int GetOutlineColorAlpha() => (int)Math.Round(255 * OutlineColorAlpha);
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

        private readonly GlobalSettings _globalSettings;

        public ShapeSettings(GlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public Color GetFillColor() => Color.FromArgb(GetFillColorAlpha(), FillColor ?? _globalSettings.FillColor);
        public Color GetOutlineColor() => Color.FromArgb(GetOutlineColorAlpha(), OutlineColor ?? _globalSettings.OutlineColor);
        public int GetFillColorAlpha() => (int)Math.Round(255 * (FillColorAlpha ?? _globalSettings.FillColorAlpha));
        public int GetOutlineColorAlpha() => (int)Math.Round(255 * (OutlineColorAlpha ?? _globalSettings.OutlineColorAlpha));
        public float GetCrosshairSize() => CrosshairSize ?? _globalSettings.CrosshairSize;
        public float GetCrosshairGap() => CrosshairGap ?? _globalSettings.CrosshairGap;
        public float GetCrosshairWidth() => CrosshairWidth ?? _globalSettings.CrosshairWidth;
        public float GetCrosshairOutline() => CrosshairOutline ?? _globalSettings.CrosshairOutline;
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
