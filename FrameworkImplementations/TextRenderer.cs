using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations
{
    public class TextRenderer : IDrawable
    {
        IScreenText _screenText;

        public TextRenderer(IScreenText screenText)
        {
            _screenText = screenText;
        }

        void IDrawable.Draw()
        {
            _screenText.DrawColor(C64Color.Grey_2);
        }
    }
}
