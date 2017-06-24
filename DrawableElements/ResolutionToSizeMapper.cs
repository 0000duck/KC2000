using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace DrawableElements
{
    public class ResolutionToSizeMapper : IResolutionToSizeMapper
    {
        public double GetSize(int resolution)
        {
            return (resolution / 16.0) * 0.5;
        }
    }
}
