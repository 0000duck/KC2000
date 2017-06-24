using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;
using FrameworkContracts;
using BaseTypes;

namespace DrawableElements
{
    public class AnimationByPercentSprite : IPercentDrivenSprite
    {
        private IDrawable _sprite;
        private IAnimation _animation;
        private ITextureChanger _textureChanger;
        private double _percent;
        private bool _flipAnimation;
        private double _factor;

        public AnimationByPercentSprite(IDrawable sprite, IAnimation animation, ITextureChanger textureChanger, bool flipAnimation = false, double factor = 1.0)
        {
            _sprite = sprite;
            _animation = animation;
            _textureChanger = textureChanger;
            _flipAnimation = flipAnimation;
            _factor = factor;
        }

        void IDrawable.Draw()
        {
            double percent = _percent * _factor;

            while (percent > 1.0)
                percent -= 1.0;

            _textureChanger.SetTexture(_animation.GetImage(_flipAnimation ? 1 - percent : percent, Degree.Degree_0).Texture.TextureId);
            _sprite.Draw();
        }

        void IPercentDrivenSprite.SetPercent(double percent)
        {
            _percent = percent;
        }
    }
}
