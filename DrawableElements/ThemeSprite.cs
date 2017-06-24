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
    public class ThemeSprite : IDrawable, ICommunicationElement
    {
        private ITheme Theme { set; get; }
        private IAnimationImage AnimationImage { set; get; }
        private Position3D Position { set; get; }
        private IDrawable Sprite { set; get; }
        private bool IsVisible { set; get; }
        private IDegreeCalculator DegreeCalculator { set; get; }
        private ITextureChanger _textureChanger;
        private IWorldTranslator _worldTranslator;

        public ThemeSprite(ITheme theme, ITextureChanger textureChanger, Position3D position, IDrawable sprite, IDegreeCalculator degreeCalculator, IWorldTranslator worldTranslator)
        {
            Theme = theme;
            Position = new Position3D { PositionX = position.PositionX, PositionY = position.PositionZ, PositionZ = position.PositionY };
            Sprite = sprite;
            DegreeCalculator = degreeCalculator;
            _textureChanger = textureChanger;
            _worldTranslator = worldTranslator;
        }

        #region IDrawable
        void IDrawable.Draw()
        {
            if (!IsVisible)
                return;

            _textureChanger.SetTexture(AnimationImage.Texture.TextureId);

            _worldTranslator.Store();
            _worldTranslator.TranslateWorld(Position.PositionX, Position.PositionY, Position.PositionZ);
            if (AnimationImage.IsMirrored && Sprite is IMirroredDrawable)
                ((IMirroredDrawable)Sprite).DrawMirrored();
            else
                Sprite.Draw();

            _worldTranslator.Reset();

            IsVisible = false;
        }
        #endregion

        #region ICommunicationElement
        void ICommunicationElement.ChangePosition(double x, double y, double z)
        {
            Position.PositionX = x;
            Position.PositionY = z;
            Position.PositionZ = y;
        }

        void ICommunicationElement.RenderAnimation(Behaviour behaviour, double percent, Degree degree = Degree.Degree_0, bool isMarked = false)
        {
            degree = DegreeCalculator.CalculateIndividualDegree(degree, Position.PositionX, Position.PositionZ);
            AnimationImage = Theme.GetTexture(behaviour, degree, percent);
            IsVisible = true;
        }
        #endregion
    }
}
