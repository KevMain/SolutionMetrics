using System.IO;

namespace CompatibleSoftware.SolutionMetrics.Analyser.FileSystem
{
    public class SystemFile : IFile
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public FileStream OpenRead(string path)
        {
            return File.OpenRead(path);
        }
    }
}
