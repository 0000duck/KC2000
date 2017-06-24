using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOInterface
{

    public interface IInitValue
    {
        int Identifier { set; get; }

        string Value { set; get; }

        int ValueAsInt { get; }

        double ValueAsDouble { get; }
    }

    public interface IInitInformation
    {
        List<IInitValue> InitValues { set; get; }
    }
}
