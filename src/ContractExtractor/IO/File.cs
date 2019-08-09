using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ContractExtractor.IO
{
    public interface IFile
    {
        string Name { get; }
        Stream Read();
    }

    public interface IFileSystem
    {
        IEnumerable<IFile> ListAsync(string pattern);
    }
}
