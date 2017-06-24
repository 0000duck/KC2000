using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;
using Render;

namespace FrameworkImplementations
{
    public class RectangleFactory : IRectangleFactory
    {
        private IAnimationLoader AnimationLoader { set; get; }

        private string CharacterPath { set; get; }

        private string ImagePath { set; get; }
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;

        public RectangleFactory(IAnimationLoader animationLoader, ITextureChanger textureChanger, IPolygonRenderer polygonRenderer, string characterPath, string imagePath)
        {
            AnimationLoader = animationLoader;
            _polygonRenderer = polygonRenderer;
            CharacterPath = characterPath;
            ImagePath = imagePath;
            _textureChanger = textureChanger;
        }

        public IRectangle CreateRectangle(double leftCornerX, double leftCornerY, double lengthX, double lengthY, char? character = null, string image = null, bool center = true)
        {
            IAnimation animation = null; 
            if(character.HasValue)
            {
                string characterName = character.ToString();
                characterName = characterName.Replace("?", "QM");
                characterName = characterName.Replace("!", "EM");
                characterName = characterName.Replace(":", "DP");
                animation = AnimationLoader.LoadAnimation(CharacterPath + "\\" + characterName);
            }
            else if(image != null)
            {
                animation = AnimationLoader.LoadAnimation(ImagePath + "\\" + image);
            }
            else throw new ArgumentNullException("missing character or image name!");

            Rectangle2D rectangle = new Rectangle2D(animation, _textureChanger, _polygonRenderer,new RectanglePolygonBuilder(), leftCornerX, leftCornerY, lengthX, lengthY, center);

            return rectangle;
        }
    }
}
