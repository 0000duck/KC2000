using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace BaseTypes
{
    public class ImpulseCollection
    {
        public double ImpulseFromRightToLeft { private set; get; }
        public double ImpulseFromLeftToRight { private set; get; }
        public double ImpulseFromTopToBottom { private set; get; }
        public double ImpulseFromBottomToTop { private set; get; }
        public double ImpulseFromCeilingToFloor { private set; get; }
        public double ImpulseFromFloorToCeiling { private set; get; }

        public bool HasImpulseFromLeftToRight
        {
            get
            {
                return ImpulseFromLeftToRight > 0;
            }
        }

        public bool HasImpulseFromRightToLeft
        {
            get
            {
                return ImpulseFromRightToLeft > 0;
            }
        }

        public bool HasImpulseFromBottomToTop
        {
            get
            {
                return ImpulseFromBottomToTop > 0;
            }
        }

        public bool HasImpulseFromTopToBottom
        {
            get
            {
                return ImpulseFromTopToBottom > 0;
            }
        }

        public bool HasImpulseFromCeilingToFloor
        {
            get
            {
                return ImpulseFromCeilingToFloor > 0;
            }
        }

        public bool HasImpulseFromFloorToCeiling
        {
            get
            {
                return ImpulseFromFloorToCeiling > 0;
            }
        }

        public void AddImpulse(Impulse impulse)
        {
            switch (impulse.ImpulseDirection)
            {
                case Direction.FromLeftToRight:
                    ImpulseFromLeftToRight += impulse.Strength;
                    ImpulseFromRightToLeft -= impulse.Strength;
                    break;
                case Direction.FromRightToLeft:
                    ImpulseFromRightToLeft += impulse.Strength;
                    ImpulseFromLeftToRight -= impulse.Strength;
                    break;
                case Direction.FromTopToBottom:
                    ImpulseFromTopToBottom += impulse.Strength;
                    ImpulseFromBottomToTop -= impulse.Strength;
                    break;
                case Direction.FromBottomToTop:
                    ImpulseFromBottomToTop += impulse.Strength;
                    ImpulseFromTopToBottom -= impulse.Strength;
                    break;
                case Direction.FromCeilingToFloor:
                    ImpulseFromCeilingToFloor += impulse.Strength;
                    ImpulseFromFloorToCeiling -= impulse.Strength;
                    break;
                case Direction.FromFloorToCeiling:
                    ImpulseFromFloorToCeiling += impulse.Strength;
                    ImpulseFromCeilingToFloor -= impulse.Strength;
                    break;
            }
        }

        public Impulse ExtractImpulse(Direction direction)
        {
            Impulse impulse = new Impulse();
            impulse.ImpulseDirection = direction;

            switch (direction)
            {
                case Direction.FromLeftToRight:
                    impulse.Strength = ImpulseFromLeftToRight;
                    ImpulseFromLeftToRight = 0;
                    ImpulseFromRightToLeft = 0;
                    break;
                case Direction.FromRightToLeft:
                    impulse.Strength = ImpulseFromRightToLeft;
                    ImpulseFromRightToLeft = 0;
                    ImpulseFromLeftToRight = 0;
                    break;
                case Direction.FromTopToBottom:
                    impulse.Strength = ImpulseFromTopToBottom;
                    ImpulseFromTopToBottom = 0;
                    ImpulseFromBottomToTop = 0;
                    break;
                case Direction.FromBottomToTop:
                    impulse.Strength = ImpulseFromBottomToTop;
                    ImpulseFromBottomToTop = 0;
                    ImpulseFromTopToBottom = 0;
                    break;
                case Direction.FromCeilingToFloor:
                    impulse.Strength = ImpulseFromCeilingToFloor;
                    ImpulseFromCeilingToFloor = 0;
                    ImpulseFromFloorToCeiling = 0;
                    break;
                case Direction.FromFloorToCeiling:
                    impulse.Strength = ImpulseFromFloorToCeiling;
                    ImpulseFromFloorToCeiling = 0;
                    ImpulseFromCeilingToFloor = 0;
                    break;
            }

            return impulse;
        }
    }
}