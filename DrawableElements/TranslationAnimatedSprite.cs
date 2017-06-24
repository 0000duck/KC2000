using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;
using BaseTypes;

namespace DrawableElements
{
    public class TranslationAnimatedSprite : IPercentDrivenSprite
    {
        private IDrawable _sprite;
        private IWorldTranslator _worldTranslator;
        private Position3D _start;
        private Position3D _end;
        private double _percent;

        public TranslationAnimatedSprite(IDrawable sprite, IWorldTranslator worldTranslator, Position3D start, Position3D end)
        {
            _sprite = sprite;
            _worldTranslator = worldTranslator;
            _start = start;
            _end = end;
        }

        void IPercentDrivenSprite.SetPercent(double percent)
        {
            _percent = percent;
        }

        void IDrawable.Draw()
        {
            _worldTranslator.Store();
            _worldTranslator.TranslateWorld((_start.PositionX * (1.0 - _percent)) + (_end.PositionX * _percent),
                (_start.PositionY * (1.0 - _percent)) + (_end.PositionY * _percent),
                (_start.PositionZ * (1.0 - _percent)) + (_end.PositionZ * _percent));
            _sprite.Draw();
            _worldTranslator.Reset();
        }
    }
}
