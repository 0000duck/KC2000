using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using System.Xml.Linq;
using System.Globalization;
using FrameworkContracts;

namespace SaveGames.XDocumentConverter
{
    public class LevelStateToXDocumentConverter
    {
        private VisualParameterToXElementConverter _visualParameterToXElementConverter = new VisualParameterToXElementConverter();

        public XDocument Convert(IEnumerable<IElement> elements)
        {
            XDocument saveDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));

            saveDocument.Add(new XElement("LevelContent", MapElementsToNodes(elements)));

            return saveDocument;
        }

        private XElement[] MapElementsToNodes(IEnumerable<IElement> list)
        {
            List<XElement> elements = new List<XElement>();
            foreach (IElement element in list)
            {
                elements.Add(MapElementToNode(element));
            }
            return elements.ToArray();
        }

        private XElement MapElementToNode(IElement element)
        {
            XElement xElement = new XElement("Element");

            AddAttributesToElement(xElement, element);

            if(element.InitInformation != null)
                AddInitInformationToElement(xElement, element.InitInformation);

            if (element.Parameters != null && element.Parameters is IVisualParameters)
                _visualParameterToXElementConverter.AddVisualParameters(xElement, element.Parameters as IVisualParameters);

            if(element.SubElements == null)
                return xElement;

            foreach(IElement subElement in element.SubElements)
            {
                xElement.Add(MapElementToNode(subElement));
            }

            return xElement;
        }

        private void AddInitInformationToElement(XElement xElement, IInitInformation initInformation)
        {
            foreach(IInitValue initValue in initInformation.InitValues)
            {
                XElement xInitValue = new XElement("Init");

                XAttribute value = new XAttribute("Value", initValue.Value);
                XAttribute identifier = new XAttribute("Id", initValue.Identifier.ToString(CultureInfo.InvariantCulture));

                xInitValue.Add(value);
                xInitValue.Add(identifier);

                xElement.Add(xInitValue);
            }
        }

        private void AddAttributesToElement(XElement xElement, IElement element)
        {
            XAttribute theme = new XAttribute("Theme", element.ElementTheme);
            XAttribute orientation = new XAttribute("Orientation", element.Orientation);
            XAttribute positionX = new XAttribute("PosX", element.StartPosition.PositionX.ToString(CultureInfo.InvariantCulture));
            XAttribute positionY = new XAttribute("PosY", element.StartPosition.PositionY.ToString(CultureInfo.InvariantCulture));
            XAttribute positionZ = new XAttribute("PosZ", element.StartPosition.PositionZ.ToString(CultureInfo.InvariantCulture));

            xElement.Add(theme);
            xElement.Add(orientation);
            xElement.Add(positionX);
            xElement.Add(positionY);
            xElement.Add(positionZ);
        }
    }
}
