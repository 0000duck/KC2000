using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;
using IOInterface;

namespace DrawableElements
{
    public class FirelessWeaponRenderer: IWeaponRenderer
    {
        private ITheme _theme;
        private IDrawable _sprite;
        private ITextureChanger _textureChanger;

        public FirelessWeaponRenderer(ITheme theme, ITextureChanger textureChanger, IDrawable sprite)
        {
            _theme = theme;
            _sprite = sprite;
            _textureChanger = textureChanger;
        }

        void IWeaponRenderer.Draw(Behaviour behaviour, double percent)
        {
            IAnimationImage texture = _theme.GetTexture(behaviour, BaseTypes.Degree.Degree_0, percent);
            _textureChanger.SetTexture(texture.Texture.TextureId);

            _sprite.Draw();
        }
    }
}
