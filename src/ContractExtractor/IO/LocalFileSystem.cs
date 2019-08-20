using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ContractExtractor.IO
{
    public class LocalFileSystem : IFileSystem
    {
        public string path { get; private set; }

        public LocalFileSystem(string path)
        {
            this.path = path;
        }


        public IEnumerable<IFile> ListAsync(string pattern)
        {
            var list = new List<IFile>();
            foreach (var file in Directory.GetFiles(path, pattern))
            {
                list.Add(new LocalFile(new FileInfo(file)));
            }

            return list;
        }
    }

    public class LocalFile : IFile
    {
        private readonly FileInfo fileInfo;

        public string Name => fileInfo.Name;

        public LocalFile(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }

        public Stream Read()
        {
            return File.OpenRead(fileInfo.FullName);
        }
    }
}
