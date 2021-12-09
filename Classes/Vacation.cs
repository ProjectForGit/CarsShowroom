using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Vacation
    {
        public int IdVacation { get; set; }
        public int Duration { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }
        public int VacationSalary { get; set; }
    }
}
