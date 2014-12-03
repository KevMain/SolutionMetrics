namespace CompatibleSoftware.SolutionMetrics.Analyser.Structure
{
    public interface ISystemFile
    {
        /// <summary>
        /// The name of the file
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The absolute path to the file
        /// </summary>
        string FilePath { get; }
    }
}
