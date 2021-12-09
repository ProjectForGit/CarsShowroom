using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int CarId { get; set; }
        public Employee Employee { get; set; }
        public Car Car { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }

    }
}
