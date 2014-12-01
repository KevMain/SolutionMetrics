namespace CompatibleSoftware.SolutionMetrics.Analyser.FileSystem
{
    public interface IDirectory
    {
        string[] GetFiles(string directory, string patternMatch);

        string[] GetDirectories(string directory);
    }
}
