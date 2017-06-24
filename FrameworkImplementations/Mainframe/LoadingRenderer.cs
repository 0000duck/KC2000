using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseContracts;

namespace FrameworkImplementations.Mainframe
{
    public class LoadingRenderer : IDrawable
    {
        private IPercentProvider _precentProvider;
        private IPercentDrivenSprite _percentDrivenSprite;
        private bool _loadingDelay;
        private double _delaySeconds;
        private DateTime _start;
        private double _lastPercent;

        public LoadingRenderer(IPercentProvider percentProvider, IPercentDrivenSprite percentDrivenSprite, double delaySeconds)
        {
            _precentProvider = percentProvider;
            _percentDrivenSprite = percentDrivenSprite;
            _loadingDelay = true;
            _delaySeconds = delaySeconds;
            _lastPercent = 1;
        }

        void IDrawable.Draw()
        {
            if (_loadingDelay)
            {
                if ((DateTime.Now - _start).TotalSeconds < _delaySeconds)
                {
                    _percentDrivenSprite.SetPercent(_lastPercent < 1 ? _lastPercent : 0);
                    _percentDrivenSprite.Draw();
                    return;
                }
                else
                {
                    _loadingDelay = false;
                }
            }
            double percent = _precentProvider.GetPercent();
            _percentDrivenSprite.SetPercent(percent);
            _percentDrivenSprite.Draw();

            if (_lastPercent > percent)
            {
                _loadingDelay = true;
                _start = DateTime.Now;
            }
            _lastPercent = percent;
        }
    }
}
