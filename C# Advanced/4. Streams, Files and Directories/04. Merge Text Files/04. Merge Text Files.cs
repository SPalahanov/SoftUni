namespace MergeFiles
{
    using System;
    using System.IO;
    using System.Reflection.PortableExecutable;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> inputs = new List<string>();

            using (StreamReader firstReader = new StreamReader(firstInputFilePath))
            using (StreamReader secondReader = new StreamReader(secondInputFilePath))
            {
                while (firstReader.EndOfStream == false)
                {
                    string firstInput = firstReader.ReadLine();
                    inputs.Add(firstInput);
                }

                while (secondReader.EndOfStream == false)
                {
                    string secondInput = secondReader.ReadLine();
                    inputs.Add(secondInput);
                }
                
                inputs.Sort();
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var input in inputs)
                {
                    writer.WriteLine(input);
                }
            }
        }
    }
}
