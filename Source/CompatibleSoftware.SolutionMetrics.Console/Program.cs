using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompatibleSoftware.SolutionMetrics.Analyser;

namespace CompatibleSoftware.SolutionMetrics.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Which directory to analyse?");
            var dir = System.Console.ReadLine();

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var solutionInfo = new FileAnalyser(dir).Run();

            stopwatch.Stop();

            System.Console.WriteLine("Total Lines: " + solutionInfo.TotalLines);
            System.Console.WriteLine("Lines Of Code: " + solutionInfo.LinesOfCode);
            System.Console.WriteLine("Lines Of Whitespace: " + solutionInfo.LinesOfWhitespace);
            System.Console.WriteLine("Lines Of Comments: " + solutionInfo.LinesOfComments);
            System.Console.WriteLine("Comments Percentage: " + solutionInfo.CommentsPercentage + "%");
            System.Console.WriteLine("Time taken to analyse: " + stopwatch.Elapsed.TotalSeconds);

            System.Console.ReadLine();
        }
    }
}
