﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace IOImplementation
{
    public class InitInformation : IInitInformation
    {

        public List<IInitValue> InitValues
        {
            get;
            set;
        }
    }
}