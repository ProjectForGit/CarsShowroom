using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Color : INotifyPropertyChanged
    {
        private string name;
        private string code;

        public int ColorId { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        public string Code
        {
            get => code; set
            {
                code = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(code)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name;
        }
    }
}
