using System;
using System.Collections.Generic;
using CompatibleSoftware.SolutionMetrics.Analyser.FileTypes;

namespace CompatibleSoftware.SolutionMetrics.Analyser.FileSystem
{
    public interface IDirectorySearcher
    {
        List<String> DirSearch(string directory, IList<IFileType> filesTypes);
    }
}