using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class SkillLevelRepository : ISkillLevelSetter, ISkillLevelProvider
    {
        private SkillLevel _skillLevel;

        SkillLevel ISkillLevelProvider.GetSkillLevel()
        {
            return _skillLevel;
        }

        void ISkillLevelSetter.SetSkillLevel(SkillLevel skillLevel)
        {
            _skillLevel = skillLevel;
        }
    }
}
