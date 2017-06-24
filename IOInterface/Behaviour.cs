using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOInterface
{
    public enum Behaviour
    {
        StandardBehaviour,
        StandardBehaviourH,
        StandardBehaviourT,
        StandardBehaviourLe,
        StandardBehaviourA,

        LyingOnFloor,
        LyingOnFloorH,
        LyingOnFloorT,
        LyingOnFloorL,
        LyingOnFloorA,

        StepWithLeftFoot,
        StepWithLeftFootH,
        StepWithLeftFootT,
        StepWithLeftFootA,

        StepWithRightFoot,
        StepWithRightFootH,
        StepWithRightFootT,
        StepWithRightFootA,

        RotateLeft,
        RotateLeftH,
        RotateLeftT,
        RotateLeftA,

        RotateRight,
        RotateRightH,
        RotateRightT,
        RotateRightA,

        Ducked,
        DuckedH,
        DuckedT,
        DuckedA,

        Collapse,
        CollapseH,
        CollapseT,
        CollapseA,
        CollapseL,

        HeldInHand,

        FiredInHand,

        LoadedInHand,

        RemoveWeapon,

        Sliding,

        Run,
        Jump,
        JumpH,
        JumpT,
        JumpA,
        JumpL
    }
}
