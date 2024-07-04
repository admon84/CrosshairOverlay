using System;
using System.Drawing;
using System.Globalization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace CrosshairOverlay.Helpers
{
    internal sealed class FloatTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(double);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            throw new NotImplementedException();
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            emitter.Emit(new Scalar(null, ((double)value).ToString(new CultureInfo("en-US"))));
        }
    }

    internal sealed class CrosshairStyleTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(GameOverlay.Drawing.CrosshairStyle);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            throw new NotImplementedException();
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            if (value != null)
            {
                emitter.Emit(new Scalar(null, ((GameOverlay.Drawing.CrosshairStyle)value).ToString()));
            }
        }
    }

    internal sealed class ColorTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(Color);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            throw new NotImplementedException();
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            if (value != null)
            {
                emitter.Emit(new Scalar(null, Helpers.GetColorName((Color)value)));
            }
        }
    }

    internal static class Helpers
    {
        internal static string GetColorName(Color color)
        {
            if (color.IsNamedColor)
            {
                return color.Name;
            }
            return $"{color.R}, {color.G}, {color.B}";
        }
    }
}