using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using Render.Contracts;

namespace DrawableElements
{
    public class StandardWeaponRenderer : IWeaponRenderer
    {
        private ITheme _theme;
        private IDrawable _sprite;
        private IGunFire _gunfire;
        private ITextureChanger _textureChanger;

        public StandardWeaponRenderer(ITheme theme, ITextureChanger textureChanger, IDrawable sprite, IGunFire gunfire)
        {
            _theme = theme;
            _sprite = sprite;
            _gunfire = gunfire;
            _textureChanger = textureChanger;
        }

        void IWeaponRenderer.Draw(Behaviour behaviour, double percent)
        {
            if (behaviour == Behaviour.FiredInHand)
                _gunfire.DrawFire(percent);

            IAnimationImage texture = _theme.GetTexture(behaviour, BaseTypes.Degree.Degree_0, percent);
            _textureChanger.SetTexture(texture.Texture.TextureId);

            _sprite.Draw();
        }
    }
}
