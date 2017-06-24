using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Render.Contracts;

namespace FrameworkImplementations.Animation
{
    public class Animation : IAnimation
    {
        private List<ITexture> Textures { set; get; }

        public Animation(List<ITexture> textures)
        {
            if (textures.Count == 0)
                throw new ArgumentException("empty texture list!");
            Textures = textures;
        }

        public IAnimationImage GetImage(double percentageOfAnimation, Degree degree = Degree.Degree_0)
        {
            double percentageStep = 1.0 / (double)Textures.Count;

            double addedStep = percentageStep;
            int index = 0;

            while (addedStep <= 1.0)
            {
                if (percentageOfAnimation < addedStep)
                    return new AnimationImage(Textures.ElementAt(index), false);
                addedStep += percentageStep;
                index++;
            }

            return new AnimationImage(Textures.Last(), false);
        }

        public IAnimationImage GetFirstImage(Degree degree = Degree.Degree_0)
        {
            return new AnimationImage(Textures.First(), false);
        }
    }
}
