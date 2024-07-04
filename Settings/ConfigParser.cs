using CrosshairOverlay.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CrosshairOverlay.Settings
{
    public class ConfigParser<T>
    {
        private IDeserializer _deserializer;

        public ConfigParser()
        {
            var builder = new DeserializerBuilder();
            if (typeof(T) == typeof(ConfigFile))
            {
                builder.IgnoreUnmatchedProperties();
            }
            _deserializer = builder.WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
        }

        public ConfigFile Parse(string configFileName, byte[] configResource)
        {
            var yamlResource = Encoding.Default.GetString(configResource);
            if (configFileName == null)
            {
                return _deserializer.Deserialize<ConfigFile>(yamlResource);
            }

            var fileManager = new FileManager(configFileName);
            if (!fileManager.FileExists())
            {
                return _deserializer.Deserialize<ConfigFile>(yamlResource);
            }

            var yamlFile = fileManager.ReadFile();
            var configuration = _deserializer.Deserialize<ConfigFile>(yamlFile);
            return configuration;
        }

        public void Save(T _)
        {
            var config = ConfigFile.Loaded;
            using (var streamWriter = new StreamWriter("Config.yaml"))
            {
                var serializer = new SerializerBuilder()
                    .WithNamingConvention(PascalCaseNamingConvention.Instance)
                    .WithTypeConverter(new FloatTypeConverter())
                    .WithTypeConverter(new ColorTypeConverter())
                    .Build();
                serializer.Serialize(streamWriter, config);
            }
        }
    }
}
