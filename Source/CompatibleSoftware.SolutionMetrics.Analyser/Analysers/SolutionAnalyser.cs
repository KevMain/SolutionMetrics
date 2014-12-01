using System;
using System.IO;
using CompatibleSoftware.SolutionMetrics.Analyser.Metrics;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public class SolutionAnalyser : IAnalyser
    {
        public SolutionInfo Process(string solutionFile)
        {
            var solutionName = Path.GetFileName(solutionFile);

            var solution = new SolutionInfo(solutionName);

            var lines = File.ReadAllLines(solutionFile);

            if (!lines[0].Contains("Microsoft Visual Studio Solution File, Format Version 12.00"))
            {
                throw new ApplicationException("Not a valid solution");
            }

            BuildProjectListFromSolution(lines, solution);

            return solution;
        }

        public void BuildProjectListFromSolution(string[] lines, SolutionInfo solution)
        {
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

                    solution.AddProject(new ProjectInfo(projectName));
                }
            }
        }
    }
}
