using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <returns>The result of the analyses. Returns a non-zero exit code when at least one Quality Gate fails.</returns>
        internal int Run()
        {
            var processArguments = CreateProcessArguments();

            var processArgumentBuilder = new ProcessArgumentBuilder();
            foreach(var processArgument in processArguments)
                processArgumentBuilder.Append(processArgument);

            var processSettings = new ProcessSettings();

            var process = RunProcess(_settings, processArgumentBuilder, processSettings);
            process.WaitForExit();

            var exitCode = process.GetExitCode();

            Console.WriteLine(process.GetStandardOutput().Select(x => x));

            if(exitCode != 0)
                Console.Error.WriteLine(process.GetStandardError().Select(x => x));

            return exitCode;
        }

        /// <summary>
        ///     Creates the IProcessArgument based on the settings.
        /// </summary>
        /// <returns>The collection of the IProcessArguments.</returns>
        private IReadOnlyCollection<IProcessArgument> CreateProcessArguments()
        {
            var processArguments = new List<IProcessArgument>
                                   {
                                       new ProcessArgumentString(
                                           nameof(_settings.ProjectPath),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.ViewReport),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.Silent),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.HideConsole),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.Concurrent),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.LogTrendMetrics),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.TrendStoreDir),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.PersistHistoricAnalysisResult),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.HistoricAnalysisResultsDir),
                                           _settings),
                                       new ProcessArgumentString(
                                           nameof(_settings.OutDir),
                                           _settings),
                                       new ProcessArgumentString(
                                           nameof(_settings.XslForReport),
                                           _settings),
                                       new ProcessArgumentStringCollection(
                                           nameof(_settings.InDirs),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.KeepProjectInDirs),
                                           _settings),
                                       new ProcessArgumentStringCollection(
                                           nameof(_settings.CoverageFiles),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.KeepProjectCoverageFiles),
                                           _settings),
                                       new ProcessArgumentString(
                                           nameof(_settings.CoverageDir),
                                           _settings),
                                       new ProcessArgumentStringCollection(
                                           nameof(_settings.RuleFiles),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.KeepProjectRuleFiles),
                                           _settings),
                                       new ProcessArgumentStringCollection(
                                           nameof(_settings.PathVariables),
                                           _settings),
                                       new ProcessArgumentBool(
                                           nameof(_settings.AnalysisResultToCompareWith),
                                           _settings)
                                   };


            return processArguments;
        }
    }
}