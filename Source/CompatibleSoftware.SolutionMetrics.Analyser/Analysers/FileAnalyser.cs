using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CompatibleSoftware.SolutionMetrics.Analyser.FileSystem;
using CompatibleSoftware.SolutionMetrics.Analyser.FileTypes;
using CompatibleSoftware.SolutionMetrics.Analyser.Metrics;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public class FileAnalyser
    {
        private readonly IDirectorySearcher _directorySearcher;

        public FileAnalyser(IDirectorySearcher directorySearcher)
        {
            if (directorySearcher == null)
                throw new ArgumentNullException("directorySearcher");

            _directorySearcher = directorySearcher;
        }

        public SolutionInfo Process(string directory)
        {
            var files = new List<string>();

            var filesTypes = new List<IFileType> {new CSharpClass(), new VbClass()};

            files.AddRange(_directorySearcher.DirSearch(directory, filesTypes));
            
            var codeLines = new List<CodeLine>();

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
    }
}
