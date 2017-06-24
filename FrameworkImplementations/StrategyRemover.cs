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
                case ElementTheme.SoldierShotGun:
                case ElementTheme.SoldierShotGunF:
                case ElementTheme.SoldierShotGunR:
                    return _themeLoader.LoadTheme(ElementTheme.SoldierShotGun);
                case ElementTheme.SoldierRocket:
                case ElementTheme.SoldierRocketR:
                case ElementTheme.SoldierRocketF:
                    return _themeLoader.LoadTheme(ElementTheme.SoldierRocket);
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.SoldierPistolF:
                    return _themeLoader.LoadTheme(ElementTheme.SoldierPistol);
                case ElementTheme.SoldierMG:
                    return _themeLoader.LoadTheme(ElementTheme.SoldierMG);
                case ElementTheme.DogF:
                    return _themeLoader.LoadTheme(ElementTheme.Dog);
                case ElementTheme.HelicopterMGOnlyB:
                    return _themeLoader.LoadTheme(ElementTheme.Helicopter);
            }

            return _themeLoader.LoadTheme(theme);
        }
    }
}
