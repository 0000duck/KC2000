using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using IOInterface;
using GameInteractionContracts;

namespace FrameworkImplementations.Player
{
    public class AmmoCountRenderer : IDrawable, IWeaponThemeObserver
    {
        private Dictionary<ElementTheme, ICountRenderer> _ammoRenderers;
        private double _rightCornerX;
        private ICountRenderer _selectedAmmoMark;
        private ElementTheme _selectedTheme;
        private IAmmoPerWeaponCounter _ammoPerWeaponCounter;

        public AmmoCountRenderer(Dictionary<ElementTheme, ICountRenderer> ammoRenderers, IAmmoPerWeaponCounter ammoPerWeaponCounter, ICountRenderer selectedAmmoMark, double rightCornerX)
        {
            _ammoPerWeaponCounter = ammoPerWeaponCounter;
            _ammoRenderers = ammoRenderers;
            _rightCornerX = rightCornerX;
            _selectedAmmoMark = selectedAmmoMark;
        }

        void IDrawable.Draw()
        {
            double leftCornerX = _rightCornerX - 0.142;
            double markedLeftCornerX =_rightCornerX - 0.158;
            double leftCornerY = 0.7;

            foreach (ElementTheme theme in _ammoRenderers.Keys)
            {
                _ammoRenderers[theme].RenderCount(_ammoPerWeaponCounter.GetAmmoCountOfWeapon(theme), _selectedTheme == theme ? markedLeftCornerX : leftCornerX, leftCornerY);

                leftCornerY -= 0.1;
            }
        }

        void IWeaponThemeObserver.WeaponThemeIsSelected(ElementTheme theme)
        {
            _selectedTheme = theme;
        }
    }
}
