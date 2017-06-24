using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Render.Contracts;
using FrameworkContracts;

namespace FrameworkImplementations
{
    public class Rectangle2DImage : IRectangle
    {
        private double LeftCornerX { set; get; }
        private double LeftCornerY { set; get; }
        private double LengthX { set; get; }
        private double LengthY { set; get; }
        private bool Center { set; get; }

        private ITexture Texture { set; get; }
        private Polygon Rectangle { set; get; }
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;
        private IRectanglePolygonBuilder _rectanglePolygonBuilder;

        public Rectangle2DImage(ITexture texture, ITextureChanger textureChanger, IPolygonRenderer polygonRenderer, IRectanglePolygonBuilder rectanglePolygonBuilder, double leftCornerX, double leftCornerY, double lengthX, double lengthY, bool center)
        {
            Texture = texture;
            _polygonRenderer = polygonRenderer;
            _rectanglePolygonBuilder = rectanglePolygonBuilder;
            LeftCornerX = leftCornerX;
            LeftCornerY = leftCornerY;
            LengthX = lengthX;
            LengthY = lengthY;
            Center = center;
            _textureChanger = textureChanger;
            Rectangle = _rectanglePolygonBuilder.CreatePolygon((float)LeftCornerX, (float)LeftCornerY, (float)LengthX, (float)LengthY, Center);
        }

        public void SetPosition(double leftCornerX, double leftCornerY)
        {
            LeftCornerX = leftCornerX;
            LeftCornerY = leftCornerY;
            Rectangle = _rectanglePolygonBuilder.CreatePolygon((float)LeftCornerX, (float)LeftCornerY, (float)LengthX, (float)LengthY, Center);
        }

        public void DrawAnimation(double percentOfAnimation)
        {
            RenderTexture(Texture);
        }

        public void Draw()
        {
            RenderTexture(Texture);
        }

        private void RenderTexture(ITexture texture)
        {
            _textureChanger.SetTexture(texture.TextureId);

            _polygonRenderer.RenderPolygons(new List<Polygon> { Rectangle });
        }
    }
}
