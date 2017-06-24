using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace FrameworkContracts
{
    public interface ILevelElementSplitter
    {
        List<IElement> GetGeometry(List<IElement> allElements);

        List<IElement> GetSkillDependentElements(List<IElement> allElements);
    }
}
