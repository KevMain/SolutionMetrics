using CompatibleSoftware.SolutionMetrics.Analyser.Domain;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Services
{
    public interface ISolutionReaderService
    {
        Solution ReadProjectsFromSolutionFile(string filePath);
    }
}