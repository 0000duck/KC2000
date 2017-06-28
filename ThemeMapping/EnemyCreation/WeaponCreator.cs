using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemeMapping.Contracts;
using IOInterface;
using ArtificialIntelligence.Contracts;
using BaseContracts;
using BaseTypes;
using GameInteractionContracts;
using ArtificialIntelligence;
using ElementImplementations.WeaponImplementations;
using IOInterface.Events;
using GameInteraction.Weapons;
using FrameworkContracts;
using GameInteraction;
using ElementImplementations;

namespace ThemeMapping.EnemyCreation
{
    public class WeaponCreator : IWeaponFirererBuilder
    {
        private IDestructionRegistration _enemyBulletRegistration;
        private IDestructionRegistration _enemyNearRangeRegistration;
        private IEventToSoundMapper _eventToSoundMapper;
        private IParticleManager _particleManager;
        private IFlyingShellFactory _flyingShellFactory;
        

        public WeaponCreator(IDestructionRegistration enemyBulletRegistration, IDestructionRegistration enemyNearRangeRegistration, IEventToSoundMapper eventToSoundMapper,
            IParticleManager particleManager, IFlyingShellFactory flyingShellFactory)
        {
            _enemyBulletRegistration = enemyBulletRegistration;
            _enemyNearRangeRegistration = enemyNearRangeRegistration;
            _eventToSoundMapper = eventToSoundMapper;
            _particleManager = particleManager;
            _flyingShellFactory = flyingShellFactory;
        }

        IWeaponFirerer IWeaponFirererBuilder.CreateWeapon(ElementTheme characterTheme, IListProvider<IWorldElement> visibleListProvider, IElementCreator elementCreator, IDestructibleBodyProvider destructibleBodyProvider)
        {
            switch (characterTheme)
            {
               
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.SoldierPistolF:
                    return new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(1.0), DestructionStrength.PistolStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(4), Animation.EnemyGunFire, 0.6),
                        new FireEventObserverComposition(_flyingShellFactory.CreateFlyingShell(Animation.PistolShellLeft), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.PistolSoldier)))), visibleListProvider, 1.42, 0.2, Degree.Degree_0, destructibleBodyProvider);

                case ElementTheme.Dog:
                    return new SoundPlayingWeaponFirerer(new SimpleWeaponFirerer(
                        new Weapon(new UpdateTimer(1.0), DestructionStrength.DogStrength, _enemyNearRangeRegistration), 
                            visibleListProvider, 0.4, 0.4, Degree.Degree_0, destructibleBodyProvider), _eventToSoundMapper.GetSound(GameEvent.DogAttack), new UpdateTimer(2.0));
            }
            return null;
        }
    }
}
