using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CompatibleSoftware.SolutionMetrics.Analyser.Metrics;

namespace CompatibleSoftware.SolutionMetrics.Analyser
{
    public class FileAnalyser
    {
        private readonly string _directory;

        public FileAnalyser(string directory)
        {
            _directory = directory;
        }

        public SolutionInfo Run()
        {
            var files = new List<string>();

            DirSearch(_directory, files, "*.cs");
            DirSearch(_directory, files, "*.vb");

            IList<CodeLine> codeLines = new List<CodeLine>();

            var inCommentBlock = false; 
            foreach (var file in files)
            {
                foreach (var line in File.ReadLines(file))
                {
                    if (!inCommentBlock && line.Trim().StartsWith("/*"))
                        inCommentBlock = true;

                    codeLines.Add(new CodeLine(line, inCommentBlock));

                    if (inCommentBlock && line.Trim().EndsWith("*/"))
                        inCommentBlock = false;
                }
            }

            var totalFiles = files.Count();
            var totalLines = codeLines.Count();
            var totalWhitespace = codeLines.Count(line => line.IsWhitespace);
            var totalComments = codeLines.Count(line => line.IsComment);

            return new SolutionInfo(totalFiles, totalLines, totalWhitespace, totalComments);
        }

        private void DirSearch(string directory, List<String> files, string patternMatch)
        {
            files.AddRange(Directory.GetFiles(directory, patternMatch));

            var ignoredDirectories = new List<string> {"bin", "obj", "packages"};

            foreach (var d in Directory.GetDirectories(directory))
            {
                if (ignoredDirectories.All(dir => !dir.Equals(new DirectoryInfo(d).Name, StringComparison.OrdinalIgnoreCase)))
                    DirSearch(d, files, patternMatch);
            }
        }
    }
}
