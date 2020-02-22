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
        
        public frmExtractor()
        {
            InitializeComponent();            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                string folderWithWordDocs = folderPath.Text;
                if (string.IsNullOrWhiteSpace(folderWithWordDocs))
                {
                    MessageBox.Show("please choose a folder");
                    return;
                }
                
                MessageBox.Show("exercise for the reader. See the console FastExtractDocumentMetadata");
                
            }
            catch (Exception ex)
            {                
                MessageBox.Show($"an error occured{ ex.Message}");
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //var settings = Settings.From("app.json");
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
