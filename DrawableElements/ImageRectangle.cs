using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class ImageRectangle : IDrawable
    {
        private ITexture _texture;
        private IDrawable _sprite;
        private ITextureChanger _textureChanger;

        public ImageRectangle(ITexture texture, ITextureChanger textureChanger, IDrawable sprite)
        {
            _texture = texture;
            _sprite = sprite;
            _textureChanger = textureChanger;
        }

        void IDrawable.Draw()
        {
            _textureChanger.SetTexture(_texture.TextureId);

            _sprite.Draw();
        }
    }
}
