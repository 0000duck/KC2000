using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface.Events;
using Sound.Contracts;
using FrameworkContracts;

namespace FrameworkImplementations
{
    public class EventToSoundAndTextMapper : IEventToSoundMapper
    {
        private ISoundFactory _soundFactory;
        private IEventToSoundMapper _eventToTextMapper;

        public EventToSoundAndTextMapper(ISoundFactory soundFactory, IEventToSoundMapper eventToTextMapper)
        {
            _soundFactory = soundFactory;
            _eventToTextMapper = eventToTextMapper;
        }

        ISound IEventToSoundMapper.GetSound(GameEvent gameEvent)
        {
            ISound sound = null;
            switch (gameEvent)
            {
                case GameEvent.FistPlayer:
                    sound = _soundFactory.LoadSound("Content\\Sound\\Fist.wav", false);
                    break;
                case GameEvent.FistPlayerHit:
                    sound = _soundFactory.LoadSound("Content\\Sound\\FistHit.wav", false);
                    break;
                case GameEvent.GrenadePlayer:
                    sound = _soundFactory.LoadSound("Content\\Sound\\grenade.wav", false);
                    break;
                case GameEvent.PistolShotPlayer:
                    sound = _soundFactory.LoadSound("Content\\Sound\\Pistol.wav", false);
                    break;
                case GameEvent.ShotGunPlayer:
                    sound = _soundFactory.LoadSound("Content\\Sound\\ShotGunPlayer.wav", false);
                    break;
                case GameEvent.RocketPlayer:
                    sound = _soundFactory.LoadSound("Content\\Sound\\rocket.wav", false);
                    break;
                case GameEvent.UziPlayer:
                    sound = _soundFactory.LoadSound("Content\\Sound\\Uzi.wav", false);
                    break;
                case GameEvent.MGPlayer:
                    sound = _soundFactory.LoadSound("Content\\Sound\\MG.wav", false);
                    break;
                case GameEvent.AtomaticMGPlayer:
                    sound = _soundFactory.LoadSound("Content\\Sound\\AtomaticMG.wav", false);
                    break;
                case GameEvent.Explosion:
                    sound = _soundFactory.LoadSound("Content\\Sound\\expl.wav", true);
                    break;
                case GameEvent.PistolSoldier:
                    sound = _soundFactory.LoadSound("Content\\Sound\\Pistol.wav", true);
                    break;
                case GameEvent.ShotGunSoldier:
                    sound = _soundFactory.LoadSound("Content\\Sound\\shotgun.wav", true);
                    break;
                case GameEvent.RocketSoldier:
                    sound = _soundFactory.LoadSound("Content\\Sound\\rocket.wav", true);
                    break;
                case GameEvent.MGSoldier:
                case GameEvent.HelicopterMG:
                    sound = _soundFactory.LoadSound("Content\\Sound\\MG.wav", true);
                    break;
                case GameEvent.DogAttack:
                    sound = _soundFactory.LoadSound("Content\\Sound\\dogbark.wav", true);
                    break;
                case GameEvent.UziNinja:
                    sound = _soundFactory.LoadSound("Content\\Sound\\UziNinja.wav", true);
                    break;
                case GameEvent.FlameThrowerSoldier:
                    sound = _soundFactory.LoadSound("Content\\Sound\\flame.wav", true);
                    break;
                case GameEvent.HelicopterRotor:
                    sound = _soundFactory.LoadSound("Content\\Sound\\helicopter.wav", true, true);
                    break;
                case GameEvent.ML1:
                case GameEvent.ML2:
                case GameEvent.ML3:
                    return _eventToTextMapper.GetSound(gameEvent);
                default:
                    sound = _soundFactory.LoadSound("Content\\Sound\\Pistol.wav", true);
                    break;
            }

            return new SoundComposition(sound, _eventToTextMapper.GetSound(gameEvent));
        }
    }
}