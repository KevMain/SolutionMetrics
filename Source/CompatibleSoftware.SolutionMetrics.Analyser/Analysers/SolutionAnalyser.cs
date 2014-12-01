using System;
using System.IO;
using CompatibleSoftware.SolutionMetrics.Analyser.Metrics;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Analysers
{
    public class SolutionAnalyser : IAnalyser
    {
        public SolutionAnalyser()
        {
        }

        public SolutionInfo Process(string solutionFile)
        {
            var lines = File.ReadAllLines(solutionFile);

            if (!lines[0].Contains("Microsoft Visual Studio Solution File, Format Version 12.00"))
            {
                throw new ApplicationException("Not a valid solution");
            }

            return new SolutionInfo(100, 200, 10, 10);
        }
    }
}
