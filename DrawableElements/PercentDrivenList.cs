using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace DrawableElements
{
    public class PercentDrivenList : IPercentDrivenSprite
    {
        private List<IPercentDrivenSprite> _percentDrivenSprites;

        public PercentDrivenList(List<IPercentDrivenSprite> percentDrivenSprites)
        {
            _percentDrivenSprites = percentDrivenSprites;
        }

        void IPercentDrivenSprite.SetPercent(double percent)
        {
            _percentDrivenSprites.ForEach(x=>x.SetPercent(percent));
        }

        void IDrawable.Draw()
        {
            _percentDrivenSprites.ForEach(x => x.Draw());
        }
    }
}
