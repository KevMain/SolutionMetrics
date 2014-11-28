namespace CompatibleSoftware.SolutionMetrics.Analyser.Comments
{
    public class VbComment : IComment
    {
        public bool IsMatching(string line)
        {
            return line.Trim().StartsWith("'");
        }
    }
}
