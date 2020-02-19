using ContractExtractor;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
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
            Console.WriteLine("please enter the folder with financial Word documents( press enter for current folder)");
            string folderWithWordDocs = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(folderWithWordDocs))
            {
                folderWithWordDocs = ".";

            }
            string excelResultsFile = "Contractors.xlsx";
            var wordExtractor = new WordContractExtractor(folderWithWordDocs);
            wordExtractor.ExtractToFile(excelResultsFile);
            Console.WriteLine("please see Contractors.xlsx");
        }
    }
}


