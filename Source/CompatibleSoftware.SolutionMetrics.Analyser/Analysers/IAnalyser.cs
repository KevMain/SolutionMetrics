using CompatibleSoftware.SolutionMetrics.Analyser.Structure;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public interface IAnalyser
    {
        Solution Process(string solutionFile);
    }
}
