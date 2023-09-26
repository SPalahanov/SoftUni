using System.Text;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main()
        {
            //string path = Console.ReadLine();
            string path = @"C:\Users\Lenovo\source\repos\C# Advanced\3.1. Exercise - Sets and Dictionaries Advanced\03. Periodic Table";
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionsFiles = new SortedDictionary<string, List<FileInfo>>();

            string[] fileNames = Directory.GetFiles(inputFolderPath);

            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                
                if (!extensionsFiles.ContainsKey(fileName))
                {
                    extensionsFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }

                extensionsFiles[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var extensionFiles in extensionsFiles.OrderByDescending(x =>x.Value.Count))
            {
                sb.AppendLine(extensionFiles.Key);

                foreach (var file in extensionFiles.Value.OrderBy(x =>x.Length))
                {
                    sb.AppendLine($"-{file.Name} - {(double)file.Length / 1024:f3}KB");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + reportFileName;
            
            File.WriteAllText(filePath, textContent);
        }
    }
}