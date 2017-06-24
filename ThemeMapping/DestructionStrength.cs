using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThemeMapping
{
    public static class DestructionStrength
    {
        public static int PlayerStrengthToEnemyWeaponFactor = 3;

        //enemy weapons
        public static int PistolStrength = 6 * PlayerStrengthToEnemyWeaponFactor;
        public static int ShotGunStrength = 24 * PlayerStrengthToEnemyWeaponFactor;
        public static int MachineGunStrength = 4 * PlayerStrengthToEnemyWeaponFactor;
        public static int UziStrength = 3 * PlayerStrengthToEnemyWeaponFactor;
        public static int AutoMGStrength = 9 * PlayerStrengthToEnemyWeaponFactor;
        public static int HelicopterMGStrength = 6 * PlayerStrengthToEnemyWeaponFactor;
        public static int DogStrength = 16 * PlayerStrengthToEnemyWeaponFactor;
        public static int FlameStrength = 10 * PlayerStrengthToEnemyWeaponFactor;
        public static int EnemyRocketStrength = 40 * PlayerStrengthToEnemyWeaponFactor;
        public static int AtomaticMGStrength = 8 * PlayerStrengthToEnemyWeaponFactor;

        //enemies
        public static int PistolSoldierHead = 20;
        public static int PistolSoldierArms = 20;
        public static int PistolSoldierTorso = 50;
        public static int PistolSoldierLegs = 50;

        public static int ShotGunSoldierHead = 30;
        public static int ShotGunSoldierArms = 40;
        public static int ShotGunSoldierTorso = 55;
        public static int ShotGunSoldierLegs = 55;

        public static int RocketSoldierHead = 50;
        public static int RocketSoldierArms = 60;
        public static int RocketSoldierTorso = 90;
        public static int RocketSoldierLegs = 90;

        public static int MGPart = 100;

        public static int DogHead = 40;
        public static int DogLegs = 80;

        public static int GiantHead = 300;
        public static int GiantTorso = 600;
        public static int GiantLegs = 500;

        public static int FlyGiantHead = 350;
        public static int FlyGiantTorso = 700;
        public static int FlyGiantBoard = 500;
        public static int FlyGiantGas = 200;

        public static int HeliHead = 1200;
        public static int HeliTorso = 1400;
        public static int HeliArms = 1400;

        public static int TankHead = 1400;
        public static int TankTorso = 1600;
        public static int TankLegs = 2000;

        public static int RobotLegs = 2000;
        public static int RobotHead = 1500;
        public static int RobotTorso = 1600;
        public static int RobotArm = 2000;

        public static int LastRobotLegs = 6000;
        public static int LastRobotTorso = 6000;
        public static int LastRobotHead = 5000;

        public static int CapitalistHead = 160;
        public static int CapitalistTorso = 250;
        public static int CapitalistLegs = 300;
        public static int CapitalistArms = 200;

        public static int DogExplosionResistibility = 70;
        public static int MGExplosionResistibility = 100;
        public static int StandardSoldierExplosionResistibility = 100;
        public static int GiantExplosionResistibility = 500;
        public static int HelicopterExplosionResistibility = 500;

        public static int GiantSelfExplosion = 900;
        public static int HelicopterSelfExplosion = 900;

        //player weapons
        public static int PlayerFistStrength = 8;
        public static int PlayerPistolStrength = 10;
        public static int PlayerShotGunStrength = 60;
        public static int PlayerMachineGunStrength = 20;
        public static int PlayerUziStrength = 15;
        public static int PlayerAtomaticMGStrength = 90;
        public static int PlayerGrenadeStrength = 450;
        public static int PlayerRocketStrength = 370; 
    }
}
