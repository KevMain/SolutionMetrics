using System.Collections.Generic;
using System.IO;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Structure
{
    public class CodeFile : ISystemFile
    {
        /// <summary>
        /// The name of the file
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The path to the file
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// A list of all code files found in the project
        /// </summary>
        public IList<CodeLine> Lines { get; private set; }

        /// <summary>
        /// The main constructor
        /// </summary>
        /// <param name="filePath">The absolute path to the file</param>
        public CodeFile(string filePath)
        {
            FilePath = filePath;
            Name = Path.GetFileNameWithoutExtension(filePath);
            
            Lines = ReadAllLinesFromFile();
        }

        /// <summary>
        /// Reads the code file line by line and creates a list
        /// </summary>
        /// <returns>A list of code lines</returns>
        private IList<CodeLine> ReadAllLinesFromFile()
        {
            IList<CodeLine> codeLines = new List<CodeLine>();

            var inCommentBlock = false; 
            foreach (var line in File.ReadLines(FilePath))
            {
                if (!inCommentBlock && line.Trim().StartsWith("/*"))
                    inCommentBlock = true;

                codeLines.Add(new CodeLine(line, inCommentBlock));

                if (inCommentBlock && line.Trim().EndsWith("*/"))
                    inCommentBlock = false;
            }

            return codeLines;
        }
    }
}
