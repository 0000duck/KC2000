using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class LightRenderer : IDrawable
    {
        private ILightCollection LightCollection { set; get; }
        private IDrawable Drawable { set; get; }

        public LightRenderer(ILightCollection lightCollection, IDrawable drawable)
        {
            LightCollection = lightCollection;
            Drawable = drawable;
        }

        void IDrawable.Draw()
        {
            LightCollection.Enable();
            Drawable.Draw();
            LightCollection.Disable();
        }
    }
}
