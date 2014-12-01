using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CompatibleSoftware.SolutionMetrics.Analyser.FileTypes;

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

        public List<String> DirSearch(string directory, IList<IFileType> filesTypes)
        {
            var ignoredDirectories = new List<string> { "bin", "obj", "packages" };

            var files = new List<String>();

            foreach (var filesType in filesTypes)
            {
                files.AddRange(_directory.GetFiles(directory, filesType.SearchPattern));
            }

            foreach (var childDirectory in _directory.GetDirectories(directory))
            {
                if (ignoredDirectories.All(dir => !dir.Equals(new DirectoryInfo(childDirectory).Name, StringComparison.OrdinalIgnoreCase)))
                    files.AddRange(DirSearch(childDirectory, filesTypes));
            }

            return files;
        }
    }
}
