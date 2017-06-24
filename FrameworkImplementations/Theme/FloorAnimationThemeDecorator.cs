using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using BaseTypes;

namespace FrameworkImplementations.Theme
{
    public class FloorAnimationThemeDecorator : ITheme
    {
        private ITheme _theme;
        private IAnimationImage _fixImage;

        public FloorAnimationThemeDecorator(ITheme theme)
        {
            _theme = theme;
        }

        IAnimationImage ITheme.GetTexture(Behaviour behaviour, Degree degree, double percent)
        {
            if (_fixImage != null)
                return _fixImage;

            switch (behaviour)
            {
                case Behaviour.LyingOnFloor:
                case Behaviour.LyingOnFloorA:
                case Behaviour.LyingOnFloorH:
                case Behaviour.LyingOnFloorL:
                case Behaviour.LyingOnFloorT:
                    Degree mappedDegree = MapDegree(degree);
                    if (percent > 0.9)
                    {
                        _fixImage = _theme.GetTexture(behaviour, mappedDegree, percent);
                        return _fixImage;
                    }
                    else
                    {
                        return _theme.GetTexture(behaviour, mappedDegree, percent);
                    }
                default:
                    return _theme.GetTexture(behaviour, degree, percent);
            }
        }

        private Degree MapDegree(Degree degree)
        {
            switch (degree)
            {
                case Degree.Degree_0:
                case Degree.Degree_45:
                    return Degree.Degree_45;
                case Degree.Degree_90:
                case Degree.Degree_135:
                    return Degree.Degree_135;
                case Degree.Degree_180:
                case Degree.Degree_225:
                    return Degree.Degree_225;
                case Degree.Degree_270:
                case Degree.Degree_315:
                    return Degree.Degree_315;
            }
            return Degree.Degree_45;
        }
    }
}
