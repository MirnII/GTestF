using GTest.ViewModels;

namespace GTest.Models
{
    public class Items : BaseViewModel
    {

        public string Name { get; set; }
        public double Distance { get; set; }
        public double Angle { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string IsDefect { get; set; }


    }
}
