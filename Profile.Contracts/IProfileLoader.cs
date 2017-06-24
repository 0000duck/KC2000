using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Contracts
{
    public interface IProfileLoader
    {
        ProfileInformation LoadProfile();
    }
}
