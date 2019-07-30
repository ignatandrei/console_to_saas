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
	public partial class Form : System.Windows.Forms.Form
	{
		public Form()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
			}
		}

		private void Form_Load(object sender, EventArgs e)
		{
			// TODO: This is not tested
			//var extractor = new WordContractExtractor(settings.DocumentsLocation);
			//extractor.Start();

		}
	}
}
