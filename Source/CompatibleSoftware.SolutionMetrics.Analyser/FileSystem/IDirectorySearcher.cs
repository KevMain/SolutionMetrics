using System;
using System.Collections.Generic;

namespace CompatibleSoftware.SolutionMetrics.Analyser.FileSystem
{
    public interface IDirectorySearcher
    {
        List<String> DirSearch(string directory, string patternMatch);
    }
}