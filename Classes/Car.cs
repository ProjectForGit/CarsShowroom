using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Car
    {
        private string name;
        private int cost;
        private string gearbox;
        private int maxSpeed;
        private int weight;
        private DateTime year;

        public int CarId { get; set; }
        public int MarkId { get; set; }
        public Mark Mark { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int Cost
        {
            get => cost; set
            {
                cost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(cost)));
            }
        }
        public DateTime Year
        {
            get => year; set
            {
                year = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(year)));
            }
        }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public string Gearbox
        {
            get => gearbox; set
            {
                gearbox = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(gearbox)));
            }
        }
        public int MaxSpeed
        {
            get => maxSpeed; set
            {
                maxSpeed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(maxSpeed)));
            }
        }
        public int Weight
        {
            get => weight; set
            {
                weight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(weight)));
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
