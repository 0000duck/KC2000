using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace IOImplementation
{
    public class InitValue : IInitValue
    {

        public int Identifier
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public int ValueAsInt
        {
            get 
            {
                int value = 0;
                if (int.TryParse(Value, out value))
                    return value;
                return 0;
            }
        }

        public double ValueAsDouble
        {
            get 
            {
                double value = 0;
                if (double.TryParse(Value, out value))
                    return value;
                return 0.0;
            }
        }
    }
}
