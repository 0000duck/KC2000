using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace FrameworkImplementations.Screen
{
    public class MovingCountRenderer : ICountRenderer
    {
        private ICountRenderer _countRenderer;
        private IDrawable _background;
        private IWorldTranslator _translator;

        public MovingCountRenderer(ICountRenderer countRenderer, IDrawable background, IWorldTranslator translator)
        {
            _countRenderer = countRenderer;
            _background = background;
            _translator = translator;
        }

        void ICountRenderer.RenderCount(int count, double leftCornerX, double leftCornerY)
        {
            _translator.Store();
            _translator.TranslateWorld(leftCornerX, leftCornerY, 0);
            _background.Draw();
            _countRenderer.RenderCount(count, 0.021, 0.056);
            _translator.Reset();
        }
    }
}
