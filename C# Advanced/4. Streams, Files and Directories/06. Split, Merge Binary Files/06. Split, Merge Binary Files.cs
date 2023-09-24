namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] binaryData = File.ReadAllBytes(sourceFilePath);

            int fileSize = binaryData.Length;
            int partOneSize = fileSize / 2;
            int partTwoSize = fileSize - partOneSize;

            using (FileStream partOneStream = new FileStream(partOneFilePath, FileMode.Create))
            {
                partOneStream.Write(binaryData, 0, partOneSize);
            }

            using (FileStream partTwoStream = new FileStream(partTwoFilePath, FileMode.Create))
            {
                partTwoStream.Write(binaryData, partOneSize, partTwoSize);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] partOneData = File.ReadAllBytes(partOneFilePath);

            byte[] partTwoData = File.ReadAllBytes(partTwoFilePath);

            byte[] mergedData = new byte[partOneData.Length + partTwoData.Length];

            Buffer.BlockCopy(partOneData, 0, mergedData, 0, partOneData.Length);

            Buffer.BlockCopy(partTwoData, 0, mergedData, partOneData.Length, partTwoData.Length);

            File.WriteAllBytes(joinedFilePath, mergedData);
        }
    }
}