using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextureConverter.Contracts
{
    public interface IReplacementColorProvider
    {
        List<IReplacementColor> GetListC64(Scenario scenario);
    }
}
