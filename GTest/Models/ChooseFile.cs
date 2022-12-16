using GTest.ViewModels;
using Microsoft.Win32;
using System.Windows;

namespace GTest.Models
{
    internal class ChooseFile : BaseViewModel
    {
        public string fileName;
        public string fileDirectory;
        public string fileType;
        public void SelectFile()
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "(*.xls)|*.xls|(*.xlsx)|*.xlsx|(*.csv) |*.csv";
                if (fileDialog.ShowDialog() != null)
                {
                    fileDirectory = fileDialog.FileName.ToString();
                    fileName = fileDialog.SafeFileName.ToString();
                    fileType = fileDialog.SafeFileName.Substring(fileDialog.SafeFileName.LastIndexOf("."), fileDialog.SafeFileName.Length - fileDialog.SafeFileName.LastIndexOf("."));
                    Notify("fileDirectory");
                    Notify("fileName");
                    Notify("fileType");
                }
            }
            catch
            {
                MessageBox.Show("Файл не выбран");
            }
        }
    }
}
