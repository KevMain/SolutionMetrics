using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Metrics
{
    public class ProjectInfo
    {
        /// <summary>
        /// The name of the project
        /// </summary>
        public string Name { get; private set; }

        public ProjectInfo(string name)
        {
            Name = name;
        }
    }
}
