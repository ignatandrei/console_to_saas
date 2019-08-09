using ContractExtractor.IO;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace ContractExtractor
{
	public class WordContractExtractor
	{
		private readonly string _documentLocation;
		private readonly ILogger _logger;
        private readonly IFileSystem _fileSystem;

        public WordContractExtractor(IFileSystem fileSystem)
		{
            _fileSystem = fileSystem;
			_logger = NLog.LogManager.GetLogger(nameof(WordContractExtractor));
		}

		public void Start()
		{
            var files = _fileSystem.ListAsync("*.docx").ToList();
			_logger.Info($"processing {files.Count} word documents");

			var allContractors = new List<object[]>();
			foreach (var file in files)
			{
				_logger.Info($"start processing {file.Name}");
				var document = new XWPFDocument(file.Read());
				if (document.Tables.Count < 2)
					throw new InvalidOperationException("Expected at least 2 tables");

				var contractorDetails = ExactContractorDetails(document.Tables[0]);
				allContractors.Add(contractorDetails);

				_logger.Info($"end processing {file}");
			}

			var wb = new XSSFWorkbook();
			var sheet = wb.CreateSheet("Contractors");
			for (int i = 0; i < allContractors.Count; i++)
			{
				var contractor = allContractors[i];
				IRow row = sheet.CreateRow(i);
				for (int j = 0; j < contractor.Length; j++)
				{
					var cell = row.CreateCell(j);
					cell.SetCellValue(contractor[j].ToString());
				}
			}

			wb.Write(File.OpenWrite("Contractors.xlsx"));
		}

		private static object[] ExactContractorDetails(XWPFTable table)
		{
			var rowItems = new List<object>();

			foreach (XWPFTableRow row in table.Rows)
			{
				List<XWPFTableCell> cells = row.GetTableCells();
				for (int i = 1; i < cells.Count; i += 2)
				{
					rowItems.Add(cells[i].GetText());
				}
			}

			return rowItems.ToArray();
		}
	}
}
