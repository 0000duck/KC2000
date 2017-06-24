using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public interface IImpulseConverter
    {
        IList<Impulse> ConvertDegreeToImplse(Degree movement, double weight, double speed);
        IList<Impulse> ConvertVectorToImplse(Vector2D vector, double weight, double speed);
    }
}
