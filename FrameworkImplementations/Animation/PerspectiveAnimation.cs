using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Render.Contracts;

namespace FrameworkImplementations.Animation
{
    public class PerspectiveAnimation : IAnimation
    {
        private Dictionary<Degree, List<ITexture>> Textures { set; get; }

        public PerspectiveAnimation(Dictionary<Degree, List<ITexture>> textures)
        {
            Textures = textures;
        }

        public IAnimationImage GetFirstImage(Degree degree = Degree.Degree_0)
        {
            bool isMirrored;
            Degree newDegree = DetermineDegree(degree, out isMirrored);

            List<ITexture> textures = Textures[newDegree];

            return new AnimationImage(textures.First(), isMirrored);
        }

        public IAnimationImage GetImage(double percentageOfAnimation, Degree degree = Degree.Degree_0)
        {
            bool isMirrored;
            Degree newDegree = DetermineDegree(degree, out isMirrored);

            List<ITexture> textures = Textures[newDegree];

            double percentageStep = 1.0 / (double)textures.Count;

            double addedStep = percentageStep;
            int index = 0;

            while (addedStep <= 1.0)
            {
                if (percentageOfAnimation < addedStep)
                    return new AnimationImage(textures.ElementAt(index), isMirrored);

                addedStep += percentageStep;
                index++;
            }

            return new AnimationImage(textures.Last(), isMirrored);
        }

        private Degree DetermineDegree(Degree degree, out bool isMirrored)
        {
            isMirrored = false;

            if (Textures.Keys.Contains(degree))
                return degree;

            Degree? newDegree = GetMirroredDegree(degree);

            if (newDegree.HasValue && Textures.Keys.Contains(newDegree.Value))
            {
                isMirrored = true;
                return newDegree.Value;
            }

            newDegree = GetNearestDegree(degree);
            if (newDegree.HasValue && Textures.Keys.Contains(newDegree.Value))
                return newDegree.Value;

            return Degree.Degree_0;
        }

        private Degree? GetNearestDegree(Degree degree)
        {
            switch (degree)
            {
                case Degree.Degree_45:
                    return Degree.Degree_0;
                case Degree.Degree_135:
                    return Degree.Degree_90;
                case Degree.Degree_225:
                    return Degree.Degree_180;
                case Degree.Degree_315:
                    return Degree.Degree_270;
            }
            return null;
        }

        private Degree? GetMirroredDegree(Degree degree)
        {
            switch (degree)
            {
                case Degree.Degree_45:
                    return Degree.Degree_315;
                case Degree.Degree_90:
                    return Degree.Degree_270;
                case Degree.Degree_135:
                    return Degree.Degree_225;
                case Degree.Degree_225:
                    return Degree.Degree_135;
                case Degree.Degree_270:
                    return Degree.Degree_90;
                case Degree.Degree_315:
                    return Degree.Degree_45;
            }
            return null;
        }
    }
}
