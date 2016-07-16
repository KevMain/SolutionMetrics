using System.Collections.Generic;
using System.IO;
using System.Xml;
using CompatibleSoftware.SolutionMetrics.Analyser.FileSystem;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Structure
{
    public class Project : ISystemFile
    {
        /// <summary>
        /// The name of the project
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The path to the project file
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// A list of all code files found in the project
        /// </summary>
        public IList<CodeFile> Files { get; private set; }

        /// <summary>
        /// The main constructor
        /// </summary>
        /// <param name="name">The name of the project</param>
        /// <param name="filePath">The absolute path to the project file</param>
        public Project(string name, string filePath)
        {
            Name = name;
            FilePath = filePath;
            
            Files = ReadFilesFromProjectFile();
        }

        /// <summary>
        /// Adds a new file to the project
        /// </summary>
        /// <param name="codeFile">The file to add</param>
        public void AddFile(CodeFile codeFile)
        {
            Files.Add(codeFile);
        }

        /// <summary>
        /// Read the project file and create a list of included code files
        /// </summary>
        /// <returns>A list of code files in the project</returns>
        private IList<CodeFile> ReadFilesFromProjectFile()
        {
            var content = FileReader.ReadFileContents(FilePath);
            
            var projectFiles = new List<CodeFile>();

            //Special case for UTF byte mark
            if (!content.StartsWith("<"))
            {
                var startIndex = content.IndexOf('<');
                content = content.Remove(0, startIndex);
            }

            var projectDocument = new XmlDocument();
            projectDocument.Load(new StringReader(content));

            var mgr = new XmlNamespaceManager(projectDocument.NameTable);
            mgr.AddNamespace("x", "http://schemas.microsoft.com/developer/msbuild/2003");

            XmlNode root = projectDocument.DocumentElement;

          var files = root?.SelectNodes("//x:Compile", mgr);

          if (files == null) return projectFiles;

          foreach (XmlNode file in files)
          {
            if (file.Attributes == null) continue;

            var fullPath = Path.GetDirectoryName(FilePath) + "\\" + file.Attributes["Include"].Value;

            if (!fullPath.Contains(".."))
            {
              projectFiles.Add(new CodeFile(fullPath));
            }
          }

          return projectFiles;
        }
    }
}
