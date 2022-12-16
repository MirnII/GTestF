using GTest.Models;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace GTest.ViewModels
{
    public class Context : BaseViewModel
    {
        readonly ChooseFile choose = new ();
        readonly LoadXlsx load = new ();
        readonly LoadCsv loadC = new ();
        readonly Items item = new ();
        public Context()
        {
            choose.PropertyChanged += (s, e) => { Notify(e.PropertyName); };
            chooseFile = new DelegateCommand<string>(str => { choose.SelectFile(); });
            load.PropertyChanged += (s, e) => { Notify(e.PropertyName); };
            loadC.PropertyChanged += (s, e) => { Notify(e.PropertyName); };
            item.PropertyChanged += (s, e) => { Notify(e.PropertyName); };
            loadFile = new DelegateCommand<string>(str =>
            {
                if (fileType != ".csv") Item = load.loadFile(fileDirectory, fileType);
                else Item = loadC.loadFile(fileDirectory);
            });
        }
        public string fileDirectory => choose.fileDirectory;
        public string fileType => choose.fileType;
        public ObservableCollection<Items> Item { get; set; }
        public string fileName => "Tools: " + choose.fileName + "   " + choose.fileType;
        public DelegateCommand<string> loadFile { get; }
        public DelegateCommand<string> chooseFile { get; }
    }
}
