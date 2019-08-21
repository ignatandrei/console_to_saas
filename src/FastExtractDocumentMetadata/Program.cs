using ContractExtractor;
using ContractExtractor.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            //var fileSystem = new ZipFileSystem(@"data\Painting-Contract.zip");
            var fileSystem = settings.FileSystemProvider.CurrentFileSystem();
            var extractor = new WordContractExtractor(fileSystem);
            extractor.Start();
        }

        private static void Serialization()
        {
            var indented = Formatting.Indented;
            var settingsJson = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            settingsJson.ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };

            var settings = new FileSystemSettings();
            settings.FileSystems.Add(new FileSystemSettings.Definition("local1", new LocalFileSystem("data")));
            settings.FileSystems.Add(new FileSystemSettings.Definition("zip1", new ZipFileSystem("data/Painting-Contract.zip")));
            settings.CurrentFileSystemKey = "local1";
            var s = JsonConvert.SerializeObject(settings, indented, settingsJson);
            var q = s;
        }
    }
}
