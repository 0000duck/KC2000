using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using BaseTypes;
using Render.Contracts;

namespace DrawableElements
{
    public class ImageSprite : IDrawable, ICommunicationElement, IVisualParameterized
    {
        protected ITexture Texture { set; get; }
        private Position3D Position { set; get; }
        protected IDrawable Sprite { set; get; }
        protected IDrawable MarkedSprite { set; get; }
        private bool IsMarked { set; get; }
        private bool IsVisible { set; get; }
        private ITextureChanger _textureChanger;
        private IWorldTranslator _worldTranslator;

        public ImageSprite(ITexture texture, ITextureChanger textureChanger, Position3D position, IDrawable sprite, IDrawable markedSprite, IWorldTranslator worldTranslator)
        {
            Texture = texture;
            Position = new Position3D { PositionX = position.PositionX, PositionY = position.PositionZ, PositionZ = position.PositionY };
            Sprite = sprite;
            MarkedSprite = markedSprite;
            _textureChanger = textureChanger;
            _worldTranslator = worldTranslator;
        }

        #region IDrawable
        void IDrawable.Draw()
        {
            if (!IsVisible)
                return;

            _textureChanger.SetTexture(Texture.TextureId);

            _worldTranslator.Store();

            _worldTranslator.TranslateWorld(Position.PositionX, Position.PositionY, Position.PositionZ);

            if (IsMarked && MarkedSprite != null)
            {
                MarkedSprite.Draw();
                IsMarked = false;
            }
            Sprite.Draw();

            _worldTranslator.Reset();

            IsVisible = false;
        }
        #endregion

        #region ICommunicationElement
        public void ChangePosition(double x, double y, double z)
        {
            Position.PositionX = x;
            Position.PositionY = z;
            Position.PositionZ = y;
        }

        public virtual void RenderAnimation(Behaviour behaviour, double percent, Degree degree = Degree.Degree_0, bool isMarked = false)
        {
            IsMarked = isMarked;
            IsVisible = true;
        }
        #endregion

        #region IVisualParameterized
        public IVisualParameters GetParameters()
        {
            if (Sprite is IVisualParameterized)
                return (Sprite as IVisualParameterized).GetParameters();
            return null;
        }
        #endregion
    }
}
