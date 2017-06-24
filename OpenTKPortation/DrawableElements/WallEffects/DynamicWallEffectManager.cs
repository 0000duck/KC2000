using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using Render.Contracts;

namespace DrawableElements.WallEffects
{
    public class DynamicWallEffectManager : IDynamicWallEffectManager, IDrawable
    {
        private List<IDrawable> _wallEffects = new List<IDrawable>();
        private IAlphaTester _alphaTester;

        public DynamicWallEffectManager(IAlphaTester alphaTester)
        {
            _alphaTester = alphaTester;
        }

        void IDynamicWallEffectManager.AddWallEffect(IDrawable effect, Position3D position)
        {
            _wallEffects.Add(effect);
        }

        void IDrawable.Draw()
        {
            _alphaTester.Begin();

            foreach (IDrawable effect in _wallEffects)
            {
                effect.Draw();
            }
            _alphaTester.End();
        }
    }
}
