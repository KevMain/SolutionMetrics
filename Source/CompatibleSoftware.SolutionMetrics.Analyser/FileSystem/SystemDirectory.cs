using System.IO;

namespace CompatibleSoftware.SolutionMetrics.Analyser.FileSystem
{
    public class SystemDirectory : IDirectory
    {
        public string[] GetFiles(string directory, string patternMatch)
        {
            return Directory.GetFiles(directory, patternMatch);
        }

        public string[] GetDirectories(string directory)
        {
            return Directory.GetDirectories(directory);
        }
    }
}
