using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;

namespace FrameworkImplementations.Theme
{
    public class ThemeLoader : IThemeLoader
    {
        private IAnimationLoader AnimationLoader { set; get; }
        private string ThemePath { set; get; }

        public ThemeLoader(IAnimationLoader animationLoader, string themePath)
        {
            AnimationLoader = animationLoader;
            ThemePath = themePath;
        }

        public ITheme LoadTheme(ElementTheme elementTheme)
        {
            Dictionary<Behaviour, IAnimation> animations = new Dictionary<Behaviour,IAnimation>();

            foreach (Behaviour behaviour in Enum.GetValues(typeof(Behaviour)))
            {
                string animationPath = ThemePath + "\\" + elementTheme.ToString() + "\\" + behaviour.ToString();
                IAnimation animation;

                if (AnimationLoader.TryLoadAnimation(animationPath, out animation))
                    animations.Add(behaviour, animation);
            }

            switch (elementTheme)
            {
                case ElementTheme.SoldierPistol:
                case ElementTheme.FlyingShoe:
                case ElementTheme.Dog:
                    return new FloorAnimationThemeDecorator(new Theme(animations));
                default:
                    return new Theme(animations);
            }
        }
    }
}
