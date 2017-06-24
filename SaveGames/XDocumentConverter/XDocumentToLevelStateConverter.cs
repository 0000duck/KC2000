using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using IOInterface;
using System.Globalization;
using IOImplementation;
using BaseTypes;

namespace SaveGames.XDocumentConverter
{
    public class XDocumentToLevelStateConverter
    {
        private XElementToVisualParameterConverter _xElementToVisualParameterConverter = new XElementToVisualParameterConverter();

        public List<IElement> Convert(XDocument document)
        {
            List<IElement> elements = new List<IElement>();

            elements.AddRange(MapNodesToElements(document.Element("LevelContent").Elements("Element")));

            return elements;
        }

        private IEnumerable<IElement> MapNodesToElements(IEnumerable<XElement> list)
        {
            List<IElement> elements = new List<IElement>();

            foreach (XElement element in list)
            {
                elements.Add(MapNodeToElement(element));
            }

            return elements;
        }

        private IElement MapNodeToElement(XElement xElement)
        {
            IElement element = new ElementImplementation();

            ParseAttributes(xElement, element);

            element.InitInformation = new InitInformation();

            ParseInitInformation(xElement, element.InitInformation);
            
            XElement visualParameters = xElement.Element("VP");

            if (visualParameters != null)
                element.Parameters = _xElementToVisualParameterConverter.ConvertVisualParameters(visualParameters);

            element.SubElements = new List<IElement>();
            foreach (XElement subElement in xElement.Elements("Element"))
            {
                element.SubElements.Add(MapNodeToElement(subElement));
            }

            return element;
        }

        private void ParseInitInformation(XElement xElement, IInitInformation initInformation)
        {
            initInformation.InitValues = new List<IInitValue>();

            foreach (XElement initNode in xElement.Elements("Init"))
            {
                XAttribute value = initNode.Attribute("Value");
                XAttribute identifier = initNode.Attribute("Id"); 

                int id = 0;
                int.TryParse(identifier.Value, out id);

                IInitValue initValue = new InitValue
                {
                    Identifier = id,
                    Value = value.Value
                };

                initInformation.InitValues.Add(initValue);
            }
        }

        private void ParseAttributes(XElement xElement, IElement element)
        {
            XAttribute theme = xElement.Attribute("Theme");
            XAttribute orientation = xElement.Attribute("Orientation");

            Degree degree = Degree.Degree_0;
            Enum.TryParse(orientation.Value, out degree);

            ElementTheme elementTheme = ElementTheme.Undefined;
            Enum.TryParse(theme.Value, out elementTheme);

            element.ElementTheme = elementTheme;
            element.Orientation = degree;

            XAttribute positionX = xElement.Attribute("PosX");
            XAttribute positionY = xElement.Attribute("PosY");
            XAttribute positionZ = xElement.Attribute("PosZ");

            double posX = 0;
            double.TryParse(positionX.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out posX);

            double posY = 0;
            double.TryParse(positionY.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out posY);

            double posZ = 0;
            double.TryParse(positionZ.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out posZ);

            element.StartPosition = new BaseTypes.Position3D
            {
                PositionX = posX,
                PositionY = posY,
                PositionZ = posZ
            };
        }
    }
}
