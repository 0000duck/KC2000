using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public interface IAnimationInstructionProvider
    {
        AnimationInstruction GetInstructions(bool collisionWithWorld, Position3D position);
    }
}
