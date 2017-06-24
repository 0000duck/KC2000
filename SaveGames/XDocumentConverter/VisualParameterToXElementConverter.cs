using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FrameworkContracts;
using System.Globalization;

namespace SaveGames.XDocumentConverter
{
    public class VisualParameterToXElementConverter
    {
        public void AddVisualParameters(XElement xElement, IVisualParameters visualParameters)
        {
            XElement vP = new XElement("VP");

            if (visualParameters.Bottom != null)
            {
                XElement bottom = new XElement("bo");
                AddSideToElement(bottom, visualParameters.Bottom);
                vP.Add(bottom);
            }
            if (visualParameters.Top != null)
            {
                XElement top = new XElement("to");
                AddSideToElement(top, visualParameters.Top);
                vP.Add(top);
            }
            if (visualParameters.NegativeX != null)
            {
                XElement nx = new XElement("nx");
                AddSideToElement(nx, visualParameters.NegativeX);
                vP.Add(nx);
            }
            if (visualParameters.PositiveX != null)
            {
                XElement px = new XElement("px");
                AddSideToElement(px, visualParameters.PositiveX);
                vP.Add(px);
            }
            if (visualParameters.NegativeZ != null)
            {
                XElement nz = new XElement("nz");
                AddSideToElement(nz, visualParameters.NegativeZ);
                vP.Add(nz);
            }
            if (visualParameters.PositiveZ != null)
            {
                XElement pz = new XElement("pz");
                AddSideToElement(pz, visualParameters.PositiveZ);
                vP.Add(pz);
            }

            AddPhysicalParameters(visualParameters, vP);

            xElement.Add(vP);
        }

        private static void AddPhysicalParameters(IVisualParameters visualParameters, XElement vP)
        {
            vP.Add(new XAttribute("tf", visualParameters.TextureFolder));
            vP.Add(new XAttribute("ia", visualParameters.IsAnimation ? "1" : "0"));
            vP.Add(new XAttribute("ad", visualParameters.AnimationDurationPerImage.ToString(CultureInfo.InvariantCulture)));
            if (visualParameters.TextureCoordinateDirection.HasValue)
                vP.Add(new XAttribute("tcd", ((int)(visualParameters.TextureCoordinateDirection.Value)).ToString(CultureInfo.InvariantCulture)));
            vP.Add(new XAttribute("sh", visualParameters.Shape == BaseTypes.Shape.Circle ? "C" : "R"));
            vP.Add(new XAttribute("he", visualParameters.Height.ToString(CultureInfo.InvariantCulture)));
            vP.Add(new XAttribute("lx", visualParameters.SideLengthX.ToString(CultureInfo.InvariantCulture)));
            vP.Add(new XAttribute("ly", visualParameters.SideLengthY.ToString(CultureInfo.InvariantCulture)));
            vP.Add(new XAttribute("we", visualParameters.Weight.ToString(CultureInfo.InvariantCulture)));
        }

        private void AddSideToElement(XElement element, ISide side)
        {
            element.Add(CreateAttribute(side.TexCoord1.X, "TC1X"));
            element.Add(CreateAttribute(side.TexCoord1.Y, "TC1Y"));
            element.Add(CreateAttribute(side.TexCoord2.X, "TC2X"));
            element.Add(CreateAttribute(side.TexCoord2.Y, "TC2Y"));
            element.Add(CreateAttribute(side.TexCoord3.X, "TC3X"));
            element.Add(CreateAttribute(side.TexCoord3.Y, "TC3Y"));
            element.Add(CreateAttribute(side.TexCoord4.X, "TC4X"));
            element.Add(CreateAttribute(side.TexCoord4.Y, "TC4Y")); 
        }

        private XAttribute CreateAttribute(double value, string name)
        {
            return new XAttribute(name, value.ToString(CultureInfo.InvariantCulture));
        }
    }
}
