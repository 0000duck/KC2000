using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class NoPositionOnRoomFieldModel : ISimpleCollisionModel
    {
        int ISimpleCollisionModel.X
        {
            get { return 0; }
        }

        int ISimpleCollisionModel.Y
        {
            get { return 0; }
        }

        void ISimpleCollisionModel.Update(Position3D position, double sideLengthX, double sideLengthY)
        {
             
        }

        bool ISimpleCollisionModel.EventuallyCollidesWith(ISimpleCollisionModel otherCollisionModel)
        {
            return false;
        }
    }
}
