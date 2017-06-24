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
                case ElementTheme.SoldierShotGun:
                case ElementTheme.SoldierShotGunF:
                case ElementTheme.SoldierShotGunR:
                case ElementTheme.SoldierRocket:
                case ElementTheme.SoldierRocketR:
                case ElementTheme.SoldierRocketF:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.75;
                    physicalAppearance.Weight = 60;
                    physicalAppearance.Height = 1.8;
                    break;
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.SoldierPistolF:
                case ElementTheme.Ninja:
                case ElementTheme.Capitalist1:
                case ElementTheme.Capitalist2:
                case ElementTheme.Capitalist3:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.6;
                    physicalAppearance.Weight = 60;
                    physicalAppearance.Height = 1.8;
                    break;
                case ElementTheme.AutoMG:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 1;
                    physicalAppearance.Weight = 6000;
                    physicalAppearance.Height = 1;
                    break;
                case ElementTheme.SoldierMG:
                case ElementTheme.FlyingSoldierFlameThrower:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 1.5;
                    physicalAppearance.Weight = 200;
                    physicalAppearance.Height = 3.6;
                    break;
                case ElementTheme.Helicopter:
                case ElementTheme.HelicopterMGOnlyB:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 7;
                    physicalAppearance.Weight = 800;
                    physicalAppearance.Height = 3.8;
                    break;
                case ElementTheme.SoldierTank:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 3;
                    physicalAppearance.Weight = 800;
                    physicalAppearance.Height = 3.5;
                    break;
                case ElementTheme.SoldierRobot:
                case ElementTheme.LastRobot:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 2.8;
                    physicalAppearance.Weight = 500;
                    physicalAppearance.Height = 3.95;
                    break;
                case ElementTheme.Dog:
                case ElementTheme.DogF:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.8;
                    physicalAppearance.Weight = 20;
                    physicalAppearance.Height = 0.7;
                    break;
                case ElementTheme.Pistol:
                case ElementTheme.PistolPlaceHolder:
                case ElementTheme.Uzi:
                case ElementTheme.UziPlaceHolder:
                case ElementTheme.Fist:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.3;
                    physicalAppearance.Weight = 0.2;
                    physicalAppearance.Height = 0.15;
                    break;
                case ElementTheme.MG:
                case ElementTheme.MGPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 2;
                    physicalAppearance.Weight = 30;
                    physicalAppearance.Height = 0.2;
                    break;
                case ElementTheme.AtomaticMG:
                case ElementTheme.AtomaticMGPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 2;
                    physicalAppearance.Weight = 50;
                    physicalAppearance.Height = 0.5;
                    break;
                case ElementTheme.ShotGun:
                case ElementTheme.ShotGunPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.5;
                    physicalAppearance.Weight = 0.3;
                    physicalAppearance.Height = 0.15;
                    break;
                case ElementTheme.Rocket:
                case ElementTheme.EnemyRocket:
                case ElementTheme.RocketTriggerer:
                case ElementTheme.RocketPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.15;
                    physicalAppearance.Weight = 3.0;
                    physicalAppearance.Height = 0.15;
                    break;
                case ElementTheme.Grenade:
                case ElementTheme.EnemyGrenade:
                case ElementTheme.GrenadePlaceHolder:
                case ElementTheme.GrenadeTriggerer:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.12;
                    physicalAppearance.Weight = 0.5;
                    physicalAppearance.Height = 0.12;
                    break;
                case ElementTheme.GrenadeLauncher:
                case ElementTheme.GrenadeLauncherPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.4;
                    physicalAppearance.Weight = 10;
                    physicalAppearance.Height = 0.3;
                    break;
                case ElementTheme.RocketThrower:
                case ElementTheme.RocketThrowerPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 1.0;
                    physicalAppearance.Weight = 10;
                    physicalAppearance.Height = 0.40;
                    break;
                case ElementTheme.MGChain:
                case ElementTheme.MGChainPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.4;
                    physicalAppearance.Weight = 0.4;
                    physicalAppearance.Height = 0.2;
                    break;
                case ElementTheme.AtomaticMGChain:
                case ElementTheme.AtomaticMGChainPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.3;
                    physicalAppearance.Weight = 5;
                    physicalAppearance.Height = 0.2;
                    break;
                case ElementTheme.ShotShells:
                case ElementTheme.ShotShellsPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.2;
                    physicalAppearance.Weight = 0.05;
                    physicalAppearance.Height = 0.1;
                    break;
                case ElementTheme.PistolBullets:
                case ElementTheme.PistolBulletPlaceHolder:
                case ElementTheme.UziBullets:
                case ElementTheme.UziBulletPlaceHolder:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.2;
                    physicalAppearance.Weight = 0.1;
                    physicalAppearance.Height = 0.1;
                    break;
                case ElementTheme.MovingTree:
                case ElementTheme.MovingCactus:
                case ElementTheme.MovingPalm:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 1;
                    physicalAppearance.SideLengthY = 1;
                    physicalAppearance.Height = 2;
                    break;
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
                case ElementTheme.GiantSkull:
                case ElementTheme.BloodyPart:
                case ElementTheme.Bowls:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.5;
                    physicalAppearance.Weight = 1.0;
                    physicalAppearance.Height = 0.5;
                    break;
                case ElementTheme.GiantTorso:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 1.2;
                    physicalAppearance.Weight = 1.0;
                    physicalAppearance.Height = 0.7;
                    break;
                case ElementTheme.FlyingBloodMedium:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.5;
                    physicalAppearance.Weight = 1.0;
                    physicalAppearance.Height = 0.5;
                    break;
                case ElementTheme.ExplosiveBox:
                    physicalAppearance.Shape = Shape.Rectangle;
                    physicalAppearance.SideLengthX = 1.0;
                    physicalAppearance.SideLengthY = 1.0;
                    physicalAppearance.Weight = 30.0;
                    physicalAppearance.Height = 1.0;
                    break;
                case ElementTheme.AmmoBox:
                case ElementTheme.RocketBox:
                    physicalAppearance.Shape = Shape.Rectangle;
                    physicalAppearance.SideLengthX = 1;
                    physicalAppearance.SideLengthY = 1;
                    physicalAppearance.Weight = 20.0;
                    physicalAppearance.Height = 1;
                    break;
                case ElementTheme.FireDeleter:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.3;
                    physicalAppearance.Weight = 10.0;
                    physicalAppearance.Height = 1.0;
                    break;
                case ElementTheme.Beer:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.1;
                    physicalAppearance.Weight = 0.8;
                    physicalAppearance.Height = 0.3;
                    break;
                case ElementTheme.FireBall:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.15;
                    physicalAppearance.Weight = 1;
                    physicalAppearance.Height = 0.3;
                    break;
                case ElementTheme.MGPart:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 0.35;
                    physicalAppearance.Weight = 5;
                    physicalAppearance.Height = 0.3;
                    break;
                case ElementTheme.ML1:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 1.6;
                    physicalAppearance.Weight = 200;
                    physicalAppearance.Height = 1.4;
                    break;
                case ElementTheme.ML2:
                case ElementTheme.ML3:
                    physicalAppearance.Shape = Shape.Circle;
                    physicalAppearance.SideLengthX = 1;
                    physicalAppearance.Weight = 200;
                    physicalAppearance.Height = 1.8;
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
