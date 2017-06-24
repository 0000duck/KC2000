using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using IOInterface;

namespace ArtificialIntelligence
{
    public class BehaviourMapper : IBehaviourMapper
    {
        Behaviour IBehaviourMapper.MapBehaviour(Behaviour behaviour, MainBodyStatus bodyStatus)
        {
            switch (behaviour)
            {
                case Behaviour.StandardBehaviour:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.StandardBehaviour;
                        case MainBodyStatus.NoHead:
                            return Behaviour.CollapseH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.CollapseT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.CollapseA;
                        case MainBodyStatus.NoLegs:
                            return Behaviour.CollapseL;
                    }
                    break;
                case Behaviour.RotateLeft:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.RotateLeft;
                        case MainBodyStatus.NoHead:
                            return Behaviour.RotateLeftH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.RotateLeftT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.RotateLeftA;
                    }
                    break;
                case Behaviour.RotateRight:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.RotateRight;
                        case MainBodyStatus.NoHead:
                            return Behaviour.RotateRightH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.RotateRightT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.RotateRightA;
                    }
                    break;
                case Behaviour.StepWithLeftFoot:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.StepWithLeftFoot;
                        case MainBodyStatus.NoHead:
                            return Behaviour.StepWithLeftFootH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.StepWithLeftFootT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.StepWithLeftFootA;
                    }
                    break;
                case Behaviour.StepWithRightFoot:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.StepWithRightFoot;
                        case MainBodyStatus.NoHead:
                            return Behaviour.StepWithRightFootH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.StepWithRightFootT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.StepWithRightFootA;
                    }
                    break;
                case Behaviour.Ducked:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.Ducked;
                        case MainBodyStatus.NoHead:
                            return Behaviour.DuckedH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.DuckedT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.DuckedA;
                    }
                    break;
                case Behaviour.Collapse:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.Collapse;
                        case MainBodyStatus.NoHead:
                            return Behaviour.CollapseH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.CollapseT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.CollapseA;
                        case MainBodyStatus.NoLegs:
                            return Behaviour.CollapseL;
                    }
                    break;
                case Behaviour.LyingOnFloor:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.LyingOnFloor;
                        case MainBodyStatus.NoHead:
                            return Behaviour.LyingOnFloorH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.LyingOnFloorT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.LyingOnFloorA;
                        case MainBodyStatus.NoLegs:
                            return Behaviour.LyingOnFloorL;
                    }
                    break;
                case Behaviour.Jump:
                    switch (bodyStatus)
                    {
                        case MainBodyStatus.DeadlyInjured:
                        case MainBodyStatus.FullBody:
                            return Behaviour.Jump;
                        case MainBodyStatus.NoHead:
                            return Behaviour.JumpH;
                        case MainBodyStatus.NoTorso:
                            return Behaviour.JumpT;
                        case MainBodyStatus.NoArms:
                            return Behaviour.JumpA;
                        case MainBodyStatus.NoLegs:
                            return Behaviour.JumpL;
                    }
                    break;
                case Behaviour.Run:
                    return Behaviour.Run;
            }
            return ((IBehaviourMapper)this).MapBehaviour(Behaviour.StandardBehaviour, bodyStatus);
        }
    }
}
