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
                case ElementTheme.Capitalist1:
                case ElementTheme.Capitalist2:
                case ElementTheme.Capitalist3:
                    return new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.12), DestructionStrength.UziStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(2), Animation.EnemyGunFireShort, 0.3),
                        new FireEventObserverComposition(_flyingShellFactory.CreateFlyingShell(Animation.PistolShellRight), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.UziNinja)))), visibleListProvider, 1.42, 0.2, Degree.Degree_0, destructibleBodyProvider);
                case ElementTheme.SoldierShotGun:
                case ElementTheme.SoldierShotGunF:
                case ElementTheme.SoldierShotGunR:
                    return new SimpleWeaponFirerer(new StrengthLosingWeapon(new UpdateTimer(1.0), DestructionStrength.ShotGunStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(4), Animation.EnemyGunFire, 0.3),
                        1, new FireEventObserverComposition(_flyingShellFactory.CreateFlyingShell(Animation.PistolShellRight), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.ShotGunSoldier)))), visibleListProvider, 1.1, 0.45, Degree.Degree_45, destructibleBodyProvider);
                case ElementTheme.SoldierRocket:
                case ElementTheme.SoldierRocketR:
                case ElementTheme.SoldierRocketF:
                    return new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(2.0), elementCreator, ElementTheme.EnemyRocket, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.RocketSoldier)), 15),
                        visibleListProvider, 1.5, 0.45, Degree.Degree_45, destructibleBodyProvider);
                case ElementTheme.SoldierPistol:
                case ElementTheme.SoldierPistolR:
                case ElementTheme.SoldierPistolF:
                    return new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(1.0), DestructionStrength.PistolStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(4), Animation.EnemyGunFire, 0.6),
                        new FireEventObserverComposition(_flyingShellFactory.CreateFlyingShell(Animation.PistolShellLeft), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.PistolSoldier)))), visibleListProvider, 1.42, 0.2, Degree.Degree_0, destructibleBodyProvider);
                case ElementTheme.FlyingSoldierFlameThrower:
                    return new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(0.2), elementCreator, ElementTheme.FireBall, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.FlameThrowerSoldier)), 12),
                        visibleListProvider, 1.85, 0.25, Degree.Degree_315, destructibleBodyProvider);
                case ElementTheme.SoldierMG:
                    return new DoubleWeaponFirerer(new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.12), DestructionStrength.MachineGunStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(7), Animation.EnemyGunFireShort, 0.5), 
                        new FireEventObserverComposition(_flyingShellFactory.CreateFlyingShell(Animation.PistolShellRight), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.MGSoldier)))), visibleListProvider, 2.3, 0.8, Degree.Degree_45, destructibleBodyProvider)
                        , new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.12), DestructionStrength.MachineGunStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(7), Animation.EnemyGunFireShort, .5), 
                            _flyingShellFactory.CreateFlyingShell(Animation.PistolShellLeft)), visibleListProvider, 2.3, 0.8, Degree.Degree_315, destructibleBodyProvider));
                case ElementTheme.Ninja:
                    return new DoubleWeaponFirerer(new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.12), DestructionStrength.UziStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(10), Animation.EnemyGunFireShort, 0.3), 
                        new FireEventObserverComposition(_flyingShellFactory.CreateFlyingShell(Animation.PistolShellRight), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.UziNinja)))), visibleListProvider, 1.2, 0.45, Degree.Degree_45, destructibleBodyProvider)
                        , new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.12), DestructionStrength.UziStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(10), Animation.EnemyGunFireShort, 0.3), 
                            _flyingShellFactory.CreateFlyingShell(Animation.PistolShellLeft)), visibleListProvider, 1.2, 0.45, Degree.Degree_315, destructibleBodyProvider));
                case ElementTheme.Dog:
                    return new SoundPlayingWeaponFirerer(new SimpleWeaponFirerer(
                        new Weapon(new UpdateTimer(1.0), DestructionStrength.DogStrength, _enemyNearRangeRegistration), 
                            visibleListProvider, 0.4, 0.4, Degree.Degree_0, destructibleBodyProvider), _eventToSoundMapper.GetSound(GameEvent.DogAttack), new UpdateTimer(2.0));
                case ElementTheme.AutoMG:
                    return new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.15), DestructionStrength.AutoMGStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(5), Animation.EnemyGunFireShort, 0.4), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.MGSoldier))), visibleListProvider, 0.3, 0.2, Degree.Degree_0, destructibleBodyProvider);
                case ElementTheme.Helicopter:
                    return new DoubleWeaponFirerer(new DoubleWeaponFirerer(
                        new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(2.0), elementCreator, ElementTheme.EnemyRocket, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.RocketSoldier)), 15),
                        visibleListProvider, 1.2, 2.1, Degree.Degree_45, destructibleBodyProvider)
                        , new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(2.8), elementCreator, ElementTheme.EnemyRocket, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.RocketSoldier)), 15),
                        visibleListProvider, 1.2, 2.1, Degree.Degree_315, destructibleBodyProvider)),
                    new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.15), DestructionStrength.HelicopterMGStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(9), Animation.EnemyGunFireShort, 4), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.HelicopterMG))),
                            visibleListProvider,1, 0.2, Degree.Degree_0, destructibleBodyProvider));
                case ElementTheme.HelicopterMGOnlyB:
                    return new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.15), DestructionStrength.HelicopterMGStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(9), Animation.EnemyGunFireShort, 4), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.HelicopterMG))),
                            visibleListProvider, 1, 0.2, Degree.Degree_0, destructibleBodyProvider);
                case ElementTheme.SoldierRobot:
                    return new DoubleWeaponFirerer(new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.2), DestructionStrength.AtomaticMGStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(7), Animation.EnemyGunFireShort, 0.5),
                        new FireEventObserverComposition(_flyingShellFactory.CreateFlyingShell(Animation.PistolShellRight), new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.AtomicMGSoldier)))), visibleListProvider, 2.3, 1, Degree.Degree_45, destructibleBodyProvider)
                        , new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.2), DestructionStrength.AtomaticMGStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(7), Animation.EnemyGunFireShort, 0.5),
                            _flyingShellFactory.CreateFlyingShell(Animation.PistolShellLeft)), visibleListProvider, 2.3, 1, Degree.Degree_315, destructibleBodyProvider));
                case ElementTheme.LastRobot:
                    return new DoubleWeaponFirerer(
                        new DoubleWeaponFirerer(
                    new DoubleWeaponFirerer(
                        new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(1.4), elementCreator, ElementTheme.EnemyRocket, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.RocketSoldier)), 15),
                        visibleListProvider, 2.3, 1.2, Degree.Degree_45, destructibleBodyProvider)
                        , new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(1.9), elementCreator, ElementTheme.EnemyRocket, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.RocketSoldier)), 15),
                        visibleListProvider, 2.3, 1.2, Degree.Degree_315, destructibleBodyProvider))
                            , new SimpleWeaponFirerer(new NotifyingWeapon(new UpdateTimer(0.15), DestructionStrength.MachineGunStrength, new BulletRegistrationDecorator(_enemyBulletRegistration, _particleManager, new RandomBooleanProvider(5), Animation.EnemyGunFireShort, 0.4),
                                new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.MGSoldier))), visibleListProvider, 3.2, 0.2, Degree.Degree_0, destructibleBodyProvider)),
                                new DoubleWeaponFirerer(
                        new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(0.2), elementCreator, ElementTheme.FireBall, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.FlameThrowerSoldier)), 12),
                        visibleListProvider, 3.1, 1, Degree.Degree_45, destructibleBodyProvider)
                        , new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(0.2), elementCreator, ElementTheme.FireBall, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.FlameThrowerSoldier)), 12),
                        visibleListProvider, 3.1, 1, Degree.Degree_315, destructibleBodyProvider)));
                case ElementTheme.SoldierTank:
                    return new DoubleWeaponFirerer(
                        new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(1.4), elementCreator, ElementTheme.EnemyRocket, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.RocketSoldier)), 15),
                        visibleListProvider, 2, 1.2, Degree.Degree_45, destructibleBodyProvider)
                        , new SimpleWeaponFirerer(new SimpleExplosiveThrower(new UpdateTimer(1.9), elementCreator, ElementTheme.EnemyRocket, new PositionUpdatingSoundPlayer(_eventToSoundMapper.GetSound(GameEvent.RocketSoldier)), 15),
                        visibleListProvider, 2, 1.2, Degree.Degree_315, destructibleBodyProvider));
            }
            return null;
        }
    }
}
