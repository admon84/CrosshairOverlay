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
        public bool Accepts(Type type) => type == typeof(double);

        public object ReadYaml(IParser parser, Type type) => throw new NotImplementedException();

        public void WriteYaml(IEmitter emitter, object value, Type type) =>
            emitter.Emit(new Scalar(null, ((double)value).ToString(new CultureInfo("en-US"))));
    }

    internal sealed class ColorTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type) => type == typeof(Color);

        public object ReadYaml(IParser parser, Type type) => throw new NotImplementedException();

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            if (value != null)
            {
                emitter.Emit(new Scalar(null, ((Color)value).ToColorName()));
            }
        }
    }
}