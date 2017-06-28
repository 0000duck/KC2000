using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using ArtificialIntelligence.Contracts;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;
using ArtificialIntelligence;

namespace ThemeMapping.EnemyCreation
{
    public class WeaponLooserFactory : IWeaponLooserFactory
    {
        IDestructionObserver IWeaponLooserFactory.CreateWeaponLooser(ElementTheme character, IWorldElementProvider characterProvider, IElementCreator elementCreator)
        {
            switch(character)
            {
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.SoldierPistolF:
                    return new WeaponLooser(characterProvider, elementCreator,ElementTheme.PistolPlaceHolder);
                default:
               return new EmptyObserver();

            }
        }
    }
}
