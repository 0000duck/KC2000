using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace IOInterface
{
    public interface IElement
    {
        ElementTheme ElementTheme { set; get; }

        Position3D StartPosition {set; get;}

        Degree Orientation { set; get; }

        IInitInformation InitInformation { set; get; }

        IList<IElement> SubElements { set; get; }

        IPhysicalParameters Parameters { set; get; }
    }

}
