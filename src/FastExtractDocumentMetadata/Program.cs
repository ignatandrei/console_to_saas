using ContractExtractor;
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
			var extractor = new WordContractExtractor(settings.DocumentsLocation);
			extractor.Start();
        }
    }
}
