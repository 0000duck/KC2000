using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace DrawableElements
{
    public class ListRenderer : IDrawableList
    {
        private List<IDrawable> _drawableList;

        public ListRenderer(List<IDrawable> drawableList)
        {
            _drawableList = drawableList;
        }

        void IDrawable.Draw()
        {
            foreach (IDrawable drawable in _drawableList)
            {
                drawable.Draw();
            }
        }

        void IDrawableList.Add(IDrawable drawable)
        {
            _drawableList.Add(drawable);
        }

        void IDrawableList.Remove(IDrawable drawable)
        {
            _drawableList.Remove(drawable);
        }
    }
}
