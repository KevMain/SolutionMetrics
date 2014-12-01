namespace CompatibleSoftware.SolutionMetrics.Analyser.FileTypes
{
    public class VbClass : IFileType
    {
        public string SearchPattern
        {
            get { return "*.vb"; }
        }
    }
}
