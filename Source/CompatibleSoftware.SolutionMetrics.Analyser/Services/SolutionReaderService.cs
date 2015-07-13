using System;
using System.Collections.Generic;
using System.IO;
using CompatibleSoftware.SolutionMetrics.Analyser.Domain;
using CompatibleSoftware.SolutionMetrics.Analyser.FileSystem;
using CompatibleSoftware.SolutionMetrics.Analyser.Structure;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Services
{
    public class SolutionReaderService : ISolutionReaderService
    {
        private readonly IFile _file;

        public SolutionReaderService(IFile file)
        {
            if (file == null)
                throw new ArgumentNullException("file");

            _file = file;
        }

        public Solution ReadProjectsFromSolutionFile(string filePath)
        {
            IList<Project> projects = new List<Project>();

            var lines = _file.ReadAllLines(filePath);

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
                    var fullPath = Path.GetDirectoryName(filePath) + "\\" + relativePath;

                    if (fullPath.Trim().EndsWith(".csproj"))
                    {
                        var project = new Project();
                        project.ReadFilesFromProjectFile(projectName, fullPath);
                        projects.Add(project);
                    }
                }
            }

            return new Solution(filePath, Path.GetFileNameWithoutExtension(filePath), projects);
        }
    }
}
