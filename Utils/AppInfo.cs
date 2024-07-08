using System;
using System.Reflection;

namespace CrosshairOverlay.Utils
{
    public static class AppInfo
    {
        public static readonly string AppName = "CrosshairOverlay";
        public static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
        public static readonly string AppVersion = string.Format("v{0}.{1}.{2}", AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build);
        public static readonly string AppNameVersion = $"{AppName} {AppVersion}";
    }
}
