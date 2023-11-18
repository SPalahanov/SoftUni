using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.Core.Exceptions;
using Log.ForU.Core.IO.Interfaces;

namespace Log.ForU.Core.IO
{
    public class LogFile : ILogFile
    {
        private const string DefaultExtension = "txt";
        private static readonly string DefaultName = $"Log_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}";
        private static readonly string DefaultPath = $"{Directory.GetCurrentDirectory()}";
        
        private string name;
        private string path;
        private string extension;

        public LogFile()
        {
            Name = DefaultName;
            Extension = DefaultExtension;
            Path = DefaultPath;
        }

        public LogFile(string name, string extension, string path) : this()
        {
            Name = name;
            Extension = extension;
            Path = path;
        }
        
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileNameExtension();
                }

                name = value;
            }

        }

        public string Extension
        {
            get => extension;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileExtensionException();
                }

                extension = value;
            }
        }

        public string Path
        {
            get => path;
            set
            {
                if (!Directory.Exists(value))
                {
                    throw new InvalidPathException();
                }

                path = value;
            }
        }

        public string FullPath => System.IO.Path.GetFullPath($"{Path}/{Name}.{Extension}");

        public int Size => File.ReadAllText(FullPath).Length;
    }
}
