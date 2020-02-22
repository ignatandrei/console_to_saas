

using ContractExtractor;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace FastExtractDocumentMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings= Settings.From("app.json");
            string folderWithWordDocs = settings.DocumentsLocation;
            
            string excelResultsFile = "Contractors.xlsx";
            var wordExtractor = new WordContractExtractor(folderWithWordDocs);
            wordExtractor.ExtractToFile(excelResultsFile);
            Console.WriteLine("please see Contractors.xlsx");
        }
    }
}


