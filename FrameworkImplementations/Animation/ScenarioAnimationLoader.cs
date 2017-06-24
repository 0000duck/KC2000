using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Animation
{
    public class ScenarioAnimationLoader : IAnimationLoader
    {
        private IAnimationLoader _animationLoader;
        private IScenarioProvider _scenarioProvider;
        private List<string> _soldierNames;
        private ILevelIdProvider _levelIdProvider;

        public ScenarioAnimationLoader(IAnimationLoader animationLoader, IScenarioProvider scenarioProvider, List<string> soldierNames, ILevelIdProvider levelIdProvider)
        {
            _animationLoader = animationLoader;
            _scenarioProvider = scenarioProvider;
            _soldierNames = soldierNames;
            _levelIdProvider = levelIdProvider;
        }

        IAnimation IAnimationLoader.LoadAnimation(string folderName)
        {
            string scenarioPath = ReplacePathWithScenario(folderName);
            return _animationLoader.LoadAnimation(scenarioPath);
        }

        bool IAnimationLoader.TryLoadAnimation(string animationPath, out IAnimation animation)
        {
            string scenarioPath = ReplacePathWithScenario(animationPath);
            return _animationLoader.TryLoadAnimation(scenarioPath, out animation);
        }

        private string ReplacePathWithScenario(string folderName)
        {
            foreach (string soldierName in _soldierNames)
            {
                if (!folderName.Contains(soldierName))
                    continue;

                Scenario scenario = _scenarioProvider.GetScenario(_levelIdProvider.GetLevelId());
                return folderName.Replace(soldierName, "Scenarios\\" + scenario.ToString() + "\\" + soldierName);
            }

            return folderName;
        }
    }
}
