using CrosshairOverlay.Utils;
using System.Drawing;
using YamlDotNet.Serialization;

namespace CrosshairOverlay.Settings
{
    public class Config
    {
        public static Config Current { get; set; }

        public static void Load()
        {
            var configParser = new ConfigParser<Config>();
            Current = configParser.Parse("./Config.yaml", Properties.Resources.Config);
        }

        public void Save()
        {
            new ConfigParser<Config>().Save(this);
        }

        [YamlMember(Alias = "Color", ApplyNamingConventions = false)]
        public Color Color { get; set; }

        [YamlMember(Alias = "Gap", ApplyNamingConventions = false)]
        public float Gap { get; set; }

        [YamlMember(Alias = "Opacity", ApplyNamingConventions = false)]
        public float Opacity { get; set; }

        [YamlMember(Alias = "ShowCircle", ApplyNamingConventions = false)]
        public bool ShowCircle { get; set; }

        [YamlMember(Alias = "ShowCross", ApplyNamingConventions = false)]
        public bool ShowCross { get; set; }

        [YamlMember(Alias = "ShowDot", ApplyNamingConventions = false)]
        public bool ShowDot { get; set; }

        [YamlMember(Alias = "ShowPlus", ApplyNamingConventions = false)]
        public bool ShowPlus { get; set; }

        [YamlMember(Alias = "Size", ApplyNamingConventions = false)]
        public float Size { get; set; }

        [YamlMember(Alias = "Thickness", ApplyNamingConventions = false)]
        public float Thickness { get; set; }
    }
}
