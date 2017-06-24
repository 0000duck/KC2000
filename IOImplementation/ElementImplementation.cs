using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;

namespace IOImplementation
{
    public class ElementImplementation : IElement
    {
        public ElementTheme ElementTheme { set; get; }

        public Position3D StartPosition { get; set; }

        public Degree Orientation { set; get; }

        public IInitInformation InitInformation { set; get; }

        public IList<IElement> SubElements { set; get; }

        public IPhysicalParameters Parameters { set; get; }
    }
}
