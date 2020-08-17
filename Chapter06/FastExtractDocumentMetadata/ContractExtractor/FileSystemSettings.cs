using ContractExtractor.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContractExtractor
{
    public class FileSystemSettings
    {
        public FileSystemSettings()
        {
            FileSystems = new List<Definition>();
        }

        public IList<Definition> FileSystems { get; set; }
        public string CurrentFileSystemKey { get; set; }

        public IFileSystem CurrentFileSystem()
        {
            return FileSystems.FirstOrDefault(it => it.Name == CurrentFileSystemKey).FileSystem;
        }

        public class Definition
        {
            public string Name { get; }
            public IFileSystem FileSystem { get; }

            public Definition(string name, IFileSystem fileSystem)
            {
                Name = name;
                FileSystem = fileSystem;
            }
        }
    }
}
