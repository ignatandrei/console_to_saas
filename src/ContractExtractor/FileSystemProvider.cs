using ContractExtractor.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContractExtractor
{
    public class FileSystemProvider
    {
        public FileSystemProvider()
        {
            //FileSystems = new List<Tuple<string, IFileSystem>>();
            //FileSystems.Add(
            //    new Tuple<string, IFileSystem>("local1", new LocalFileSystem("path to folder")));
            //FileSystems.Add(new Tuple<string, IFileSystem>("zip1", new ZipFileSystem("path to zip file")));
            //currentFileSystem = "local1";

        }
        public IList<Tuple<string, IFileSystem>> FileSystems { get; set; }
        public string currentFileSystem { get; set; }
        public IFileSystem ActualFileSystem()
        {
            return FileSystems.FirstOrDefault(it => it.Item1 == currentFileSystem).Item2;
        }

    }
}
