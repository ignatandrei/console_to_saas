using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;



namespace ContractExtractor.IO
{
    //read also http://msprogrammer.serviciipeweb.ro/2019/06/03/correct-abstraction-net-core-ifileprovider/

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
