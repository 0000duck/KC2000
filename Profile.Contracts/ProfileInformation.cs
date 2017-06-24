using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace Profile.Contracts
{
    public class ProfileInformation
    {
        public int? NextLevel { set; get; }

        public SkillLevel SkillLevel { set; get; }
    }
}
