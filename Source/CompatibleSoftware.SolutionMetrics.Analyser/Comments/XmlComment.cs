namespace CompatibleSoftware.SolutionMetrics.Analyser.Comments
{
    public class XmlComment : IComment
    {
        public bool IsMatching(string line)
        {
            return line.Trim().StartsWith("///");
        }
    }
}
