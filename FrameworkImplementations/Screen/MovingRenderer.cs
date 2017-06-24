using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace FrameworkImplementations.Screen
{
    public class MovingRenderer : ICountRenderer
    {
        private IDrawable _drawable;
        private IWorldTranslator _translator;

        public MovingRenderer(IDrawable drawable, IWorldTranslator translator)
        {
            _drawable = drawable;
            _translator = translator;
        }

        void ICountRenderer.RenderCount(int count, double leftCornerX, double leftCornerY)
        {
            _translator.Store();
            _translator.TranslateWorld(leftCornerX, leftCornerY, 0);
            _drawable.Draw();
            _translator.Reset();
        }
    }
}
