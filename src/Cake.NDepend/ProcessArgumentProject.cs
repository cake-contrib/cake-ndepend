using Cake.Core.IO;

namespace Cake.NDepend
{
    /// <summary>
    ///     Processes the project argument.
    /// </summary>
    internal sealed class ProcessArgumentProject : IProcessArgument
    {
        private readonly NDependSettings _settings;

        /// <summary>
        ///     Default ctor.
        /// </summary>
        /// <param name="settings">The NDepend settings.</param>
        internal ProcessArgumentProject(NDependSettings settings)
        {
            _settings = settings;
        }

        /// <inheritdoc />
        public string Render()
        {
            return _settings.ProjectPath;
        }

        /// <inheritdoc />
        public string RenderSafe()
        {
            return Render();
        }
    }
}