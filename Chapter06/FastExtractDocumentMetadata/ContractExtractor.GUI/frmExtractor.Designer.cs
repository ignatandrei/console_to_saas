namespace ContractExtractor.GUI
{
    partial class frmExtractor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.chooseFolderbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(353, 144);
            this.startButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 44);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folder location";
            // 
            // folderPath
            // 
            this.folderPath.Location = new System.Drawing.Point(24, 67);
            this.folderPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.folderPath.Name = "folderPath";
            this.folderPath.ReadOnly = true;
            this.folderPath.Size = new System.Drawing.Size(432, 31);
            this.folderPath.TabIndex = 2;
            // 
            // chooseFolderbutton
            // 
            this.chooseFolderbutton.Location = new System.Drawing.Point(465, 67);
            this.chooseFolderbutton.Name = "chooseFolderbutton";
            this.chooseFolderbutton.Size = new System.Drawing.Size(38, 31);
            this.chooseFolderbutton.TabIndex = 3;
            this.chooseFolderbutton.Text = "...";
            this.chooseFolderbutton.UseVisualStyleBackColor = true;
            this.chooseFolderbutton.Click += new System.EventHandler(this.ChooseFolderbutton_Click);
            // 
            // frmExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 216);
            this.Controls.Add(this.chooseFolderbutton);
            this.Controls.Add(this.folderPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExtractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extractor";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox folderPath;
        private System.Windows.Forms.Button chooseFolderbutton;
    }
}

