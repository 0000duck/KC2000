using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public enum Direction : byte
    {
        FromNowhereToNowhere = 0,
        
        FromLeftToRight = 1,

        FromBottomToTop = 3,
        
        FromRightToLeft = 5,
        
        FromTopToBottom = 7,    
        
        FromFloorToCeiling = 9,
        
        FromCeilingToFloor = 11
    }
}
