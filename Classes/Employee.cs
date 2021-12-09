using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Inn { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Role { get; set; }


        public override string ToString()
        {
            return Surname;
        }
    }
}
