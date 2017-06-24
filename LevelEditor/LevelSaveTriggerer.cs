using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElementImplementations.ActivationManagerImplementations;
using InitializationContracts;
using IOInterface;
using SaveGames;
using FrameworkContracts;

namespace LevelEditor
{
    public class LevelSaveTriggerer : ISaveGameObserver
    {
        private ILevelStateGrabber LevelStateGrabber { set; get; }

        private int LevelID { set; get; }

        private IAutoSaveGameSerializer AutoSaveGameSerializer { set; get; }
        private SkillLevel _skillLevel;

        public LevelSaveTriggerer(ILevelStateGrabber levelStateGrabber,
            IAutoSaveGameSerializer autoSaveGameSerializer,
            int levelId, SkillLevel skillLevel)
        {
            LevelStateGrabber = levelStateGrabber;
            LevelID = levelId;
            AutoSaveGameSerializer = autoSaveGameSerializer;
            _skillLevel = skillLevel;
        }

        public void GameContentIsSaved()
        {
            List<IElement> stateOfAllElements = LevelStateGrabber.GetStateOfAllElements();

            SaveGameDataConverter saveGameDataConverter = new SaveGameDataConverter();

            AutoSaveGameSerializer.SaveLevelDataTemporary(saveGameDataConverter.ConvertLevel(stateOfAllElements, LevelID, _skillLevel.ToString()));
        }
    }
}
