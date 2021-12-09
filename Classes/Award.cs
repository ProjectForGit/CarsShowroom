using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Award
    {
        public int IdAward { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Name { get; set; }
        public int SalaryAdd { get; set; }
    }
}
