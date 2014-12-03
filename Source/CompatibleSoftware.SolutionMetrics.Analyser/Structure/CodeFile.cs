using System.Collections.Generic;
using System.IO;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Structure
{
    public class CodeFile
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
        }
    }
}
