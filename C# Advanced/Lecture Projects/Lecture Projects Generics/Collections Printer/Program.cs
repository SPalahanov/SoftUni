namespace Collections_Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Streams<StreamReader> streams = new Streams<StreamReader>();
            Streams<StreamWriter> streams2 = new Streams<StreamWriter>();

            streams.OpenStream(new StreamReader(""));
        }
    }

    class Streams<T> where T : IDisposable
    {
        public void OpenStream(T stream)
        {
            stream.Dispose();
            using (stream)
            {
                
            }
        }
    }
}