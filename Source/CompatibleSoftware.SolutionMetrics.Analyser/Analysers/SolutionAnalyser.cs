using System;
using System.Collections.Generic;
using System.IO;
using CompatibleSoftware.SolutionMetrics.Analyser.Metrics;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public class SolutionAnalyser : IAnalyser
    {
        public SolutionInfo Process(string solutionFile)
        {
            var solutionName = Path.GetFileName(solutionFile);
            
            var basePath = Path.GetDirectoryName(solutionFile);

            var solution = new SolutionInfo(solutionName);

            var lines = File.ReadAllLines(solutionFile);

            if (!lines[0].Contains("Microsoft Visual Studio Solution File, Format Version 12.00"))
            {
                throw new ApplicationException("Not a valid solution");
            }

            var projects = BuildProjectListFromSolution(lines, basePath);
            foreach (var project in projects)
            {
                solution.AddProject(project);
            }
            
            return solution;
        }

        public IList<ProjectInfo> BuildProjectListFromSolution(string[] lines, string basePath)
        {
            IList<ProjectInfo> projects = new List<ProjectInfo>();

            foreach (var line in lines)
            {
                if (line.StartsWith("Project("))
                {
                    var projectParts = line.Split(',');
                    if (projectParts.Length != 3)
                    {
                        throw new ApplicationException("Badly formed Visual Studio Solution file");
                    }

                    //TODO: Meh. refactor this
                    var projectName = projectParts[0].Split('"')[3];
                    var projectPath = projectParts[1].Trim();
                    var relativePath = projectPath.Substring(1, projectPath.Length - 2);
                    var fullPath = basePath + "\\" + relativePath;

                    //TODO: Define project types
                    if (fullPath.Trim().EndsWith(".csproj"))
                    {
                        projects.Add(new ProjectInfo(projectName, fullPath));
                    }
                }
            }

            return projects;
        }
    }
}
