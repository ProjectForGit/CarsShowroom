using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Order
    {
        private DateTime date;

        public int IdOrder { get; set; }
        public int CarId { get; set; }
        public Employee Employee { get; set; }
        public Car Car { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date
        {
            get => date; set
            {
                date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(date)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
