using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Models
{
    public class Sensor
    {
        public string Name { get; set; }

        public Sensor(string name)
        {
            Name = name;
        }

        public bool Activate(string weakness)
        {
            return Name == weakness;
        }
    }

}
