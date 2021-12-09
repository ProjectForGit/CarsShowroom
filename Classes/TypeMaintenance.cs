using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class TypeMaintenance : INotifyPropertyChanged
    {
        private string name;
        private int cost;
        private int duration;

        public int TypeMaintenanceId { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        public int Cost
        {
            get => cost; set
            {
                cost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(cost)));
            }
        }
        public int Duration
        {
            get => duration; set
            {
                duration = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(duration)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name;
        }
    }
}
