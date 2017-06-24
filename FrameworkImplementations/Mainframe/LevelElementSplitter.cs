using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;

namespace FrameworkImplementations.Mainframe
{
    public class LevelElementSplitter : ILevelElementSplitter
    {
        private List<ElementTheme> _skillDependentThemes;

        public LevelElementSplitter(List<ElementTheme> skillDependentThemes)
        {
            _skillDependentThemes = skillDependentThemes;
        }

        List<IOInterface.IElement> ILevelElementSplitter.GetGeometry(List<IOInterface.IElement> allElements)
        {
            return allElements.Where(x => !_skillDependentThemes.Contains(x.ElementTheme)).ToList();
        }

        List<IOInterface.IElement> ILevelElementSplitter.GetSkillDependentElements(List<IOInterface.IElement> allElements)
        {
            return allElements.Where(x => _skillDependentThemes.Contains(x.ElementTheme)).ToList();
        }
    }
}
