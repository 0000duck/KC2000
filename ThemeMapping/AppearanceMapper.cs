using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionDetection;
using IOInterface;
using BaseTypes;
using IOImplementation;

namespace ThemeMapping
{
    public class AppearanceMapper
    {
        private static AppearanceMapper Instance = null;

        private AppearanceMapper()
        {

        }

        public static AppearanceMapper GetInstance()
        {
            if (Instance == null)
                Instance = new AppearanceMapper();

            return Instance;
        }

        public IPhysicalParameters GetAppearance(ElementTheme theme)
        {
            IPhysicalParameters physicalAppearance = new PhysicalAppearance();

            switch (theme)
            {
                case ElementTheme.PlayerOne:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.6;
                    physicalAppearance.Weight = 70;
                    physicalAppearance.Height = 1.65;
                    break;
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.SoldierPistolF:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.6;
                    physicalAppearance.Weight = 60;
                    physicalAppearance.Height = 1.8;
                    break;
                case ElementTheme.Dog:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.8;
                    physicalAppearance.Weight = 20;
                    physicalAppearance.Height = 0.7;
                    break;
                case ElementTheme.Pistol:
                case ElementTheme.PistolPlaceHolder:
               
                case ElementTheme.Fist:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.3;
                    physicalAppearance.Weight = 0.2;
                    physicalAppearance.Height = 0.15;
                    break;
                
               
                
                case ElementTheme.PistolBullets:
                case ElementTheme.PistolBulletPlaceHolder:
                
                case ElementTheme.StraightFlyingBloodVerySmall:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.3;
                    physicalAppearance.Weight = 1.0;
                    physicalAppearance.Height = 0.3;
                    break;
                case ElementTheme.StraightFlyingBloodSmall:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.5;
                    physicalAppearance.Weight = 1.0;
                    physicalAppearance.Height = 0.5;
                    break;
                case ElementTheme.FlyingShoe:
                case ElementTheme.Skull:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.25;
                    physicalAppearance.Weight = 1.0;
                    physicalAppearance.Height = 0.2;
                    break;
                case ElementTheme.BloodTorso:
                case ElementTheme.DogBloodTorso:
                case ElementTheme.BloodyPart:
                case ElementTheme.Bowls:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.5;
                    physicalAppearance.Weight = 1.0;
                    physicalAppearance.Height = 0.5;
                    break;
                
                case ElementTheme.FlyingBloodMedium:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.5;
                    physicalAppearance.Weight = 1.0;
                    physicalAppearance.Height = 0.5;
                    break;
               
                case ElementTheme.AmmoBox:
               
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.15;
                    physicalAppearance.Weight = 1;
                    physicalAppearance.Height = 0.3;
                    break;
                
                default:
                    return null;
            }

            if ((int)physicalAppearance.Shape < 1)
                return null;
            return physicalAppearance;
        }
    }
}
