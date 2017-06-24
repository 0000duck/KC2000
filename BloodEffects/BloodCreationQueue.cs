using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;
using GameInteractionContracts;
using BloodEffects.Contracts;

namespace BloodEffects
{
    public class BloodCreationQueue : IWallEffectQueue, IExecuteble
    {
        private IDynamicWallEffectManager _dynamicWallEffectManager;
        private IBloodAnimationSpriteFactory _bloodAnimationSpriteFactory;
        private List<QueuedWallEffect> _queuedWallEffects;

        public BloodCreationQueue(IDynamicWallEffectManager dynamicWallEffectManager, IBloodAnimationSpriteFactory bloodAnimationSpriteFactory)
        {
            _dynamicWallEffectManager = dynamicWallEffectManager;
            _bloodAnimationSpriteFactory = bloodAnimationSpriteFactory;
            _queuedWallEffects = new List<QueuedWallEffect>();
        }

        void IWallEffectQueue.QueueWallEffect(WallSpriteAnimationParameters wallSpriteAnimationParameters, IWorldElement wall, List<IWorldElement> allWalls, Position3D bloodCenterPosition)
        {
            _queuedWallEffects.Add(new QueuedWallEffect 
            { 
                BloodCenterPosition = bloodCenterPosition,
                Wall = wall,
                AllWalls = allWalls,
                WallSpriteAnimationParameters = wallSpriteAnimationParameters
            });
        }

        void IExecuteble.ExecuteLogic()
        {
            CreateBloodEffect();
            CreateBloodEffect();
            CreateBloodEffect();
        }

        private void CreateBloodEffect()
        {
            if (_queuedWallEffects.Count < 1)
                return;

            QueuedWallEffect queuedWallEffect = _queuedWallEffects.First();
            IDrawable sprite = _bloodAnimationSpriteFactory.CreateBloodSprite(queuedWallEffect.WallSpriteAnimationParameters);
            _dynamicWallEffectManager.AddWallEffect(sprite, queuedWallEffect.WallSpriteAnimationParameters.SpriteCenterPosition);
            _queuedWallEffects.RemoveAt(0);
        }
    }
}
