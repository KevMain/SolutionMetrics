using System.Collections.Generic;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Structure
{
    public class Solution
    {
        /// <summary>
        /// The name of the solution
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// A list of all projects found in the solution
        /// </summary>
        public IList<Project> Projects { get; private set; }
   
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="name">The name of the solution</param>
        public Solution(string name)
        {
            Name = name;
            Projects = new List<Project>();
        }

        /// <summary>
        /// Adds a new project to the solution
        /// </summary>
        /// <param name="project">The project to add</param>
        public void AddProject(Project project)
        {
            Projects.Add(project);
        }
    }
}
