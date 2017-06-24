using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence
{
    public class Ducker : IDucker
    {
        private IRandomDurationGenerator _randomDurationGenerator;
        private PercentFader _duckPercentFader;
        private DuckStatus _status;

        private enum DuckStatus
        {
            Standing = 0,
            MoveDown = 1,
            Waiting = 2,
            MoveUp = 3
        }

        public Ducker(IRandomDurationGenerator randomDurationGenerator, double duckDuration)
        {
            _randomDurationGenerator = randomDurationGenerator;
            _duckPercentFader = new PercentFader(duckDuration);
            _status = DuckStatus.Standing;
        }

        bool IDucker.IsDucking()
        {
            return _status != DuckStatus.Standing;
        }

        void IDucker.StartDucking()
        {
            _duckPercentFader.Start();
            _status = DuckStatus.MoveDown;
        }

        DuckResult IDucker.GetDuckResult()
        {
            switch (_status)
            {
                case DuckStatus.MoveDown:
                    if (_duckPercentFader.IsFinished())
                    {
                        _status = DuckStatus.Waiting;
                        _randomDurationGenerator.StartRandomDuration();
                    }
                    return new DuckResult
                    {
                        Behaviour = IOInterface.Behaviour.Ducked,
                        Percent = _duckPercentFader.GetPercent()
                    };
                case DuckStatus.Waiting:
                    if (_randomDurationGenerator.IsFinished())
                    {
                        _status = DuckStatus.MoveUp;
                        _duckPercentFader.Start();
                    }
                    return new DuckResult
                    {
                        Behaviour = IOInterface.Behaviour.Ducked,
                        Percent = 1.0
                    };
                case DuckStatus.MoveUp:
                    if (_duckPercentFader.IsFinished())
                    {
                        _status = DuckStatus.Standing;
                    }
                    return new DuckResult
                    {
                        Behaviour = IOInterface.Behaviour.Ducked,
                        Percent = 1.0 - _duckPercentFader.GetPercent()
                    };
            }
            return new DuckResult
            {
                Behaviour = IOInterface.Behaviour.StandardBehaviour,
                Percent = 0
            };
        }
    }
}
