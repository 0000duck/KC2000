using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class DepthlessRenderer : IDrawable
    {
        private IDepthTestActivator _depthTestActivator;
        private IDrawable _element;

        public DepthlessRenderer(IDepthTestActivator depthTestActivator, IDrawable element)
        {
            _depthTestActivator = depthTestActivator;
            _element = element;
        }

        void IDrawable.Draw()
        {
            _depthTestActivator.Deactivate();
            _element.Draw();
            _depthTestActivator.Activate();
        }
    }
}
