using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ContractExtractor.IO
{
    public class ZipFileSystem : IFileSystem
    {
        private readonly string pathZipFile;

        public ZipFileSystem(string pathZipFile)
        {
            this.pathZipFile = pathZipFile;
        }
        public IEnumerable<IFile> ListAsync(string pattern)
        {
            var tmpFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            ZipFile.ExtractToDirectory(pathZipFile, tmpFolder);
            LocalFileSystem lfs = new LocalFileSystem(tmpFolder);
            return lfs.ListAsync(pattern);
        }
    }

}
