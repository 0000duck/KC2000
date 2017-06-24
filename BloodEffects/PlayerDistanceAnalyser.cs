using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;

namespace BloodEffects
{
    public class PlayerDistanceAnalyser : IPlayerDistanceAnalyser
    {
        private Position3D _spritePosition;
        private IWorldElementProvider _playerProvider;
        private double _squareDistanceVeryFar = 800;
        private double _squareDistanceFar = 200;    
        private double _squareDistanceNear = 50;

        public PlayerDistanceAnalyser(Position3D spritePosition, IWorldElementProvider playerProvider)
        {
            _spritePosition = spritePosition.Clone();

            _spritePosition.PositionY = spritePosition.PositionZ;
            _spritePosition.PositionZ = spritePosition.PositionY;

            _playerProvider = playerProvider;
        }

        Distance IPlayerDistanceAnalyser.GetPlayerDistance()
        {
            IWorldElement player = _playerProvider.GetElement();

            DistanceBetweenTwoPositions distance = new DistanceBetweenTwoPositions(player.Position, _spritePosition);

            if (distance.SquareDistanceX > _squareDistanceVeryFar || distance.SquareDistanceY > _squareDistanceVeryFar)
                return Distance.VeryFar;

            if (distance.SquareDistanceX > _squareDistanceFar || distance.SquareDistanceY > _squareDistanceFar)
                return Distance.Far;

            if (distance.SquareDistanceX > _squareDistanceNear || distance.SquareDistanceY > _squareDistanceNear)
                return Distance.Near;

            return Distance.VeryNear;
        }
    }
}
