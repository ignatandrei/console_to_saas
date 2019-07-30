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
			var config = new NLog.Config.LoggingConfiguration();

			var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
			var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

			config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
			config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

			NLog.LogManager.Configuration = config;


			var settings = Settings.From("app.json");
			var extractor = new WordContractExtractor(settings.DocumentsLocation);
			extractor.Start();
        }
    }
}
