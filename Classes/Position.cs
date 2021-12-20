using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public class Position : INotifyPropertyChanged
    {
        private string name;
        private int salary;

        public int PositionId { get; set; }

        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        public int Salary
        {
            get => salary; set
            {
                salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(salary)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return Name;
        }
    }
}
