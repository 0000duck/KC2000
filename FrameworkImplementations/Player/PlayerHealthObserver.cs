using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Player
{
    public class PlayerHealthObserver : IPlayerHealthObserver, IDrawable
    {
        private ICountRenderer _healthRenderer;
        private int _healthPoints;

        public PlayerHealthObserver(ICountRenderer healthRenderer)
        {
            _healthRenderer = healthRenderer;
        }

        void IPlayerHealthObserver.HealthHasChanged(int healthPoints)
        {
            _healthPoints = healthPoints;
        }

        void IDrawable.Draw()
        {
            _healthRenderer.RenderCount(_healthPoints, 0.05, 0.9);
        }
    }
}
