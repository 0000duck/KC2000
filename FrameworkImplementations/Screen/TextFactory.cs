using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace FrameworkImplementations.Screen
{
    public class TextFactory : ITextFactory
    {
        private IAnimationLoader _animationLoader;
        private string _characterPath;
        private IRectanglePolygonBuilder _rectangleBuilder;
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;
        private double _characterLength;
        private IColorToPercentMapper _mapper;

        public TextFactory(IAnimationLoader animationLoader, IRectanglePolygonBuilder rectangleBuilder, ITextureChanger textureChanger, IColorToPercentMapper mapper, IPolygonRenderer polygonRenderer, string characterPath, double characterLength)
        {
            _animationLoader = animationLoader;
            _rectangleBuilder = rectangleBuilder;
            _characterPath = characterPath;
            _polygonRenderer = polygonRenderer;
            _textureChanger = textureChanger;
            _characterLength = characterLength;
            _mapper = mapper;
        }

        IScreenText ITextFactory.CreateText(double leftCornerX, double leftCornerY, string text)
        {
            List<IRectangle> characters = new List<IRectangle>();

            double nextLeftCornerX = leftCornerX;
            foreach (char c in text)
            {
                string characterName = c.ToString();
                characterName = characterName.Replace("?", "QM");
                characterName = characterName.Replace("!", "EM");
                characterName = characterName.Replace(":", "DP");
                
                if (!c.Equals(' ') && !c.Equals('.') && !c.Equals('\\'))
                {
                    IAnimation animation = _animationLoader.LoadAnimation(_characterPath + "\\" + characterName);
                    Rectangle2D rectangle = new Rectangle2D(animation, _textureChanger, _polygonRenderer, new RectanglePolygonBuilder(), nextLeftCornerX, leftCornerY, _characterLength, _characterLength, false);
                    characters.Add(rectangle);
                }

                nextLeftCornerX += _characterLength;
            }

            return new Text(characters, _mapper, nextLeftCornerX, _characterLength, leftCornerX, leftCornerY);
        }
    }
}
