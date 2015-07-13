using System.IO;

namespace CompatibleSoftware.SolutionMetrics.Analyser.FileSystem
{
    public interface IFile
    {
        string[] ReadAllLines(string path);
        FileStream OpenRead(string path);
    }
}
