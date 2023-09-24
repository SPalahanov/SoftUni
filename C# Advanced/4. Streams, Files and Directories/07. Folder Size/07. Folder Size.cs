using System.Net.Security;

namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long size = CalculateFolderSize(folderPath, 0);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine($"{size / 1024.0} KB");
            }
        }

        public static long CalculateFolderSize(string folderPath,  int level)
        {
            string[] files = Directory.GetFiles(folderPath);

            long bytes = 0;

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);

                bytes += info.Length;
            }

            string[] directories = Directory.GetDirectories(folderPath);

            foreach (var directoryPath in directories)
            {
                bytes += CalculateFolderSize(directoryPath, level + 1);
            }

            return bytes;
        }
    }
}
