using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseContracts;
using System.Threading;

namespace BaseTypes
{
    public class ThreadPausingPercentFader : IPercentFader
    {
        private int _sleep;
        private int _numberOfFrames;
        private int _counter;

        public ThreadPausingPercentFader(double duration, int numberOfFrames)
        {
            _numberOfFrames = numberOfFrames;
            _sleep = (int) ((duration * 1000.0) / numberOfFrames);
        }

        void IPercentFader.Start()
        {
            _counter = 0;
        }

        bool IPercentFader.IsFinished()
        {
            return _counter >= _numberOfFrames;
        }

        double IPercentFader.GetPercent()
        {
            Thread.Sleep(_sleep);
            _counter++;

            if (_counter > _numberOfFrames)
                _counter = _numberOfFrames;

            return ((double)_counter) / _numberOfFrames;
        }
    }
}
