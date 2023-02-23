using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menuOld
{
    internal class Car
    {
        string model;
        string color;
        string year;
        List<Owner> owners;

        public Car(string model, string color, string year, List<Owner> owners)
        {
            this.model = model; 
            this.color = color;
            this.year = year;
            this.owners = owners;
        }

        public string Model { get { return model; } }
        public string Color { get { return color; } }
        public int Year { get { return Int32.Parse(year); } }
        public int OwnersLen { get { return owners.ToArray().Length; } }
    }
}