using StreamProgress.Models.Interfaces;

namespace StreamProgress
{
    public class StreamProgressInfo
    {
        //private File file;

        private IStreamType streamType;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamType streamType)
        {
            this.streamType = streamType;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamType.BytesSent * 100) / this.streamType.Length;
        }
    }
}
