using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaveGames;

namespace LevelEditor
{
    public interface IAutoSaveGameSerializer
    {
        void SaveLevelDataTemporary(LevelSaveGame levelSaveGame);
    }
}
