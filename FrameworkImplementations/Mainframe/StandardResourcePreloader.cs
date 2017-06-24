using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class StandardResourcePreloader : IExecuteble
    {
        private IAnimationLoader _animationLoader;
        private IThemeLoader _themeLoader;
        private string _animationPath;

        public StandardResourcePreloader(IAnimationLoader animationLoader, string animationPath, IThemeLoader themeLoader)
        {
            _animationLoader = animationLoader;
            _themeLoader = themeLoader;
            _animationPath = animationPath;
        }

        void IExecuteble.ExecuteLogic()
        {
            List<IOInterface.Animation> necessaryAnimations = new List<IOInterface.Animation>
            {
                IOInterface.Animation.Dust,
                IOInterface.Animation.FistDust,
                IOInterface.Animation.Smoke,
                IOInterface.Animation.Explosion,
                IOInterface.Animation.ExplosionSmall,
                IOInterface.Animation.VerySmallBodyExplosion,
                IOInterface.Animation.SmallBodyExplosion,
                IOInterface.Animation.MediumBodyExplosion,
                IOInterface.Animation.BigBodyExplosion,
                IOInterface.Animation.WoodExplosionSmall,
                IOInterface.Animation.WoodExplosionBig,
                IOInterface.Animation.GunFire,
                IOInterface.Animation.EnemyGunFire,
                IOInterface.Animation.BloodVerySmall1,
                IOInterface.Animation.SmallBloodLowDensity,
                IOInterface.Animation.Glass,
                IOInterface.Animation.WaterParticle,
                IOInterface.Animation.BloodSmall1,
                IOInterface.Animation.BloodVerySmall2,
                IOInterface.Animation.BloodVerySmall3,
                IOInterface.Animation.BloodSmall4,
                IOInterface.Animation.BloodSmall5,
                IOInterface.Animation.BloodMedium1,
                IOInterface.Animation.BloodMediumLD1,
                IOInterface.Animation.BloodMediumLD2,
                IOInterface.Animation.BloodMediumLD3,
                IOInterface.Animation.BloodMediumLD4,
                IOInterface.Animation.BloodSmall2,
                IOInterface.Animation.BloodSmall3,
                IOInterface.Animation.BloodSmall6
            };
            foreach (IOInterface.Animation animation in necessaryAnimations)
            {
                _animationLoader.LoadAnimation(_animationPath + "\\" + animation);
            }

            _themeLoader.LoadTheme(IOInterface.ElementTheme.BloodTorso);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.BloodyPart);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.FlyingBloodMedium);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.FlyingBloodSmall);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.StraightFlyingBloodSmall);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.StraightFlyingBloodVerySmall);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.FlyingShoe);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.Skull);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.GiantSkull);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.GiantTorso);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.DogBloodTorso);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.Bowls);
            _themeLoader.LoadTheme(IOInterface.ElementTheme.DogBloodTorso);
        }
    }
}
