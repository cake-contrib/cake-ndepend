using System.Collections.Generic;
using System.Linq;

using Cake.Core.IO;

namespace Cake.NDepend
{
    /// <summary>
    ///     Processes a collections of strings argument.
    /// </summary>
    internal sealed class ProcessArgumentStringCollection : IProcessArgument
    {
        private readonly NDependSettings _settings;
        private readonly string _settingsOptionName;

        /// <summary>
        ///     Default ctor.
        /// </summary>
        /// <param name="settingsOptionName">The settings option name.</param>
        /// <param name="settings">The NDepend settings.</param>
        internal ProcessArgumentStringCollection(string settingsOptionName, NDependSettings settings)
        {
            _settingsOptionName = settingsOptionName;
            _settings = settings;
        }

        /// <inheritdoc />
        public string Render()
        {
            if(!(_settings.GetType().GetProperty(_settingsOptionName)?.GetValue(_settings) is
                   IReadOnlyCollection<string>
                   optionValues) || !optionValues.Any())
                return string.Empty;

            return $"/{_settingsOptionName} {string.Join(" ", optionValues)}";
        }

        /// <inheritdoc />
        public string RenderSafe()
        {
            return Render();
        }
    }
}