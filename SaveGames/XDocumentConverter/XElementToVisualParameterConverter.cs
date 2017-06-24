using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using System.Xml.Linq;
using System.Globalization;

namespace SaveGames.XDocumentConverter
{
    public class XElementToVisualParameterConverter
    {
        public IVisualParameters ConvertVisualParameters(XElement vpElement)
        {
            IVisualParameters visualParameters = new VisualParameters();

            XElement bottom = vpElement.Element("bo");
            if (bottom != null)
                visualParameters.Bottom = ConvertElementToSide(bottom);

            XElement top = vpElement.Element("to");
            if (top != null)
                visualParameters.Top = ConvertElementToSide(top);

            XElement nx = vpElement.Element("nx");
            if (nx != null)
                visualParameters.NegativeX = ConvertElementToSide(nx);

            XElement px = vpElement.Element("px");
            if (px != null)
                visualParameters.PositiveX = ConvertElementToSide(px);

            XElement nz = vpElement.Element("nz");
            if (nz != null)
                visualParameters.NegativeZ = ConvertElementToSide(nz);

            XElement pz = vpElement.Element("pz");
            if (pz != null)
                visualParameters.PositiveZ = ConvertElementToSide(pz);

            AddPhysicalParameters(visualParameters, vpElement);

            return visualParameters;
        }

        private void AddPhysicalParameters(IVisualParameters visualParameters, XElement vpElement)
        {
            XAttribute textureFolder = vpElement.Attribute("tf");
            visualParameters.TextureFolder = textureFolder.Value;

            XAttribute isAnimation = vpElement.Attribute("ia");
            if (isAnimation != null)
            visualParameters.IsAnimation = isAnimation.Value.Equals("1");

            XAttribute animationDuration = vpElement.Attribute("ad");
            if (animationDuration != null)
                visualParameters.AnimationDurationPerImage = double.Parse(animationDuration.Value, NumberStyles.Float, CultureInfo.InvariantCulture);

            XAttribute texcoordDirection = vpElement.Attribute("tcd");
            if (texcoordDirection != null)
            {   TextureCoordinateDirection tcd;
                if(Enum.TryParse(texcoordDirection.Value, true, out tcd))
                    visualParameters.TextureCoordinateDirection = tcd;
            }
            XAttribute shape = vpElement.Attribute("sh");
            visualParameters.Shape = shape.Value.Equals("C") ? BaseTypes.Shape.Circle : BaseTypes.Shape.Rectangle;

            XAttribute height = vpElement.Attribute("he");
            visualParameters.Height = double.Parse(height.Value, NumberStyles.Float, CultureInfo.InvariantCulture);

            XAttribute lengthX = vpElement.Attribute("lx");
            visualParameters.SideLengthX = double.Parse(lengthX.Value, NumberStyles.Float, CultureInfo.InvariantCulture);

            XAttribute lengthY = vpElement.Attribute("ly");
            visualParameters.SideLengthY = double.Parse(lengthY.Value, NumberStyles.Float, CultureInfo.InvariantCulture);

            XAttribute weight = vpElement.Attribute("we");
            visualParameters.Weight = double.Parse(weight.Value, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        private ISide ConvertElementToSide(XElement element)
        {
            Side side = new Side();

            side.TexCoord1 = new TextureCoordinate { X = ReadValueOfAttribute(element, "TC1X"), Y = ReadValueOfAttribute(element, "TC1Y") };
            side.TexCoord2 = new TextureCoordinate { X = ReadValueOfAttribute(element, "TC2X"), Y = ReadValueOfAttribute(element, "TC2Y") };
            side.TexCoord3 = new TextureCoordinate { X = ReadValueOfAttribute(element, "TC3X"), Y = ReadValueOfAttribute(element, "TC3Y") };
            side.TexCoord4 = new TextureCoordinate { X = ReadValueOfAttribute(element, "TC4X"), Y = ReadValueOfAttribute(element, "TC4Y") };

            return side;
        }

        private double ReadValueOfAttribute(XElement element, string attributeName)
        {
            XAttribute attribute = element.Attributes(attributeName).First();
            double value;
            if(Double.TryParse(attribute.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return value;

            throw new Exception("wrong number format! " + attributeName);
        }
    }
}
