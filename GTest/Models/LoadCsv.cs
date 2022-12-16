using GTest.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace GTest.Models
{
    internal class LoadCsv : BaseViewModel
    {
        public ObservableCollection<Items> loadFile(string directory)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(directory, Encoding.Default))
            {
                string[] headers = sr.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++) dr[i] = rows[i];
                    dt.Rows.Add(dr);
                }
            }
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
            Notify("Item");
            return Item;
        }

    }
}
