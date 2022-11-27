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
    }
}