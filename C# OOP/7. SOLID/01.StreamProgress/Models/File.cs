using StreamProgress.Models.Interfaces;

namespace StreamProgress.Models
{
    public class File : IStreamType
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }

        public override string ToString()
        {
            return $"File name: {this.name}, Length: {Length}, BytesSent: {BytesSent}";
        }
    }
}