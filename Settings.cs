using System;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace CrosshairOverlay
{
    public class Settings
    {
        public Color FillColor { get; set; } = Color.FromArgb(2, 238, 238);
        public Color OutlineColor { get; set; } = Color.FromArgb(50, 0, 0, 0);
        public float CrosshairSize { get; set; } = 10;
        public float CrosshairGap { get; set; } = 10;
        public float CrosshairWidth { get; set; } = 1;
        public float CrosshairOutline { get; set; } = 1;
        public Boolean CrosshairDot { get; set; } = true;
        public Boolean CrosshairCross { get; set; } = true;

        private static readonly string SettingsFilePath = "settings.json";

        private static Settings _instance;

        private Settings() { }

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
            var json = JsonConvert.SerializeObject(this, Formatting.Indented, new ColorJsonConverter());
            File.WriteAllText(SettingsFilePath, json);
        }

        public static Settings Load()
        {
            if (!File.Exists(SettingsFilePath))
            {
                return new Settings();
            }

            var json = File.ReadAllText(SettingsFilePath);
            return JsonConvert.DeserializeObject<Settings>(json, new ColorJsonConverter());
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
