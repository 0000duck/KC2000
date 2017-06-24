using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;
using GameInteraction.BaseImplementations;
using IOInterface;

namespace GameInteraction.Weapons
{
    public class ComplexWeapon : StandardWorldElement, IElementGroup, IVisualAppearance, IComplexWeapon
    {
        private IElementGroup _elementGroup;
        private IComplexWeapon _complexWeapon;

        public ComplexWeapon(IElementGroup elementGroup, IComplexWeapon complexWeapon)
        {
            _elementGroup = elementGroup;
            _complexWeapon = complexWeapon;
        }

        IList<IGroupElement> IElementGroup.Children
        {
            get { return _elementGroup.Children; }
        }

        void IElementGroup.AddChild(IGroupElement child)
        {
            _elementGroup.AddChild(child);
        }

        void IElementGroup.RemoveChild(IGroupElement child)
        {
            _elementGroup.RemoveChild(child);
        }

        ElementTheme IVisualAppearance.ElementTheme { set; get; }

        Degree IVisualAppearance.Orientation { set; get; }

        bool IVisualAppearance.IsMarked { set; get; }

        ComplexWeaponResult IComplexWeapon.GetWeaponResult(bool fire, Position3D position, VectorWithDegree directionVector)
        {
            return _complexWeapon.GetWeaponResult(fire, position, directionVector);
        }
    }
}
