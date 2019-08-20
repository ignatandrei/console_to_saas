using ContractExtractor;
using ContractExtractor.IO;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace FastExtractDocumentMetadata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
			var settings = Settings.From("app.json");

            //var fileSystem = new LocalFileSystem(settings.DocumentsLocation);
            var fileSystem = new ZipFileSystem(@"data\Painting-Contract.zip");
            var extractor = new WordContractExtractor(fileSystem);
			extractor.Start();
        }
    }
}
