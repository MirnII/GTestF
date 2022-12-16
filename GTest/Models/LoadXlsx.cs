using ExcelDataReader;
using GTest.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace GTest.Models
{
    internal class LoadXlsx : BaseViewModel
    {
        IExcelDataReader edr;
        public ObservableCollection<Items> loadFile(string directory, string filetype)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(directory, FileMode.Open, FileAccess.Read);
            if (filetype == ".xlsx") edr = ExcelReaderFactory.CreateOpenXmlReader(stream);
            else if (filetype == ".xls") edr = ExcelReaderFactory.CreateBinaryReader(stream);
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            DataSet dataSet = edr.AsDataSet(conf);
            DataTable dt = dataSet.Tables[0];
            ObservableCollection<Items> Item = new ObservableCollection<Items>
            (dt.AsEnumerable().Select(i => new Items
            {
                Name = Convert.ToString(i["Name"]),
                Distance = Convert.ToDouble(i["Distance"]),
                Angle = Convert.ToDouble(i["Angle"]),
                Width = Convert.ToDouble(i["Width"]),
                Height = Convert.ToDouble(i["Height"]),
                IsDefect = Convert.ToString(i["IsDefect"])
            }));
            edr.Close();
            Notify("Item");
            return Item;
        }
    }
}
