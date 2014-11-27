using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompatibleSoftware.SolutionMetrics.Analyser
{
    public class FileAnalyser
    {
        private readonly string _directory;

        public FileAnalyser(string directory)
        {
            _directory = directory;
        }

        public void Run()
        {
            var files = new List<string>();

            DirSearch(_directory, files, "*.cs");
            DirSearch(_directory, files, "*.vb");

            var totalLines = files.Sum(file => File.ReadLines(file).Count(line => !String.IsNullOrWhiteSpace(line)));

            Console.WriteLine("Lines Of Code: " + totalLines);
        }

        private void DirSearch(string directory, List<String> files, string patternMatch)
        {
            try
            {
                files.AddRange(Directory.GetFiles(directory, patternMatch));

                var ignoredDirectories = new List<string> {"bin", "obj", "packages"};

                foreach (var d in Directory.GetDirectories(directory))
                {
                    if (ignoredDirectories.All(dir => !dir.Equals(new DirectoryInfo(d).Name, StringComparison.OrdinalIgnoreCase)))
                        DirSearch(d, files, patternMatch);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured - " +  ex.Message);
            }

        }
    }
}
