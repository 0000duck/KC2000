using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;
using BaseTypes;

namespace DrawableElements
{
    public class TextureTranslationDecorator : IDrawable
    {
        private IDrawable _sprite;
        private ITextureTranslator _textureTranslator;
        private double _durationInSeconds;
        private TextureCoordinateDirection _textureCoordinateDirection;

        public TextureTranslationDecorator(IDrawable sprite, ITextureTranslator textureTranslator, double durationInSeconds, TextureCoordinateDirection textureCoordinateDirection)
        {
            _sprite = sprite;
            _textureTranslator = textureTranslator;
            _durationInSeconds = durationInSeconds;
            _textureCoordinateDirection = textureCoordinateDirection;
        }

        void IDrawable.Draw()
        {
            _textureTranslator.Store();
            double distance = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds / _durationInSeconds;
            switch (_textureCoordinateDirection)
            {
                case TextureCoordinateDirection.PositiveX:
                    _textureTranslator.TranslateTexture(distance, 0);
                    break;
                case TextureCoordinateDirection.NegativeX:
                    _textureTranslator.TranslateTexture(-distance, 0);
                    break;
                case TextureCoordinateDirection.PositiveY:
                    _textureTranslator.TranslateTexture(0, distance);
                    break;
                case TextureCoordinateDirection.NegativeY:
                    _textureTranslator.TranslateTexture(0, -distance);
                    break;
                case TextureCoordinateDirection.PositiveXNegativeY:
                    _textureTranslator.TranslateTexture(distance, 0);
                    _textureTranslator.TranslateTexture(0, -distance);
                    break;
                case TextureCoordinateDirection.NegativeXNegativeY:
                    _textureTranslator.TranslateTexture(-distance, 0);
                    _textureTranslator.TranslateTexture(0, -distance);
                    break;
            }
            _sprite.Draw();
            _textureTranslator.Reset();
        }
    }
}
