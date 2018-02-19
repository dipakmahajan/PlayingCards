using System;
using System.IO;

namespace PlayingCards
{
    /// <summary>
    /// Helper class for file operations
    /// </summary>
    public static class FileOperations
    {
        /// <summary>
        /// Writes the text file
        /// </summary>
        /// <param name="filePath">Full physical path for text file</param>
        /// <returns>file contents</returns>
        public static void WriteTextFile(string contents)
        {
            if (string.IsNullOrWhiteSpace(contents))
            {
                throw new ArgumentException("No content provided to be written in text file.");
            }

            using (StreamWriter w = File.AppendText("Result.txt"))
            {
                w.WriteLine(contents);
                w.WriteLine("-------------------------------");
                w.WriteLine(Environment.NewLine);
            }
        }
    }
}
