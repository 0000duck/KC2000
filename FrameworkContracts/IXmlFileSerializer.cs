using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FrameworkContracts
{
    public interface IXmlFileSerializer
    {
        void SaveFile(string fileName, XDocument xmlFileContent);

        XDocument LoadFile(string fileName);
    }
}
