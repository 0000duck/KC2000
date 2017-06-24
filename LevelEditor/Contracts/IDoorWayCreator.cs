using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace LevelEditor.Contracts
{
    public interface IDoorWayCreator
    {
        void CreateDoorWay(double totalLength, Position3D position);
    }
}
