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
                case ElementTheme.Capitalist1:
                case ElementTheme.Capitalist2:
                case ElementTheme.Capitalist3:
                case ElementTheme.Ninja:
                    return new WeaponLooser(characterProvider, elementCreator, ElementTheme.UziPlaceHolder); 
                case ElementTheme.SoldierMG:
                    return new WeaponLooser(characterProvider, elementCreator,ElementTheme.MGPlaceHolder);
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.SoldierPistolF:
                    return new WeaponLooser(characterProvider, elementCreator,ElementTheme.PistolPlaceHolder);
                case ElementTheme.SoldierRocket:
                case ElementTheme.SoldierRocketF:
                case ElementTheme.SoldierRocketR:
                    return new WeaponLooser(characterProvider, elementCreator,ElementTheme.RocketThrowerPlaceHolder);
                case ElementTheme.Dog:
                case ElementTheme.DogF:
                case ElementTheme.FlyingSoldierFlameThrower:
                case ElementTheme.Helicopter:
                case ElementTheme.HelicopterMGOnlyB:
                case ElementTheme.SoldierTank:
                case ElementTheme.LastRobot:
                    return new EmptyObserver();
                case ElementTheme.SoldierRobot:
                    return new WeaponLooser(characterProvider, elementCreator, ElementTheme.AtomaticMGPlaceHolder); 
                case ElementTheme.SoldierShotGun:
                case ElementTheme.SoldierShotGunF:
                case ElementTheme.SoldierShotGunR:
                default:
                    return new WeaponLooser(characterProvider, elementCreator,ElementTheme.ShotGunPlaceHolder); 
            }
        }
    }
}
