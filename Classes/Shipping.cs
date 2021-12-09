using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Shipping
    {
        public int IdShipping { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public Accessory Accessory { get; set; }
        public int AccessoryId { get; set; }
    }
}
