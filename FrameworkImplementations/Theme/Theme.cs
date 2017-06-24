using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using BaseTypes;

namespace FrameworkImplementations.Theme
{
    public class Theme : ITheme
    {
        private Dictionary<Behaviour, IAnimation> Animations { set; get; }

        public Theme(Dictionary<Behaviour, IAnimation> animations)
        {
            Animations = animations;
        }

        public IAnimationImage GetTexture(Behaviour behaviour, Degree degree, double percent)
        {
            return Animations[behaviour].GetImage(percent, degree);
        }
    }
}
