using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Shipping
    {
        private string name;
        private DateTime orderDate;
        private DateTime shipDate;

        public int IdShipping { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        public DateTime OrderDate
        {
            get => orderDate; set
            {
                orderDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(orderDate)));
            }
        }
        public DateTime ShipDate
        {
            get => shipDate; set
            {
                shipDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(shipDate)));
            }
        }
        public Accessory Accessory { get; set; }
        public int AccessoryId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
