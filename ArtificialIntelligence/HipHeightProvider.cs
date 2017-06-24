using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;

namespace ArtificialIntelligence
{
    public class HipHeightProvider : IHipHeightProvider
    {
        private IDucker _ducker;
        private double _standardHeight;
        private double _duckedHeight;

        public HipHeightProvider(IDucker ducker, double standardHeight, double duckedHeight)
        {
            _ducker = ducker;
            _standardHeight = standardHeight;
            _duckedHeight = duckedHeight;
        }

        double IHipHeightProvider.GetRelativeHipHeight()
        {
            if (_ducker == null)
                return _standardHeight;

            return _ducker.IsDucking() ? _duckedHeight : _standardHeight;
        }
    }
}
