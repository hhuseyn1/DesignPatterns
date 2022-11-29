using System.Windows.Forms;

namespace Composite_Pattern
{
    public partial class Form1 : Form
    {
        public string Filename { get; set; }
        public string Foldername { get; set; }
        public float Filesize { get; set; }
        public float Foldersize { get; set; }
        public Form1()
        {
            InitializeComponent();
        }


        private void SelectFile_Folderbtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Name == "SelectFilebtn")
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Filesize = new FileInfo(openFileDialog.FileName).Length;
                        Filename = new FileInfo(openFileDialog.FileName).FullName;
                        Refresh();

                    }
                }
                else if (btn.Name == "SelectFolderbtn")
                {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Foldername = new FileInfo(dialog.SelectedPath).FullName;
                        Foldersize = GetDirectorySize(dialog.SelectedPath);
                        RefreshFolder();
                    }
                }
            }
        }

        static float GetDirectorySize(string p)
        {
            string[] a = Directory.GetFiles(p, "*.*");

            float b = 0;
            foreach (string name in a)
            {
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            return b;
        }


        public void Refresh()
        {
            FileNamelbl.Text = Filename;
            SelectedFileSize.Text = Filesize.ToString();
        }

        public void RefreshFolder()
        {
            FolderNamelbl.Text = Foldername;
            SelectedFolderSize.Text = Foldersize.ToString();
        }

        private Label SelectedFolderSize;
        private Label SelectedFileSize;
        private Label FolderNamelbl;
        private Button SelectFolderbtn;
        private Button SelectFilebtn;
        private Label FileNamelbl;

        private void InitializeComponent()
        {
            this.SelectedFolderSize = new System.Windows.Forms.Label();
            this.SelectedFileSize = new System.Windows.Forms.Label();
            this.FolderNamelbl = new System.Windows.Forms.Label();
            this.SelectFolderbtn = new System.Windows.Forms.Button();
            this.SelectFilebtn = new System.Windows.Forms.Button();
            this.FileNamelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectedFolderSize
            // 
            this.SelectedFolderSize.AutoSize = true;
            this.SelectedFolderSize.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.SelectedFolderSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SelectedFolderSize.Location = new System.Drawing.Point(444, 131);
            this.SelectedFolderSize.Name = "SelectedFolderSize";
            this.SelectedFolderSize.Size = new System.Drawing.Size(105, 17);
            this.SelectedFolderSize.TabIndex = 11;
            this.SelectedFolderSize.Text = "No selected folder";
            // 
            // SelectedFileSize
            // 
            this.SelectedFileSize.AutoSize = true;
            this.SelectedFileSize.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.SelectedFileSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SelectedFileSize.Location = new System.Drawing.Point(159, 131);
            this.SelectedFileSize.Name = "SelectedFileSize";
            this.SelectedFileSize.Size = new System.Drawing.Size(90, 17);
            this.SelectedFileSize.TabIndex = 10;
            this.SelectedFileSize.Text = "No selected file";
            // 
            // FolderNamelbl
            // 
            this.FolderNamelbl.AutoSize = true;
            this.FolderNamelbl.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.FolderNamelbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FolderNamelbl.ForeColor = System.Drawing.Color.White;
            this.FolderNamelbl.Location = new System.Drawing.Point(444, 53);
            this.FolderNamelbl.Name = "FolderNamelbl";
            this.FolderNamelbl.Size = new System.Drawing.Size(105, 17);
            this.FolderNamelbl.TabIndex = 9;
            this.FolderNamelbl.Text = "No selected folder";
            // 
            // SelectFolderbtn
            // 
            this.SelectFolderbtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.SelectFolderbtn.Location = new System.Drawing.Point(444, 90);
            this.SelectFolderbtn.Name = "SelectFolderbtn";
            this.SelectFolderbtn.Size = new System.Drawing.Size(90, 23);
            this.SelectFolderbtn.TabIndex = 8;
            this.SelectFolderbtn.Text = "Select Folder";
            this.SelectFolderbtn.UseVisualStyleBackColor = true;
            // 
            // SelectFilebtn
            // 
            this.SelectFilebtn.BackColor = System.Drawing.SystemColors.Control;
            this.SelectFilebtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.SelectFilebtn.Location = new System.Drawing.Point(159, 90);
            this.SelectFilebtn.Name = "SelectFilebtn";
            this.SelectFilebtn.Size = new System.Drawing.Size(75, 23);
            this.SelectFilebtn.TabIndex = 7;
            this.SelectFilebtn.Text = "Select File";
            this.SelectFilebtn.UseVisualStyleBackColor = false;
            // 
            // FileNamelbl
            // 
            this.FileNamelbl.AutoSize = true;
            this.FileNamelbl.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.FileNamelbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FileNamelbl.Location = new System.Drawing.Point(159, 53);
            this.FileNamelbl.Name = "FileNamelbl";
            this.FileNamelbl.Size = new System.Drawing.Size(90, 17);
            this.FileNamelbl.TabIndex = 6;
            this.FileNamelbl.Text = "No selected file";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(781, 224);
            this.Controls.Add(this.SelectedFolderSize);
            this.Controls.Add(this.SelectedFileSize);
            this.Controls.Add(this.FolderNamelbl);
            this.Controls.Add(this.SelectFolderbtn);
            this.Controls.Add(this.SelectFilebtn);
            this.Controls.Add(this.FileNamelbl);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}