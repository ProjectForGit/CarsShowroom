using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Award
    {
        private string name;
        private int salaryAdd;

        public int IdAward { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        public int SalaryAdd
        {
            get => salaryAdd; set
            {
                salaryAdd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(salaryAdd)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
