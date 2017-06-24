using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkContracts
{
    public interface IGameStartInitializer
    {
        void SetSkillLevel(SkillLevel skillLevel);

        void SetLevelId(int levelId);

        void Start();
    }
}
