using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Car
    {
        public int CarId { get; set; }
        public int MarkId { get; set; }
        public Mark Mark { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int Cost { get; set; }
        public DateTime Year { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public string Gearbox { get; set; }
        public int MaxSpeed { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
