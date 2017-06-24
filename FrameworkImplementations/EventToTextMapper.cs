using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;
using BaseTypes;
using Sound.Contracts;

namespace FrameworkImplementations
{
    public class EventToTextMapper : IEventToSoundMapper
    {
        private IDrawableList _textList;
        private IPolygonCreator _polygonCreator;
        private ITextureLoader _textureLoader;
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;
        private IWorldRotator _worldRotator;
        private IPlayerCamera _camera;
        private IWorldTranslator _worldTranslator;
        private IScaler _scaler;

        public EventToTextMapper(IDrawableList textList, IPolygonCreator polygonCreator, ITextureLoader textureLoader, ITextureChanger textureChanger,
            IPolygonRenderer polygonRenderer, IWorldRotator worldRotator, IPlayerCamera camera, IWorldTranslator worldTranslator, IScaler scaler)
        {
            _textList = textList;
            _polygonCreator = polygonCreator;
            _textureLoader = textureLoader;
            _textureChanger = textureChanger;
            _camera = camera;
            _polygonRenderer = polygonRenderer;
            _worldRotator = worldRotator;
            _worldTranslator = worldTranslator;
            _scaler = scaler;
        }

        ISound IEventToSoundMapper.GetSound(IOInterface.Events.GameEvent gameEvent)
        {
            ISound sound;

            switch (gameEvent)
            {
                case IOInterface.Events.GameEvent.PlayerHeard:
                    sound = new VaryingVisualSound(new VisualSound[]
                    {
                        new VisualSound(_textureLoader.LoadTexture("Content\\Images\\qm.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(0.25, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                   new VisualSound(_textureLoader.LoadTexture("Content\\Images\\what.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(2, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                        new VisualSound(_textureLoader.LoadTexture("Content\\Images\\hm.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(1, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                        new VisualSound(_textureLoader.LoadTexture("Content\\Images\\qmem.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(1, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                        new VisualSound(_textureLoader.LoadTexture("Content\\Images\\qm.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(0.25, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                   new VisualSound(_textureLoader.LoadTexture("Content\\Images\\wtf.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(1, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) })
                    });
                    break;
                case IOInterface.Events.GameEvent.PlayerOutOfSight:
                    sound = new VaryingVisualSound(new VisualSound[]
                    {
                        new VisualSound(_textureLoader.LoadTexture("Content\\Images\\dotqm.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(1, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                   new VisualSound(_textureLoader.LoadTexture("Content\\Images\\nothing.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(2, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                   new VisualSound(_textureLoader.LoadTexture("Content\\Images\\hmdot.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(1, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                    new VisualSound(_textureLoader.LoadTexture("Content\\Images\\nocontact.png", false),
                        _textureChanger, new List<IParticle> { new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(4, 0.25, true), 1, 0.25, 0, new PercentFader(0.8)) }),
                    });
                    break;
                case IOInterface.Events.GameEvent.ML1:
                case IOInterface.Events.GameEvent.ML2:
                case IOInterface.Events.GameEvent.ML3:
                    sound = new LoopedVisualSound(GetTexture(gameEvent), _textureChanger, GetParticleList(gameEvent, 3), 0.3);
                    break;
                case IOInterface.Events.GameEvent.HelicopterRotor:
                    sound = new LoopedVisualSound(GetTexture(gameEvent), _textureChanger, GetParticleList(gameEvent, 4), 0.16);
                    break;
                default:
                    sound = new VisualSound(GetTexture(gameEvent), _textureChanger, GetParticleList(gameEvent, 5));
                    break;
            }
            _textList.Add(sound as IDrawable);
            return sound;
        }

        private List<IParticle> GetParticleList(IOInterface.Events.GameEvent gameEvent, int numberOfItems)
        {
            List<IParticle> list = new List<IParticle>();

            for (int i = 0; i < numberOfItems; i++)
            {
                list.Add(GetSprite(gameEvent));
            }

            return list;
        }

        private IParticle GetSprite(IOInterface.Events.GameEvent gameEvent)
        {
            switch (gameEvent)
            {
                case IOInterface.Events.GameEvent.RocketSoldier:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(2, 0.25, true), 2, 1, 1, new PercentFader(0.6));
                case IOInterface.Events.GameEvent.Explosion:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(2, 0.5, true), 2, 1, 1.5, new PercentFader(0.6));
                case IOInterface.Events.GameEvent.MGSoldier:
                case IOInterface.Events.GameEvent.UziNinja:
                case IOInterface.Events.GameEvent.FlameThrowerSoldier:
                case IOInterface.Events.GameEvent.AtomicMGSoldier:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(2, 0.25, true), 2, 1, 1.5, new PercentFader(0.3));
                case IOInterface.Events.GameEvent.ML1:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(2, 0.25, true), 1.5, 1.2, 1.9, new PercentFader(0.7));
                case IOInterface.Events.GameEvent.ML2:
                case IOInterface.Events.GameEvent.ML3:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(0.5, 0.5, true), 1.5, 1.2, 1.8, new PercentFader(0.7));
                case IOInterface.Events.GameEvent.DogAttack:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(1, 0.25, true), 1.5, 0.5, 1, new PercentFader(0.5));
                case IOInterface.Events.GameEvent.HelicopterRotor:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(2, 0.5, true), 2, 2.5, 5, new PercentFader(0.5));
                case IOInterface.Events.GameEvent.HelicopterMG:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(2, 0.5, true), 2, -1.5, -1, new PercentFader(0.5));
                default:
                    return new ScalingImageSprite(_camera, _polygonRenderer, _worldRotator, _worldTranslator, _scaler, _polygonCreator.CreatePolygons(1, 0.25, true), 1.5, 1,1, new PercentFader(0.4));
            }
        }

        private ITexture GetTexture(IOInterface.Events.GameEvent gameEvent)
        {
            switch (gameEvent)
            {
                case IOInterface.Events.GameEvent.RocketSoldier:
                    return _textureLoader.LoadTexture("Content\\Images\\zoosh.png", false);
                case IOInterface.Events.GameEvent.DogAttack:
                    return _textureLoader.LoadTexture("Content\\Images\\woof.png", false);
                case IOInterface.Events.GameEvent.MGSoldier:
                case IOInterface.Events.GameEvent.UziNinja:
                case IOInterface.Events.GameEvent.HelicopterMG:
                case IOInterface.Events.GameEvent.AtomicMGSoldier:
                    return _textureLoader.LoadTexture("Content\\Images\\ratta.png", false);
                case IOInterface.Events.GameEvent.FlameThrowerSoldier:
                    return _textureLoader.LoadTexture("Content\\Images\\flame.png", false);
                case IOInterface.Events.GameEvent.Explosion:
                    return _textureLoader.LoadTexture("Content\\Images\\boom.png", false);
                case IOInterface.Events.GameEvent.ML1:
                    return _textureLoader.LoadTexture("Content\\Images\\click.png", false);
                case IOInterface.Events.GameEvent.ML2:
                case IOInterface.Events.GameEvent.ML3:
                    return _textureLoader.LoadTexture("Content\\Images\\note.png", false);
                case IOInterface.Events.GameEvent.HelicopterRotor:
                    return _textureLoader.LoadTexture("Content\\Images\\rofl.png", false);
                case IOInterface.Events.GameEvent.PlayerOutOfSight:
                    return _textureLoader.LoadTexture("Content\\Images\\Ausrufezeichen.png", false);
                default:
                    return _textureLoader.LoadTexture("Content\\Images\\peng.png", false);
            }
        }
    }
}
