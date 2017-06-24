using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using BaseContracts;

namespace FrameworkImplementations.Mainframe
{
    public class LoopedFader : IDrawable, IFader
    {
        private Action _swapBuffer;
        private IPercentDrivenSprite _fadeAnimation;
        private bool _fading;
        private bool _fadeOut;
        private IPercentFader _timer;

        public LoopedFader(Action swapBuffer, IPercentDrivenSprite fadeAnimation, IPercentFader percentFader)
        {
            _swapBuffer = swapBuffer;
            _fadeAnimation = fadeAnimation;
            _timer = percentFader;
        }

        void IDrawable.Draw()
        {
            if (!_fading)
                return;

            if (_fadeOut)
            {
                double percentFadeout;
                while (!_timer.IsFinished())
                {
                    percentFadeout = _timer.GetPercent();
                    _fadeAnimation.SetPercent(1 - percentFadeout);
                    _fadeAnimation.Draw();
                    _swapBuffer();
                }
                _fadeOut = false;
                _timer.Start();
            }

            double percentFadein = _timer.GetPercent();
            _fadeAnimation.SetPercent(percentFadein);
            _fadeAnimation.Draw();

            if (_timer.IsFinished())
            {
                _fading = false;
            }
        }

        void IFader.FadeOut()
        {
            _fading = true;
            _timer.Start();
            _fadeOut = true;
        }
    }
}
