using CompatibleSoftware.SolutionMetrics.Analyser.Metrics;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public interface IAnalyser
    {
        SolutionOverview Process(string solutionFile);
    }
}
