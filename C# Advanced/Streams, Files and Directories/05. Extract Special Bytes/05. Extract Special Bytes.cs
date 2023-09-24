using System.Text;

namespace ExtractSpecialBytes
{
    using System;
    using System.IO;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] bytes = File.ReadAllBytes(bytesFilePath);

            byte[] binaryData = File.ReadAllBytes(binaryFilePath);
            
            using (MemoryStream outputStream = new MemoryStream())
            {
                for (int i = 0; i < binaryData.Length; i++)
                {
                    if (Array.IndexOf(bytes, binaryData[i]) != -1)
                    {
                        outputStream.WriteByte(binaryData[i]);
                    }
                }
                
                File.WriteAllBytes(outputPath, outputStream.ToArray());
            }
        }
    }
}
