namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int lastSeparatorIndex = filePath.LastIndexOf('\\');

            string newString = filePath.Remove(0, lastSeparatorIndex + 1);

            string[] filteredFilePath = newString.Split(".");

            string fileName = filteredFilePath[0];
            string extension = filteredFilePath[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}