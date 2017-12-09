using Cake.Core.IO;

namespace Cake.NDepend
{
    /// <summary>
    ///     Processes a boolean argument.
    /// </summary>
    internal sealed class ProcessArgumentBool : IProcessArgument
    {
        private readonly NDependSettings _settings;
        private readonly string _settingsOptionName;

        /// <summary>
        ///     Default ctor.
        /// </summary>
        /// <param name="settingsOptionName">The settings option name.</param>
        /// <param name="settings">The NDepend settings.</param>
        internal ProcessArgumentBool(string settingsOptionName, NDependSettings settings)
        {
            _settingsOptionName = settingsOptionName;
            _settings = settings;
        }

        /// <inheritdoc />
        public string Render()
        {
            var optionValue = _settings.GetType().GetProperty(_settingsOptionName)?.GetValue(_settings) as bool?;
            return optionValue == true ? $"/{_settingsOptionName}" : string.Empty;
        }

        /// <inheritdoc />
        public string RenderSafe()
        {
            return Render();
        }
    }
}