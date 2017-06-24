using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using IOInterface;
using Render.Contracts;

namespace DrawableElements
{
    public class MultiWeaponRenderer : IDrawable, IMultiWeaponRenderer
    {
        private Dictionary<ElementTheme, IWeaponRenderer> _weapons;
        private ElementTheme _theme;
        private Behaviour _behaviour;
        private double _percent;
        private IWorldTranslator _worldTranslator;
        private IWeaponThemeObserver _weaponThemeObserver;

        public MultiWeaponRenderer(Dictionary<ElementTheme, IWeaponRenderer> weapons, IWorldTranslator worldTranslator, IWeaponThemeObserver weaponThemeObserver)
        {
            _weapons = weapons;
            _worldTranslator = worldTranslator;
            _weaponThemeObserver = weaponThemeObserver;
        }

        void IMultiWeaponRenderer.Render(ElementTheme weaponTheme, Behaviour behaviour, double percent)
        {
            if (_theme != weaponTheme)
                _weaponThemeObserver.WeaponThemeIsSelected(weaponTheme);

            _theme = weaponTheme;
            _behaviour = behaviour;
            _percent = percent;
        }

        void IDrawable.Draw()
        {
            if (_theme == ElementTheme.Undefined)
                return;

            if (_behaviour == Behaviour.RemoveWeapon)
            {
                _worldTranslator.Store();
                _worldTranslator.TranslateWorld(0, _percent / -2.0, 0);
                _weapons[_theme].Draw(Behaviour.HeldInHand, _percent);
                _worldTranslator.Reset();
            }
            else
            {
                _weapons[_theme].Draw(_behaviour, _percent);
            }
        }
    }
}
