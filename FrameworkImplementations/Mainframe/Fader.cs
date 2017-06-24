using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using BaseContracts;

namespace FrameworkImplementations.Mainframe
{
    public class Fader : IDrawable, IFader
    {
        private IPercentDrivenSprite _fadeAnimation;
        private bool _fading;
        private bool _fadeOut;
        private IPercentFader _timer;

        public Fader(IPercentDrivenSprite fadeAnimation, IPercentFader percentFader)
        {
            _fadeAnimation = fadeAnimation;
            _timer = percentFader;
        }

        void IDrawable.Draw()
        {
            if (!_fading)
                return;

            if (_fadeOut)
            {
                double percentFadeout = _timer.GetPercent();
                _fadeAnimation.SetPercent(1 - percentFadeout);
                _fadeAnimation.Draw();

                if (_timer.IsFinished())
                {
                    _fadeOut = false;
                    _timer.Start();
                }
            }
            else
            {
                double percentFadein = _timer.GetPercent();
                _fadeAnimation.SetPercent(percentFadein);
                _fadeAnimation.Draw();

                if (_timer.IsFinished())
                {
                    _fading = false;
                }
            }
        }

        void IFader.FadeOut()
        {
            _fading = true;
            _fadeOut = true;
            _timer.Start();  
        }
    }
}
