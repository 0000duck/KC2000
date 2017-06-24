using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;

namespace GameInteraction.Weapons
{
    public class WeaponManager : IElementGroup, IComplexWeaponFirerer
    {
        private IMultiWeaponRenderer _multiWeaponRenderer;
        private List<WeaponSlot> _weapons;
        private ElementTheme _lowPriorityWeapon;
        private int? _selectedWeapon;
        private int? _desiredWeapon;
        private IWeaponSwitcher _weaponSwitcher;
        private bool _firering;
        private IAmmoPerWeaponCounter _ammoPerWeaponCounter;

        public WeaponManager(IMultiWeaponRenderer multiWeaponRenderer, IAmmoPerWeaponCounter ammoPerWeaponCounter, List<WeaponSlot> emptyWeaponSlots, IWeaponSwitcher weaponSwitcher, ElementTheme lowPriorityWeapon)
        {
            _multiWeaponRenderer = multiWeaponRenderer;
            _ammoPerWeaponCounter = ammoPerWeaponCounter;
            _weapons = emptyWeaponSlots;
            _weaponSwitcher = weaponSwitcher;
            _lowPriorityWeapon = lowPriorityWeapon;
        }

        void IComplexWeaponFirerer.SetInstructions(IWeaponInstructions instructions, Position3D position, VectorWithDegree vector)
        {
            if (_weaponSwitcher.IsSwitching())
            {
                WeaponSwitchResult switchresult = _weaponSwitcher.GetResult();
                _multiWeaponRenderer.Render(switchresult.WeaponTheme, Behaviour.RemoveWeapon, switchresult.Percent);

                if (_desiredWeapon.HasValue)
                {
                    _selectedWeapon = _desiredWeapon.Value;
                    _desiredWeapon = null;
                }

                return;
            }

            if (!_firering)
            {
                SearchForDesiredWeapon(instructions);

                if (_desiredWeapon.HasValue && _desiredWeapon.Value != _selectedWeapon.Value)
                {
                    _weaponSwitcher.StartSwitching(_weapons.ElementAt(_selectedWeapon.Value).WeaponTheme,
                        _weapons.ElementAt(_desiredWeapon.Value).WeaponTheme);

                    //deactivate fire
                    instructions.FiredPressed = false;
                }
            }

            if (!_selectedWeapon.HasValue)
                return;

            WeaponSlot slot = _weapons.ElementAt(_selectedWeapon.Value);
            ComplexWeaponResult result = slot.Weapon.GetWeaponResult(instructions.FiredPressed, position, vector);
            _multiWeaponRenderer.Render(slot.WeaponTheme, result.Behaviour, result.Percent);

            _firering = result.Behaviour == Behaviour.FiredInHand;
        }

        private void SearchForDesiredWeapon(IWeaponInstructions instructions)
        {
            if (instructions.NextWeapon)
            {
                SearchNextHigherWeapon();
            }

            if (instructions.PreviousWeapon)
            {
                SearchNextLowerWeapon();
            }

            if (instructions.Number.HasValue)
            {
                _desiredWeapon = instructions.Number.Value - 1;

                if (instructions.Number.Value == 0)
                    _desiredWeapon = 9;

                if (_desiredWeapon >= _weapons.Count)
                {
                    _desiredWeapon = null;
                }
            }

            if(_desiredWeapon.HasValue && _weapons[_desiredWeapon.Value].Weapon == null)
                _desiredWeapon = null;
        }

        private void SearchNextLowerWeapon()
        {
            _desiredWeapon = _selectedWeapon - 1;

            if (_desiredWeapon < 0)
            {
                _desiredWeapon = _weapons.Count - 1;
            }

            if (_desiredWeapon == null)
                return;

            int searchCounter = 0;
            while (_weapons[_desiredWeapon.Value].Weapon == null || (_ammoPerWeaponCounter.GetAmmoCountOfWeapon(_weapons[_desiredWeapon.Value].WeaponTheme) == 0 && _weapons[_desiredWeapon.Value].WeaponTheme != ElementTheme.Fist))
            {
                _desiredWeapon--;
                searchCounter++;
                if (_desiredWeapon < 0)
                {
                    _desiredWeapon = _weapons.Count - 1;
                }

                if (searchCounter > 10)
                    break;
            }
        }

        private void SearchNextHigherWeapon()
        {
            _desiredWeapon = _selectedWeapon + 1;
            if (_desiredWeapon >= _weapons.Count)
            {
                _desiredWeapon = 0;
            }

            if (_desiredWeapon == null)
                return;

            int searchCounter = 0;
            while (_weapons[_desiredWeapon.Value].Weapon == null || (_ammoPerWeaponCounter.GetAmmoCountOfWeapon(_weapons[_desiredWeapon.Value].WeaponTheme) == 0 && _weapons[_desiredWeapon.Value].WeaponTheme != ElementTheme.Fist))
            {
                _desiredWeapon++;
                searchCounter++;
                if (_desiredWeapon >= _weapons.Count)
                {
                    _desiredWeapon = 0;
                }

                if (searchCounter > 10)
                    break;
            }
        }

        IList<IGroupElement> IElementGroup.Children
        {
            get
            {
                List<IGroupElement> elements = new List<IGroupElement>();
                foreach (WeaponSlot weaponSlot in _weapons)
                {
                    if (weaponSlot.Weapon != null)
                        elements.Add((IGroupElement)weaponSlot.Weapon);
                }
                return elements;
            }
        }

        void IElementGroup.AddChild(IGroupElement child)
        {
            if (child is IComplexWeapon)
            {
                IVisualAppearance appearance = (IVisualAppearance)child;
                WeaponSlot slot = _weapons.Find(x => x.WeaponTheme == appearance.ElementTheme);
                if(slot != null && slot.Weapon == null)
                    slot.Weapon = (IComplexWeapon)child;

                if (!_selectedWeapon.HasValue)
                {
                    SelectFirstWeapon();
                }

                if (_weapons.FindAll(x => x.Weapon != null).Count == 2)
                {
                    WeaponSlot selectedSlot = _weapons.ElementAt(_selectedWeapon.Value);
                    if (selectedSlot.WeaponTheme == _lowPriorityWeapon)
                    {
                        WeaponSlot highPrioWeapon = _weapons.Find(x => x.WeaponTheme != _lowPriorityWeapon && x.Weapon != null);
                        _selectedWeapon = _weapons.IndexOf(highPrioWeapon);
                    }
                }
            }
        }

        private void SelectFirstWeapon()
        {
            WeaponSlot weaponSlot = _weapons.First(x => x.Weapon != null);
            if (weaponSlot != null)
            {
                _selectedWeapon = _weapons.IndexOf(weaponSlot);
            }
        }

        void IElementGroup.RemoveChild(IGroupElement child)
        {
            WeaponSlot slot = _weapons.Find(x => x.Weapon == child);
            if (slot != null)
                slot.Weapon = null;
        }
    }
}
