using System.Collections.Generic;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Metrics
{
    public class SolutionInfo
    {
        /// <summary>
        /// The name of the solution
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// A list of all projects found in the solution
        /// </summary>
        public IList<ProjectInfo> Projects { get; private set; }
   
        public SolutionInfo(string name)
        {
            Name = name;
            Projects = new List<ProjectInfo>();
        }

        /// <summary>
        /// Adds a new project to the solution
        /// </summary>
        /// <param name="project"></param>
        public void AddProject(ProjectInfo project)
        {
            Projects.Add(project);
        }
    }
}
