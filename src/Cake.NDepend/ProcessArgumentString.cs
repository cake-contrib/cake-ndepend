using System.Reflection;

using Cake.Core.IO;

namespace Cake.NDepend
{
    internal sealed class ProcessArgumentString : IProcessArgument
    {
        private readonly NDependSettings _settings;
        private readonly string _settingsOptionName;

        internal ProcessArgumentString(string settingsOptionName, NDependSettings settings)
        {
            _settingsOptionName = settingsOptionName;
            _settings = settings;
        }

        public string Render()
        {
            var optionValue = GetType().GetProperty(_settingsOptionName)?.GetValue(_settings) as string;
            return string.IsNullOrWhiteSpace(_settingsOptionName)
                ? string.Empty
                : $"/{_settingsOptionName} {optionValue} ";
        }

        public string RenderSafe()
        {
            return Render();
        }
    }
}