using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Vacation
    {
        private int duration;

        public int IdVacation { get; set; }
        public int Duration
        {
            get => duration; set
            {
                duration = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(duration)));
            }
        }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }
        public int VacationSalary { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
