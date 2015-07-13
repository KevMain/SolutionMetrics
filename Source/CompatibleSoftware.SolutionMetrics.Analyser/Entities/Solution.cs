using System.Collections.Generic;
using CompatibleSoftware.SolutionMetrics.Analyser.Structure;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Entities
{
    public class Solution : ISystemFile
    {
        /// <summary>
        /// The name of the solution
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The absolute path to the file
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// A list of all projects found in the solution
        /// </summary>
        public IList<Project> Projects { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filePath"></param>
        /// <param name="projects"></param>
        public Solution(string name, string filePath, IList<Project> projects)
        {
            Name = name;
            FilePath = filePath;
            Projects = projects;
        }
    }
}
