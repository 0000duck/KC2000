using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using FrameworkContracts;

namespace SaveGames.FileAccess
{
    public class FileSerializer : IXmlFileSerializer
    {
        public void SaveFile(string fileName, XDocument xmlFileContent)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            xmlFileContent.Save(fileName);
        }

        public XDocument LoadFile(string fileName)
        {
            if (!File.Exists(fileName))
                return null;

            XDocument file = XDocument.Load(fileName);
            return file;
        }
    }
}
