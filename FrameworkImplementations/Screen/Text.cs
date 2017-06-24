using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Screen
{
    public class Text : IScreenText
    {
        private List<IRectangle> _characters;
        private IColorToPercentMapper _mapper;
        private bool _render;
        private C64Color _lastColor;
        private DateTime _lastColorChange;

        public double Width { get; private set; }

        public double Height { get; private set; }

        public double LeftCornerX { get; private set; }

        public double LowerCornerY { get; private set; }

        public Text(List<IRectangle> characters, IColorToPercentMapper mapper, double width, double height, double leftX, double lowerY)
        {
            _characters = characters;
            _mapper = mapper;
            Width = width;
            Height = height;
            LeftCornerX = leftX;
            LowerCornerY = lowerY;
            _lastColorChange = DateTime.Now;
        }

        void IScreenText.DrawColor(C64Color c64Color)
        {
            double percent = _mapper.MapColor(c64Color);

            foreach (IRectangle character in _characters)
            {
                character.DrawAnimation(percent);
            }
        }

        void IScreenText.DrawAllColors()
        {
            DateTime now = DateTime.Now;

            if ((now - _lastColorChange).TotalSeconds > 0.1)
            {
                int color = (int)_lastColor;
                color++;

                if (color > 16)
                    color = 1;

                _lastColor = (C64Color)color;
                _lastColorChange = now;
            }

            ((IScreenText)this).DrawColor(_lastColor);
        }

        void IScreenText.DrawFlickering()
        {
            _render = !_render;

            if (!_render)
                return;

            ((IScreenText)this).DrawColor();
        }
    }
}
