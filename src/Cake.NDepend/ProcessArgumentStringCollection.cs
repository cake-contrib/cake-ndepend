using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Cake.Core.IO;

namespace Cake.NDepend
{
    internal sealed class ProcessArgumentStringCollection : IProcessArgument
    {
        private readonly NDependSettings _settings;
        private readonly string _settingsOptionName;

        internal ProcessArgumentStringCollection(string settingsOptionName, NDependSettings settings)
        {
            _settingsOptionName = settingsOptionName;
            _settings = settings;
        }

        public string Render()
        {
            if(!(GetType().GetProperty(_settingsOptionName)?.GetValue(_settings) is IReadOnlyCollection<string>
                   optionValues) || !optionValues.Any())
                return string.Empty;

            return $"/{_settingsOptionName} {string.Join(" ", optionValues)} ";
        }

        public string RenderSafe()
        {
            return Render();
        }
    }
}