using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

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

            Process();
        }

        private void Process()
        {
            Console.WriteLine("Project.." + ProjectPath);

            var contents = ReadProjectFileContents();

            var files = ReadFilesFromProjectFile(contents);
        }

        private List<string> ReadFilesFromProjectFile(string content)
        {
            //Special case for UTF byte mark
            if (!content.StartsWith("<"))
            {
                var startIndex = content.IndexOf('<');
                content = content.Remove(0, startIndex);
            }

            var projectDocument = new XmlDocument();
            projectDocument.Load(new StringReader(content));

            XmlNode root = projectDocument.DocumentElement;
            
            if (root != null)
            {
            }

            return new List<string>();
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
