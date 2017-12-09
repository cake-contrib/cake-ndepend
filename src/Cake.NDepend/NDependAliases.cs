using System;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.NDepend.Exceptions;

namespace Cake.NDepend
{
    /// <summary>
    ///     Contains functionality for working with NDepend commands.
    /// </summary>
    [CakeAliasCategory("NDepend")]
    public static class NDependAliases
    {
        /// <summary>
        ///     Analyses a NDepend project.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The NDepend settings.</param>
        [CakeMethodAlias]
        public static void NDependAnalyse(this ICakeContext context, NDependSettings settings)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));

            if(settings == null)
                throw new ArgumentNullException(nameof(settings));

            if(!settings.ValidateSettingOptions())
                throw new NDependSettingsOptionException(settings.InvalidOption);

            var runner = new NDependConsoleRunner(
                context.FileSystem,
                context.Environment,
                context.ProcessRunner,
                context.Tools,
                settings);

            var result = runner.Run();

            if(result != 0)
                throw new NDependConsoleRunnerException("NDepend Console runner return non-zero result.");
        }
    }
}