using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompatibleSoftware.SolutionMetrics.Analyser.FileSystem
{
    public class DirectorySearcher : IDirectorySearcher
    {
        private readonly IDirectory _directory;

        public DirectorySearcher(IDirectory directory)
        {
            if(directory == null)
                throw new ArgumentNullException("directory");

            _directory = directory;
        }

        public List<String> DirSearch(string directory, string patternMatch)
        {
            var files = new List<String>();

            files.AddRange(_directory.GetFiles(directory, patternMatch));

            var ignoredDirectories = new List<string> { "bin", "obj", "packages" };

            foreach (var d in _directory.GetDirectories(directory))
            {
                if (ignoredDirectories.All(dir => !dir.Equals(new DirectoryInfo(d).Name, StringComparison.OrdinalIgnoreCase)))
                    files.AddRange(DirSearch(d, patternMatch));
            }

            return files;
        }
    }
}
