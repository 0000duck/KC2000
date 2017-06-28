using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;

namespace FrameworkImplementations
{
    public class StrategyRemover : IThemeLoader
    {
        private IThemeLoader _themeLoader;

        public StrategyRemover(IThemeLoader themeLoader)
        {
            _themeLoader = themeLoader;
        }

        ITheme IThemeLoader.LoadTheme(ElementTheme theme)
        {
            switch(theme)
            {
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.SoldierPistolF:
                    return _themeLoader.LoadTheme(ElementTheme.SoldierPistol);
            }

            return _themeLoader.LoadTheme(theme);
        }
    }
}
