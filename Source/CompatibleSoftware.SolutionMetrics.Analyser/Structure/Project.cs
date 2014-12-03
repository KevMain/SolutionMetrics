using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Structure
{
    public class Project
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
        /// A list of all code files found in the project
        /// </summary>
        public IList<CodeFile> Files { get; private set; }

        /// <summary>
        /// The main constructor
        /// </summary>
        /// <param name="name">The name of the project</param>
        /// <param name="projectPath">The absolute path to the project file</param>
        public Project(string name, string projectPath)
        {
            Name = name;
            ProjectPath = projectPath;

            Files = new List<CodeFile>();

            Process();
        }

        /// <summary>
        /// Adds a new file to the project
        /// </summary>
        /// <param name="codeFile">The file to add</param>
        public void AddFile(CodeFile codeFile)
        {
            Files.Add(codeFile);
        }

        private void Process()
        {
            Console.WriteLine("Project.." + ProjectPath);

            var contents = ReadProjectFileContents();

            var files = ReadFilesFromProjectFile(contents);

            foreach (var codeFile in files)
            {
                Console.WriteLine(codeFile.Name + " = " + codeFile.FilePath);
            }
        }

        //TODO: Refactor all this
        private IEnumerable<CodeFile> ReadFilesFromProjectFile(string content)
        {
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
            
            if (root != null)
            {
                var files = root.SelectNodes("//x:Compile", mgr);

                if (files != null)
                {
                    foreach (XmlNode file in files)
                    {
                        if (file.Attributes != null)
                            projectFiles.Add(new CodeFile(file.Attributes["Include"].Value));
                    }
                }
            }

            return projectFiles;
        }

        //TODO: Move file reading stuff out
        private string ReadProjectFileContents()
        {
            //TODO: Error handling if file not available

            var fileStream = File.OpenRead(ProjectPath);

            var contents = new StringWriter();

            var bytes = new byte[1000];

            var bytesRead = fileStream.Read(bytes, 0, bytes.Length);

            while (bytesRead > 0)
            {
                for (var i = 0; i < bytesRead; i++)
                {
                    contents.Write((char)bytes[i]);
                }
                bytesRead = fileStream.Read(bytes, 0, bytes.Length);
            }

            fileStream.Close();

            return contents.ToString();
        }    
    }
}
