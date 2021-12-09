using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Maintenance
    {
        public int IdMaintenance { get; set; }
        public int TypeMaintenanceId { get; set; }
        public TypeMaintenance TypeMaintenance { get; set; }
        public int RepairId { get; set; }
        public Repair Repair { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
