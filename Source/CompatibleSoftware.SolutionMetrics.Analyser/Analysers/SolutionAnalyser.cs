using CompatibleSoftware.SolutionMetrics.Analyser.Metrics;
using CompatibleSoftware.SolutionMetrics.Analyser.Structure;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public class SolutionAnalyser : IAnalyser
    {
        public SolutionOverview Process(string solutionFile)
        {
            var solution = new Solution(solutionFile);

            var totalFiles = 0;
            var totalLines = 0;
            var linesOfWhitespace = 0;
            var linesOfComments = 0;

            foreach (var project in solution.Projects)
            {
                foreach (var file in project.Files)
                {
                    totalFiles++;

                    foreach (var line in file.Lines)
                    {
                        totalLines++;

                        if (line.IsWhitespace)
                            linesOfWhitespace++;

                        if (line.IsComment)
                            linesOfComments++;
                    }
                }
            }

            return new SolutionOverview(totalFiles, totalLines, linesOfWhitespace, linesOfComments);
        }
    }
}
