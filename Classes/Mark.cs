using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public class Mark : INotifyPropertyChanged
    {
        public string name;

        public int MarkId { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name;
        }
    }
}
