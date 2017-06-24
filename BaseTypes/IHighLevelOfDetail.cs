using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public interface IHighLevelOfDetail
    {
        IList<IWorldElement> GetHigherDetails();
    }
}
