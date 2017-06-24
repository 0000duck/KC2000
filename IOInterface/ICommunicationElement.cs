using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface ICommunicationElement
    {
        void ChangePosition(double x, double y, double z);
        void RenderAnimation(Behaviour behaviour, double percent, Degree degree = Degree.Degree_0, bool isMarked = false);
    }
}
