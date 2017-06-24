using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Contracts
{
    public interface IProfileSaver
    {
        void SaveProfile(ProfileInformation profileInformation);
    }
}
