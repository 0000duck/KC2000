﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using BaseTypes;
using Render.Contracts;

namespace DrawableElements
{
    public class AnimationSprite : IDrawable, ICommunicationElement, IVisualParameterized
    {
        protected IAnimation Animation { set; get; }
        private IAnimationImage AnimationImage { set; get; }
        private Position3D Position { set; get; }
        private Degree Degree { set; get; }
        private double _percent;
        protected IDrawable Sprite { set; get; }
        private bool IsVisible { set; get; }
        private IDegreeCalculator DegreeCalculator { set; get; }
        private ITextureChanger _textureChanger;
        private IWorldTranslator _worldTranslator;

        public AnimationSprite(IAnimation animation, ITextureChanger textureChanger, Position3D position, IDrawable sprite, IDegreeCalculator degreeCalculator, IWorldTranslator worldTranslator)
        {
            Animation = animation;
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

            DetermineTexture();
            _textureChanger.SetTexture(AnimationImage.Texture.TextureId);

            _worldTranslator.Store();
            _worldTranslator.TranslateWorld(Position.PositionX, Position.PositionY, Position.PositionZ);

            if (AnimationImage.IsMirrored && Sprite is IMirroredDrawable)
                (Sprite as IMirroredDrawable).DrawMirrored();
            else
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
            Degree = DegreeCalculator.CalculateIndividualDegree(degree, Position.PositionX, Position.PositionZ);
            IsVisible = true;
            _percent = percent;
        }
        private void DetermineTexture()
        {
            AnimationImage = Animation.GetImage(_percent, Degree);
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
