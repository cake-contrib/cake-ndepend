using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.NDepend
{
    /// <summary>
    ///     The NDepend Console Runner. Abstracts over NDepend.Console.exe.
    /// </summary>
    internal sealed class NDependConsoleRunner : Tool<NDependSettings>
    {
        private readonly NDependSettings _settings;

        /// <summary>
        ///     Initializes a new instance of the NDependConsoleRunner class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="settings">The NDepend settings.</param>
        internal NDependConsoleRunner(IFileSystem fileSystem,
                                      ICakeEnvironment environment,
                                      IProcessRunner processRunner,
                                      IToolLocator tools,
                                      NDependSettings settings) : base(fileSystem, environment, processRunner, tools)
        {
            _settings = settings;
        }

        /// <inheritdoc />
        protected override string GetToolName()
        {
            return "NDepend.Console";
        }

        /// <inheritdoc />
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] {"NDepend.Console.exe", "ndepend.console.exe", "NDepend.Console", "ndepend.console"};
        }

        /// <summary>
        ///     Runs the NDepend.Console.exe with the provided arguments.
        /// </summary>
        /// <returns>The result of the analysis. Returns a non-zero exit code when at least one Quality Gate fails.</returns>
        internal int Run()
        {
            var processArguments = CreateProcessArguments();

            var processArgumentBuilder = new ProcessArgumentBuilder();
            foreach(var processArgument in processArguments)
                processArgumentBuilder.Append(processArgument);

            var processSettings = new ProcessSettings();

            var process = RunProcess(_settings, processArgumentBuilder, processSettings);
            process.WaitForExit();

            return process.GetExitCode();
        }

        /// <summary>
        ///     Creates the IProcessArgument based on the settings.
        /// </summary>
        /// <returns>The collection of the IProcessArguments.</returns>
        private IReadOnlyCollection<IProcessArgument> CreateProcessArguments()
        {
            var processArguments = new List<IProcessArgument>
                                   {
                                       new ProcessArgumentProject(
                                           _settings),
                                       new ProcessArgumentBool(
                                           "ViewReport",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "Silent",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "HideConsole",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "Concurrent",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "LogTrendMetrics",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "TrendStoreDir",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "PersistHistoricAnalysisResult",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "HistoricAnalysisResultsDir",
                                           _settings),
                                       new ProcessArgumentString(
                                           "OutDir",
                                           _settings),
                                       new ProcessArgumentString(
                                           "XslForReport",
                                           _settings),
                                       new ProcessArgumentStringCollection(
                                           "InDirs",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "KeepProjectInDirs",
                                           _settings),
                                       new ProcessArgumentStringCollection(
                                           "CoverageFiles",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "KeepProjectCoverageFiles",
                                           _settings),
                                       new ProcessArgumentString(
                                           "CoverageDir",
                                           _settings),
                                       new ProcessArgumentStringCollection(
                                           "RuleFiles",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "KeepProjectRuleFiles",
                                           _settings),
                                       new ProcessArgumentStringCollection(
                                           "PathVariables",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "AnalysisResultToCompareWith",
                                           _settings),
                                       new ProcessArgumentBool(
                                           "ForceReturnZeroExitCode",
                                           _settings)
                                   };


            return processArguments;
        }
    }
}