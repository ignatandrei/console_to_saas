using ContractExtractor;
using ContractExtractor.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace FastExtractorTest
{
    [TestClass]
    public class TestLocalFolder
    {
        [TestMethod]
        public void TestGenerateFromDocx()
        {
            #region arrange
            string nameFile = "Contractors.xlsx";
            //cleanup - delete any files that may be left from the previous run
            var dataFolder = new DirectoryInfo(".");
            foreach (var file in dataFolder.GetFiles(nameFile))
            {
                file.Delete();
            }
            //start the filesystem to see where the files is
            IFileSystem fileSystem = new LocalFileSystem("data");

            #endregion

            #region act
            var extractor = new WordContractExtractor(fileSystem);
            extractor.Start();
            #endregion

            #region assert
            var files = dataFolder.GetFiles(nameFile);
            Assert.AreEqual(1, files.Count(), " should genereate the excel file");
            #endregion

        }
    }
}
