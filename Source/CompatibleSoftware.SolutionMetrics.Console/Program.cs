using System;
using System.Collections.Generic;
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

            var analyser = new FileAnalyser(dir);
            analyser.Run();

            System.Console.ReadLine();
        }
    }
}
