using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using BaseContracts;

namespace CollisionDetection
{
    public class CollisionProtocol : ICollisionProtocol
    {
        #region public properties
        public bool IsCollisionLeft { get; set; }

        public bool IsCollisionRight { get; set; }

        public bool IsCollisionTop { get; private set; }

        public bool IsCollisionBottom { get; private set; }

        public bool IsCollisionFloor { get; private set; }

        public bool IsCollisionCeiling { get; private set; }

        public bool IsCollisionWithMoreThanTwoSides
        {
            get 
            { 
                int counter = 0;
                counter += IsCollisionLeft ? 1 : 0;
                counter += IsCollisionRight ? 1 : 0;
                counter += IsCollisionTop ? 1 : 0;
                counter += IsCollisionBottom ? 1 : 0;

                return counter > 2;
            }
        }

        public bool IsCollisionInCorner
        {
            get
            {
                return (IsCollisionLeft && IsCollisionBottom) ||
                    (IsCollisionLeft && IsCollisionTop) ||
                    (IsCollisionRight && IsCollisionBottom) ||
                    (IsCollisionRight && IsCollisionTop);
            }
        }
        #endregion

        #region public methods
        public void SetCollisionInformation(Direction direction)
        {
            switch (direction)
            {
                case Direction.FromLeftToRight:
                    IsCollisionRight = true;
                    return;
                case Direction.FromRightToLeft:
                    IsCollisionLeft = true;
                    return;
                case Direction.FromTopToBottom:
                    IsCollisionBottom = true;
                    return;
                case Direction.FromBottomToTop:
                    IsCollisionTop = true;
                    return;
                case Direction.FromCeilingToFloor:
                    IsCollisionFloor = true;
                    return;
                case Direction.FromFloorToCeiling:
                    IsCollisionCeiling = true;
                    return;
            }
        }

        public void Reset()
        {
            IsCollisionRight = false;
            IsCollisionLeft = false;
            IsCollisionBottom = false;
            IsCollisionTop = false;
            IsCollisionFloor = false;
            IsCollisionCeiling = false;  
        }

        public bool IsThereAnyHorizontalCollision
        {
             get
             { 
                 return IsCollisionLeft||IsCollisionRight||IsCollisionTop||IsCollisionBottom;
             }
        }

        public bool IsThereAnyCollision
        {
            get
            {
                return IsCollisionLeft || IsCollisionRight || IsCollisionTop || IsCollisionBottom || IsCollisionCeiling || IsCollisionFloor;
            }
        }
        #endregion
    }
}
