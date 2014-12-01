namespace CompatibleSoftware.SolutionMetrics.Analyser.FileTypes
{
    public class CSharpClass : IFileType
    {
        public string SearchPattern
        {
            get { return "*.cs"; }
        }
    }
}
