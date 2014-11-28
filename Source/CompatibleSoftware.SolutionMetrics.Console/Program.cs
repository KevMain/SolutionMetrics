using System.Diagnostics;
using CompatibleSoftware.SolutionMetrics.Analyser;

namespace CompatibleSoftware.SolutionMetrics.Console
{
    class Program
    {
        static void Main()
        {
            System.Console.WriteLine("Which directory to analyse?");
            var dir = System.Console.ReadLine();

            System.Console.WriteLine("");
            System.Console.WriteLine("********************************************************************");
            System.Console.WriteLine("Analysing directory " + dir);

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var solutionInfo = new FileAnalyser(dir).Run();

            stopwatch.Stop();
            System.Console.WriteLine("********************************************************************");
            System.Console.WriteLine("Total Files: " + solutionInfo.TotalFiles);
            System.Console.WriteLine("Total Lines: " + solutionInfo.TotalLines);
            System.Console.WriteLine("Average Lines Per File: " + solutionInfo.AverageLinesPerFile);
            System.Console.WriteLine("Lines Of Code: " + solutionInfo.LinesOfCode);
            System.Console.WriteLine("Lines Of Whitespace: " + solutionInfo.LinesOfWhitespace);
            System.Console.WriteLine("Lines Of Comments: " + solutionInfo.LinesOfComments);
            System.Console.WriteLine("Comments Percentage: " + solutionInfo.CommentsPercentage + "%");
            System.Console.WriteLine("Time taken to analyse: " + stopwatch.Elapsed.TotalSeconds);
            System.Console.WriteLine("");
            System.Console.WriteLine("********************************************************************");
            System.Console.ReadLine();
        }
    }
}
