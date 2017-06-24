using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using IOImplementation;
using InitializationContracts;

namespace SaveGames
{
    public class SaveGameDataConverter
    {
        public LevelSaveGame ConvertLevel(List<IElement> stateOfAllElements, int levelId, string SkillName)
        {
            LevelSaveGame levelSaveGame = new LevelSaveGame();

            levelSaveGame.LevelId = levelId;
            levelSaveGame.SkillName = SkillName;
            levelSaveGame.AllElements = new List<IElement>();
            levelSaveGame.AllElements.AddRange(stateOfAllElements);

            return levelSaveGame;
        }
    }
}
