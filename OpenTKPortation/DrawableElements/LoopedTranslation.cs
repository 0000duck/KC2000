using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseContracts;

namespace DrawableElements
{
    public class LoopedTranslation : IDrawable
    {
        private IPercentDrivenSprite _percentDrivenSprite;
        private IPercentFader _percentFader;
        private bool _forward;

        public LoopedTranslation(IPercentDrivenSprite percentDrivenSprite, IPercentFader percentFader)
        {
            _percentDrivenSprite = percentDrivenSprite;
            _percentFader = percentFader;
            _forward = true;
        }

        void IDrawable.Draw()
        {
            double percent = _percentFader.GetPercent();

            if (percent < 0 || _percentFader.IsFinished())
            {
                _percentFader.Start();
                _forward = !_forward;
                percent = 0;
            }

            _percentDrivenSprite.SetPercent(_forward ? percent : 1 - percent);
            _percentDrivenSprite.Draw();
        }
    }
}
