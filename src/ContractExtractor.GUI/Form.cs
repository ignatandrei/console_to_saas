using ContractExtractor.IO;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContractExtractor.GUI
{
	public partial class frmExtractor : System.Windows.Forms.Form
	{
        private readonly ILogger _logger;
        public frmExtractor()
		{
			InitializeComponent();
            _logger = NLog.LogManager.GetLogger(nameof(WordContractExtractor));
        }

		private void StartButton_Click(object sender, EventArgs e)
		{
            try
            {
                string folder = folderPath.Text;
                if(string.IsNullOrWhiteSpace(folder))
                {
                    MessageBox.Show("please choose a folder");
                    return;
                }

                var fileSystem = new LocalFileSystem(folder);
                var extractor = new WordContractExtractor(fileSystem);
                extractor.Start();
            }
            catch(Exception ex)
            {
                _logger.Error(ex,$"exception in  {nameof(StartButton_Click)}");
                MessageBox.Show("an error occured. See the log file for details");
            }
        }

        private void Form_Load(object sender, EventArgs e)
		{
            var settings = Settings.From("app.json");
            //folderPath.Text = settings.DocumentsLocation;

		}

        private void ChooseFolderbutton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
