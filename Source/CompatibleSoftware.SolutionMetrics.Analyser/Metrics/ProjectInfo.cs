using System;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Metrics
{
    public class ProjectInfo
    {
        /// <summary>
        /// The name of the project
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The path to the project file
        /// </summary>
        public string ProjectPath { get; private set; }

        /// <summary>
        /// The main constructor
        /// </summary>
        /// <param name="name">The name of the project</param>
        /// <param name="projectPath">The absolute path to the project file</param>
        public ProjectInfo(string name, string projectPath)
        {
            Name = name;
            ProjectPath = projectPath;
        }
    }
}
