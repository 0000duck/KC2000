using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using DrawableElements;
using Render.Contracts;

namespace DrawableElements
{
    public class ParticleFactory : IParticleFactory
    {
        private IAnimationLoader _animationLoader;
        private IPlayerCamera _camera;
        private IResolutionToSizeMapper _resolutionToSizeMapper;
        private string _animationPath;
        private ITextureChanger _textureChanger;
        private IWorldTranslator _worldTranslator;
        private IPolygonRenderer _polygonRenderer;
        private IWorldRotator _worldRotator;
        private IPolygonCreator _polygonCreator;

        public ParticleFactory(IAnimationLoader animationLoader, ITextureChanger textureChanger, IPlayerCamera camera,
            IResolutionToSizeMapper resolutionToSizeMapper, string animationPath, IWorldTranslator worldTranslator, IPolygonRenderer polygonRenderer,
            IWorldRotator worldRotator, IPolygonCreator polygonCreator)
        {
            _animationLoader = animationLoader;
            _camera = camera;
            _resolutionToSizeMapper = resolutionToSizeMapper;
            _animationPath = animationPath;
            _textureChanger = textureChanger;
            _worldTranslator = worldTranslator;
            _polygonRenderer = polygonRenderer;
            _worldRotator = worldRotator;
            _polygonCreator = polygonCreator;
        }

        IAnimationParticle IParticleFactory.CreateParticle(IOInterface.Animation animation)
        {
            IAnimation particleAnimation = null;
            if (animation == IOInterface.Animation.EnemyGunFireShort)
                particleAnimation = _animationLoader.LoadAnimation(_animationPath + "\\" + IOInterface.Animation.EnemyGunFire.ToString());
            else if (animation == IOInterface.Animation.PistolShellRight)
                particleAnimation = _animationLoader.LoadAnimation(_animationPath + "\\" + IOInterface.Animation.PistolShellLeft.ToString());
            else
                particleAnimation = _animationLoader.LoadAnimation(_animationPath + "\\" + animation.ToString());

            IAnimationImage texture = particleAnimation.GetFirstImage();

            IDrawable sprite; 

            switch (animation)
            {
                case IOInterface.Animation.GunFire:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), true));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.2,  _worldTranslator);
                case IOInterface.Animation.EnemyGunFire:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), true));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.2,  _worldTranslator);
                case IOInterface.Animation.EnemyGunFireShort:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), true));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.08, _worldTranslator);
                case IOInterface.Animation.Dust:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), false));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.3,  _worldTranslator);
                case IOInterface.Animation.FistDust:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX) / 2.0, _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY) / 2.0, false));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.3, _worldTranslator);
                case IOInterface.Animation.SmallBodyExplosion:
                case IOInterface.Animation.MediumBodyExplosion:
                case IOInterface.Animation.BigBodyExplosion:
                case IOInterface.Animation.Smoke:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), true));
                     return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.4,  _worldTranslator);
                case IOInterface.Animation.VerySmallBodyExplosion:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), true));
                     return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.2,  _worldTranslator);
                case IOInterface.Animation.Explosion:
                case IOInterface.Animation.ExplosionSmall:
                     sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator,
                         _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX) * 2, _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY) * 2, true));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.9,  _worldTranslator);
                case IOInterface.Animation.WoodExplosionSmall:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), true));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.2,  _worldTranslator);
                case IOInterface.Animation.WoodExplosionBig:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), false));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.5,  _worldTranslator);
                case IOInterface.Animation.Glass:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), false));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.4,  _worldTranslator);
                case IOInterface.Animation.WaterParticle:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), false));
                    return new Particle(animation, _textureChanger, particleAnimation, sprite, 0.4,  _worldTranslator);
                case IOInterface.Animation.PistolShellLeft:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), false));
                    return new CurveFlyingParticle(animation, _textureChanger, particleAnimation, sprite, 0.5, _worldTranslator);
                case IOInterface.Animation.PistolShellRight:
                    sprite = new SimpleRotatingSprite(_camera, _polygonRenderer, _worldRotator, _polygonCreator.CreatePolygons(_resolutionToSizeMapper.GetSize(texture.Texture.ResolutionX), _resolutionToSizeMapper.GetSize(texture.Texture.ResolutionY), false, true));
                    return new CurveFlyingParticle(animation, _textureChanger, particleAnimation, sprite, 0.5, _worldTranslator);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
