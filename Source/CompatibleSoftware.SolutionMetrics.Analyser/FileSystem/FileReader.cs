using System.IO;

namespace CompatibleSoftware.SolutionMetrics.Analyser.FileSystem
{
    public static class FileReader
    {
        public static string ReadFileContents(string filePath)
        {
            var fileStream = File.OpenRead(filePath);

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
