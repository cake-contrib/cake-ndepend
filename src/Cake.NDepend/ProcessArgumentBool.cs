using System.Reflection;

using Cake.Core.IO;

namespace Cake.NDepend
{
    internal sealed class ProcessArgumentBool : IProcessArgument
    {
        private readonly NDependSettings _settings;
        private readonly string _settingsOptionName;

        internal ProcessArgumentBool(string settingsOptionName, NDependSettings settings)
        {
            _settingsOptionName = settingsOptionName;
            _settings = settings;
        }

        public string Render()
        {
            var optionValue = GetType().GetProperty(_settingsOptionName)?.GetValue(_settings) as bool?;
            return optionValue == true ? $"/{_settingsOptionName} " : string.Empty;
        }

        public string RenderSafe()
        {
            return Render();
        }
    }
}