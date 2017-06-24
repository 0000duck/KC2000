using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using BaseContracts;

namespace GameInteractionContracts
{
    public enum WeaponCommand
    {
        Undefined = 0,
        Activate = 1,
        Deactivate = 2
    }

    public enum FireBehaviour
    {
        Undefined = 0,
        FireOnActivation = 1,
        FireOnDeactivation = 2
    }

    public enum DropBehaviour
    {
        Undefined = 0,
        DropWeaponAndAmmo = 1,
        DropOnlyAmmo = 2
    }

    public struct WeaponResult
    {
        public bool NoAmmo { get; set; }

        public bool NoSpace { get; set; }

        public double PercentageOfAnimation { set; get; }

        public WeaponActivity WeaponActivity { set; get; }
    }

    public interface IWeapon
    {
        ElementTheme ElementTheme { get; }

        ElementTheme AmmoTheme { get; }

        List<IAmmo> MyAmmo { get; }

        bool WeaponIsActive { get; }

        Position3D Position { get; }

        int CompleteAmmoCount { get; }

        void AddAmmo(IAmmo ammo);

        void SetWeaponOwnerSpecificValues(IWorldElement weaponOwner);

        WeaponResult ProcessCommand(WeaponCommand weaponCommand, Position3D position, VectorWithDegree directionVector, bool infiniteAmmo, TestQuality testQuality,IListProvider<IWorldElement> customicedListProvider);

        bool Collectable { get; }
    }
}
