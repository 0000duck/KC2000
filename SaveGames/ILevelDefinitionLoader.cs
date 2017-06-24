using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace SaveGames
{
    public interface ILevelDefinitionLoader
    {
        LevelSaveGame LoadLevel(int levelId, SkillLevel skillLevel);
    }
}
