namespace CompatibleSoftware.SolutionMetrics.Analyser.Comments
{
    public class CSharpComment : IComment
    {
        public bool IsMatching(string line)
        {
            return line.Trim().StartsWith("//");
        }
    }
}
