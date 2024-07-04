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

            _deserializer = builder
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .Build();
        }

        public T ParseConfigurationFile(string fileName)
        {
            var fileManager = new FileManager(fileName);
            if (!fileManager.FileExists())
            {
                throw new Exception($"{fileName} needs to be present in the same directory as the executable");
            }

            var yaml = fileManager.ReadFile();
            var configuration = _deserializer.Deserialize<T>(yaml);
            return configuration;
        }

        public ConfigFile ParseConfigurationMain(byte[] resourcePrimary, string fileNameOverride = null)
        {
            var yamlPrimary = Encoding.Default.GetString(resourcePrimary);
            if (fileNameOverride == null)
            {
                return _deserializer.Deserialize<ConfigFile>(yamlPrimary);
            }

            var fileManagerOverride = new FileManager(fileNameOverride);
            if (!fileManagerOverride.FileExists())
            {
                return _deserializer.Deserialize<ConfigFile>(yamlPrimary);
            }

            var yamlOverride = fileManagerOverride.ReadFile();
            var primaryConfig = _deserializer.Deserialize<Dictionary<object, object>>(yamlPrimary);
            var secondaryConfig = _deserializer.Deserialize<Dictionary<object, object>>(yamlOverride);
            if (secondaryConfig != null)
            {
                Merge(primaryConfig, secondaryConfig);
            }

            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(primaryConfig);
            var configuration = _deserializer.Deserialize<ConfigFile>(yaml);
            return configuration;
        }

        public void Merge(Dictionary<object, object> primary, Dictionary<object, object> secondary)
        {
            foreach (var tuple in secondary)
            {
                if (!primary.ContainsKey(tuple.Key))
                {
                    primary.Add(tuple.Key, tuple.Value);
                    continue;
                }

                var primaryValue = primary[tuple.Key];
                if (!(primaryValue is IDictionary))
                {
                    primary[tuple.Key] = tuple.Value;
                    continue;
                }
                else
                {
                    if (secondary[tuple.Key] != null)
                    {
                        Merge((Dictionary<object, object>)primaryValue, (Dictionary<object, object>)secondary[tuple.Key]);
                    }
                }
            }
        }

        public void SerializeToFile(T _)
        {
            var config = ConfigFile.Loaded;
            using (var streamWriter = new StreamWriter("Config.yaml"))
            {
                var serializer = new SerializerBuilder()
                    .WithNamingConvention(PascalCaseNamingConvention.Instance)
                    .WithTypeConverter(new FloatTypeConverter())
                    .WithTypeConverter(new CrosshairStyleTypeConverter())
                    .WithTypeConverter(new ColorTypeConverter())
                    .Build();
                serializer.Serialize(streamWriter, config);
            }
        }
    }
}
