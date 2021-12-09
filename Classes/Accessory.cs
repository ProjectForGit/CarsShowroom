using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Accessory
    {
        public int AccessoryId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Cost { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
