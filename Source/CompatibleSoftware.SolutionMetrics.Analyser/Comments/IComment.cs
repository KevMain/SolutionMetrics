namespace CompatibleSoftware.SolutionMetrics.Analyser.Comments
{
    public interface IComment
    {
        bool IsMatching(string line);
    }
}
