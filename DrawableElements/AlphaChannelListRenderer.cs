using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class AlphaChannelListRenderer : IDrawableList
    {
        private List<IDrawable> DrawableList { set; get; }
        private IAlphaTester _alphaTester;

        public AlphaChannelListRenderer(IAlphaTester alphaTester, List<IDrawable> drawableList)
        {
            _alphaTester = alphaTester;
            DrawableList = drawableList;
        }

        public void Draw()
        {
            _alphaTester.Begin();

            foreach (IDrawable drawable in DrawableList)
            {
                drawable.Draw();
            }
            _alphaTester.End();
        }

        public void Add(IDrawable drawable)
        {
            DrawableList.Add(drawable);
        }

        public void Remove(IDrawable drawable)
        {
            DrawableList.Remove(drawable);
        }
    }
}
