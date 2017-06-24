using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace OpenTKPortation.Implementations
{
    public class MessageRenderer : IMessageRenderer, IDrawable
    {
        private string _lastText;
        private IScreenText _text;
        private ITextFactory _textFactory;
        private double _cornerX;
        private double _cornerY;

        public MessageRenderer(ITextFactory textFactory, double cornerX, double cornerY)
        {
            _textFactory = textFactory;
            _cornerX = cornerX;
            _cornerY = cornerY;
        }

        void IDrawable.Draw()
        {
            if (_text != null)
                _text.DrawColor();
        }

        void IMessageRenderer.RenderMessage(string message)
        {
            if (_lastText == null || !_lastText.Equals(message))
                _text = _textFactory.CreateText(_cornerX, _cornerY, message);
            _lastText = message;
        }
    }
}
