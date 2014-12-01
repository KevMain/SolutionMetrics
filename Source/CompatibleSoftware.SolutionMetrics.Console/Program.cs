using System;
using System.Diagnostics;
using CompatibleSoftware.SolutionMetrics.Analyser.Analysers;
using CompatibleSoftware.SolutionMetrics.Analyser.FileSystem;

namespace CompatibleSoftware.SolutionMetrics.Console
{
    class Program
    {
        static void Main()
        {
            try
            {
                System.Console.WriteLine("Which directory to analyse?");
                var dir = System.Console.ReadLine();

                System.Console.WriteLine("");
                System.Console.WriteLine("********************************************************************");
                System.Console.WriteLine("Analysing directory " + dir);

                var stopwatch = new Stopwatch();

                stopwatch.Start();

                var solutionInfo = new SolutionAnalyser().Process(dir);

                stopwatch.Stop();
                System.Console.WriteLine("********************************************************************");
                System.Console.WriteLine("Solution Name: " + solutionInfo.Name);
                foreach (var projectInfo in solutionInfo.Projects)
                {
                    System.Console.WriteLine("Paths: " + projectInfo.ProjectPath);  
                }
                System.Console.WriteLine("Number of Projects: " + solutionInfo.Projects.Count);  
                System.Console.WriteLine("");
                System.Console.WriteLine("********************************************************************");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("An error occured: " + ex.Message);
            }

            System.Console.ReadLine();
        }
    }
}
