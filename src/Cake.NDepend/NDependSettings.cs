using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Cake.Core.Tooling;

namespace Cake.NDepend
{
    /// <summary>
    ///     Settings for the NDepend.
    /// </summary>
    public class NDependSettings : ToolSettings
    {
        /// <summary>
        ///     The NDepend project path. If you need to specify a path that contains a space character use double quotes ".. ..".
        ///     The specified path must be an absolute path, with drive letter C:\ or UNC \\Server\Share format.
        /// </summary>
        public string ProjectPath { get; set; }

        /// <summary>
        ///     To view the HTML report.
        /// </summary>
        public bool ViewReport { get; set; }

        /// <summary>
        ///     To disable output and eventual calls to Console.Read() on console.
        /// </summary>
        public bool Silent { get; set; }

        /// <summary>
        ///     To hide the console window.
        /// </summary>
        public bool HideConsole { get; set; }

        /// <summary>
        ///     To parralelize analysis execution.
        /// </summary>
        public bool Concurrent { get; set; }

        /// <summary>
        ///     To force log trend metrics.
        /// </summary>
        public bool LogTrendMetrics { get; set; }

        /// <summary>
        ///     To override the trend store directory specified in the NDepend project file.
        /// </summary>
        public bool TrendStoreDir { get; set; }

        /// <summary>
        ///     To force persist historic analysis result.
        /// </summary>
        public bool PersistHistoricAnalysisResult { get; set; }

        /// <summary>
        ///     To override the historic analysis results directory specified in the NDepend project file.
        /// </summary>
        public bool HistoricAnalysisResultsDir { get; set; }

        /// <summary>
        ///     To override the output directory specified in the NDepend project file.
        ///     VisualNDepend.exe won't work on the machine where you used NDepend.Console.exe with the option OutDir because
        ///     VisualNDepend.exe is not aware of the output dir specified and will try to use the output dir specified in your
        ///     NDepend project file.
        /// </summary>
        public string OutDir { get; set; }

        /// <summary>
        ///     To provide your own Xsl file used to build report.
        /// </summary>
        public string XslForReport { get; set; }

        /// <summary>
        ///     To override input directories specified in the NDepend project file.
        ///     To customize the location(s) where assemblies to analyze (application assemblies and third-party assemblies) can be
        ///     found. The search is not recursive.
        /// </summary>
        public IReadOnlyCollection<string> InDirs { get; set; }

        /// <summary>
        ///     Directly after the option InDirs, the option KeepProjectInDirs can be used to avoid ignoring directories specified
        ///     in the NDepend project file.
        /// </summary>
        public bool KeepProjectInDirs { get; set; }

        /// <summary>
        ///     To override input coverage files specified in the NDepend project file.
        /// </summary>
        public IReadOnlyCollection<string> CoverageFiles { get; set; }

        /// <summary>
        ///     Directly after the option CoverageFiles, the option KeepProjectCoverageFiles can be used to avoid ignoring coverage
        ///     files specified in the NDepend project file.
        /// </summary>
        public bool KeepProjectCoverageFiles { get; set; }

        /// <summary>
        ///     To override the directory that contains coverage files specified in the project file.
        /// </summary>
        public string CoverageDir { get; set; }

        /// <summary>
        ///     To override input rule files specified in the NDepend project file.
        /// </summary>
        public IReadOnlyCollection<string> RuleFiles { get; set; }

        /// <summary>
        ///     Directly after the option RuleFiles, the option KeepProjectRuleFiles can be used to avoid ignoring rule files
        ///     specified in the NDepend project file.
        /// </summary>
        public bool KeepProjectRuleFiles { get; set; }

        /// <summary>
        ///     To override the values of one or several NDepend project path variables, or create new path variables.
        /// </summary>
        public IReadOnlyCollection<string> PathVariables { get; set; }

        /// <summary>
        ///     To provide a previous analysis result to compare with.
        ///     Analysis results are stored in files with file name prefix NDependAnalysisResult_ and with extension.ndar.These
        ///     files can be found under the NDepend project output directory.The prefered option to provide a previous analysis
        ///     result to compare with during an analysis is to use: NDepend > Project Properties > Analysis > Baseline for
        ///     Comparison.
        ///     You can use the option AnalysisResultToCompareWith in special scenarios where using Project Properties
        ///     doesn't work.
        /// </summary>
        public string AnalysisResultToCompareWith { get; set; }

        /// <summary>
        ///     The invalid options after validation.
        /// </summary>
        internal string InvalidOption { get; private set; }

        /// <summary>
        ///     Validates the setting options before running the NDepend.Console.exe.
        /// </summary>
        /// <returns>True if valid, false otherwise.</returns>
        internal bool ValidateSettingOptions()
        {
            if(!string.IsNullOrWhiteSpace(ProjectPath) && File.Exists(ProjectPath))
                return true;

            InvalidOption = nameof(ProjectPath);
            return false;
        }
    }
}