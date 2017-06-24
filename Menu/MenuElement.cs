using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace Menu
{
    public class MenuElement : IMenuElement
    {
        private IScreenText _text;

        public bool Visible { set; get; }

        public MenuElement(IScreenText text, bool visible = true)
        {
            _text = text;
            Visible = visible;
        }

        public virtual void Draw()
        {
            if (!Visible)
                return;

            _text.DrawColor(C64Color.Lightblue);
        }

        public virtual void DrawAnimation()
        {
            if (!Visible)
                return;

            _text.DrawAllColors();
        }

        public bool MouseOver(double mouseX, double mouseY)
        {
            if (mouseX < _text.LeftCornerX)
                return false;

            if (mouseY < _text.LowerCornerY)
                return false;

            if (mouseX > _text.LeftCornerX + _text.Width)
                return false;

            if (mouseY > _text.LowerCornerY + _text.Height)
                return false;

            return true;
        }
    }
}
