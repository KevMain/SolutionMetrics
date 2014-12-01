using CompatibleSoftware.SolutionMetrics.Analyser.Metrics;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public interface IAnalyser
    {
        SolutionInfo Process(string solutionFile);
    }
}
