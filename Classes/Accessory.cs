using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Accessory
    {
        private string name;
        private int valueChange;
        private int cost;

        public int AccessoryId { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        public int Value
        {
            get => valueChange; set
            {
                valueChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(valueChange)));
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
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
