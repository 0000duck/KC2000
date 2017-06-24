using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Profile.Contracts;
using FrameworkContracts;
using System.Xml.Linq;

namespace Profile
{
    public class ProfileAccessor : IProfileSaver, IProfileLoader
    {
        private string _folderPath;
        private string _profileName;
        private IXmlFileSerializer _serializer;

        public ProfileAccessor(string folderPath, string profileName, IXmlFileSerializer serializer)
        {
            _folderPath = folderPath;
            _profileName = profileName;
            _serializer = serializer;
        }

        void IProfileSaver.SaveProfile(ProfileInformation profileInformation)
        {
            if(!profileInformation.NextLevel.HasValue)
                return;

            XDocument saveDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));

            XElement idElement = new XElement("Id");

            XAttribute value = new XAttribute("Value", profileInformation.NextLevel);
            idElement.Add(value);

            XAttribute skill = new XAttribute("Skill", (int)profileInformation.SkillLevel);
            idElement.Add(skill);

            saveDocument.Add(idElement);

            _serializer.SaveFile(_folderPath + "\\" + _profileName + ".xml", saveDocument);
        }

        ProfileInformation IProfileLoader.LoadProfile()
        {
            XDocument document = _serializer.LoadFile(_folderPath + "\\" + _profileName + ".xml");

            if(document == null)
                return new ProfileInformation();

            XElement id = document.Element("Id");

            if (id == null)
                return new ProfileInformation();

            XAttribute idValue = id.Attributes().First(x => x.Name == "Value");
            XAttribute skill = id.Attributes().First(x => x.Name == "Skill");

            int levelId = int.Parse(idValue.Value);

            if(levelId < 0)
                return new ProfileInformation();

            ProfileInformation info = new ProfileInformation
            {
                NextLevel = levelId,
                SkillLevel = (SkillLevel)int.Parse(skill.Value),
            };

            return info;
        }
    }
}
