using System;
using System.IO;

namespace FastExtractDocumentMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the folder with financial Word documents");
            string folderWithWordDocs = Console.ReadLine();
            var files = Directory.GetFiles(folderWithWordDocs, "*.docx");
            Console.WriteLine($"processing {files?.Length} word documents");
            foreach (var file in files)
            {
                Console.WriteLine($"start processing {file}");
                //TODO: find metadata in files
                Console.WriteLine($"end processing {file}");

            }
        }
    }
}
