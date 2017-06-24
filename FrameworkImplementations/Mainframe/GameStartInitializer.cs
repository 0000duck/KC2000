using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Profile.Contracts;

namespace FrameworkImplementations.Mainframe
{
    public class GameStartInitializer : IGameStartInitializer
    {
        private SkillLevel _skillLevel;
        private int _levelId;
        private Action _startGame;
        private ILevelIdSwitcher _levelIdSwitcher;
        private ISkillLevelSetter _skillLevelSetter;

        public GameStartInitializer(Action startGame, ILevelIdSwitcher levelIdSwitcher, ISkillLevelSetter skillLevelSetter)
        {
            _startGame = startGame;
            _levelIdSwitcher = levelIdSwitcher;
            _skillLevelSetter = skillLevelSetter;
        }

        void IGameStartInitializer.SetSkillLevel(SkillLevel skillLevel)
        {
            _skillLevel = skillLevel;
        }

        void IGameStartInitializer.SetLevelId(int levelId)
        {
            _levelId = levelId;
        }

        void IGameStartInitializer.Start()
        {
            _levelIdSwitcher.SetSpecificLevel(_levelId);
            _skillLevelSetter.SetSkillLevel(_skillLevel);
            _startGame();
        }
    }
}
