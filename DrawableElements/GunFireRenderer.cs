using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class GunFireRenderer : IGunFire
    {
        private double _percentFactor;
        private IDrawable _sprite;
        private IAnimation _animation;
        private ITextureChanger _textureChanger;

        public GunFireRenderer(IAnimation animation, ITextureChanger textureChanger, IDrawable sprite, double gunFirePercentFactor)
        {
            _animation = animation;
            _percentFactor = gunFirePercentFactor;
            _sprite = sprite;
            _textureChanger = textureChanger;
        }

        void IGunFire.DrawFire(double percent)
        {
            double calculatedPercent = percent * _percentFactor;
            
            if(calculatedPercent > 1.0)
                return;

            IAnimationImage texture = _animation.GetImage(calculatedPercent);

           _textureChanger.SetTexture(texture.Texture.TextureId);

            _sprite.Draw();
        }
    }
}
