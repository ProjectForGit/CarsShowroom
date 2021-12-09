using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Repair
    {
        public int RepairId { get; set; }
        public int AccessoryId { get; set; }
        public Accessory Accessory { get; set; }
        public int Cost { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string Problem { get; set; }

        public override string ToString()
        {
            return Problem;
        }

    }
}
