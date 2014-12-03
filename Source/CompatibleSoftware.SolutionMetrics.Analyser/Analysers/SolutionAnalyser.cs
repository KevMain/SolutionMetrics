using CompatibleSoftware.SolutionMetrics.Analyser.Structure;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public class SolutionAnalyser : IAnalyser
    {
        public Solution Process(string solutionFile)
        {
            var solution = new Solution(solutionFile);

            //TODO: Analyse the solution

            return solution;
        }
    }
}
