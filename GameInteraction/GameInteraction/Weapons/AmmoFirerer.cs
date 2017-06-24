using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;
using IOInterface.Events;

namespace GameInteraction.Weapons
{
    public class AmmoFirerer : IComplexAmmo, IElementGroup
    {
        private List<IComplexAmmo> _ammo = new List<IComplexAmmo>();

        public AmmoFirerer()
        {
        }

        AmmoFireResult IComplexAmmo.Fire(Position3D position, VectorWithDegree directionVector)
        {
            if (!_ammo.Any())
                return AmmoFireResult.OutOfAmmo;

            IComplexAmmo ammo = _ammo.First();

            if (ammo == null)
                return AmmoFireResult.OutOfAmmo;

            AmmoFireResult result = ammo.Fire(position, directionVector);

            if (result == AmmoFireResult.OutOfAmmo)
                _ammo.RemoveAt(0);

            return result;
        }

        IList<IGroupElement> IElementGroup.Children
        {
            get
            {
                List<IGroupElement> elements = new List<IGroupElement>();
                foreach (IComplexAmmo ammo in _ammo)
                {
                    elements.Add((IGroupElement)ammo);
                }
                return elements;
            }
        }

        void IElementGroup.AddChild(IGroupElement child)
        {
            if (child is IComplexAmmo)
                _ammo.Add((IComplexAmmo)child);
        }

        void IElementGroup.RemoveChild(IGroupElement child)
        {
            if (child is IComplexAmmo && _ammo.Contains((IComplexAmmo)child))
                _ammo.Remove((IComplexAmmo)child);
        }

        int IComplexAmmo.Count
        {
            get 
            {
                return _ammo.Sum(x=>x.Count);
            }
        }
    }
}
