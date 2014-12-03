using System;
using System.Collections.Generic;
using System.IO;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Structure
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
        /// The main constructor
        /// </summary>
        /// <param name="filePath">The full absolute path to the solution file</param>
        public Solution(string filePath)
        {
            FilePath = filePath;
            Name = Path.GetFileNameWithoutExtension(filePath);
            Projects = ReadProjectsFromSolutionFile();
        }

        private IList<Project> ReadProjectsFromSolutionFile()
        {
            IList<Project> projects = new List<Project>();

            var lines = File.ReadAllLines(FilePath);

            if (!lines[0].Contains("Microsoft Visual Studio Solution File, Format Version 12.00"))
            {
                throw new ApplicationException("Not a valid solution");
            }

            foreach (var line in lines)
            {
                if (line.StartsWith("Project("))
                {
                    var projectParts = line.Split(',');
                    if (projectParts.Length != 3)
                    {
                        throw new ApplicationException("Badly formed Visual Studio Solution file");
                    }

                    var projectName = projectParts[0].Split('"')[3];
                    var projectPath = projectParts[1].Trim();
                    var relativePath = projectPath.Substring(1, projectPath.Length - 2);
                    var fullPath = Path.GetDirectoryName(FilePath) + "\\" + relativePath;

                    if (fullPath.Trim().EndsWith(".csproj"))
                    {
                        projects.Add(new Project(projectName, fullPath));
                    }
                }
            }

            return projects;
        }
    }
}
