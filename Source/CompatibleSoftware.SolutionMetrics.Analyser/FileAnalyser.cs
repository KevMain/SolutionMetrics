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

            var totalLines = 0; 
            var totalComments = 0;

            var inCommentBlock = false;

            foreach (var file in files)
            {
                foreach (var line in File.ReadLines(file))
                {
                    totalLines++;

                    if (inCommentBlock || line.Trim().StartsWith("//") || line.Trim().StartsWith("///") || line.Trim().StartsWith("'"))
                        totalComments++;

                    if (!inCommentBlock && line.Trim().StartsWith("/*"))
                        inCommentBlock = true;

                    if (inCommentBlock && line.Trim().EndsWith("*/"))
                        inCommentBlock = false;

                }
            }

            var commentPercent = ((double)totalComments / totalLines) * 100;

            Console.WriteLine("Total Lines: " + totalLines);
            Console.WriteLine("Lines Of Comments: " + totalComments);
            Console.WriteLine("Comments Percentage: " + Math.Round(commentPercent, 0) + "%");
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
