using System;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Metrics
{
    public class SolutionInfo
    {
        public int TotalLines { get; private set; }

        public int LinesOfCode { get; private set; }

        public int LinesOfWhitespace { get; private set; }

        public int LinesOfComments { get; private set; }

        public double CommentsPercentage { get; private set; }

        public SolutionInfo(int totalLines, int linesOfWhitespace, int linesOfComments)
        {
            TotalLines = totalLines;
            LinesOfWhitespace = linesOfWhitespace;
            LinesOfComments = linesOfComments;
            LinesOfCode = totalLines - linesOfWhitespace - linesOfComments;

            var commentPercent = ((double)linesOfComments / totalLines) * 100;

            CommentsPercentage = Math.Round(commentPercent, 2);
        }
    }
}
