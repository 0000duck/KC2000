using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ArtificialIntelligence.Contracts
{
    public interface ISoundSharer
    {
        bool SoundCanBeHeared(Position3D position);

        bool SoundIsNearEnoughToIdentifyPosition(Position3D position); 
    }
}
