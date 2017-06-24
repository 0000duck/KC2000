using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using CollisionDetection.Elements;
using CollisionDetection;

namespace ArtificialIntelligence
{
    public class ViewFieldElementProvider : IViewFieldElementProvider
    {
        private double _viewDepth;
        private double _additionalBuffer;
        private double _height;

        public ViewFieldElementProvider(double viewDepth, double additionalBuffer, double height)
        {
            _viewDepth = viewDepth;
            _additionalBuffer = additionalBuffer;
            _height = height;
        }

        IWorldElement IViewFieldElementProvider.GetViewFieldElement(Position3D viewerPosition, Degree viewDegree)
        {
            IWorldElement element = new StandardWorldElement(new LargePositionOnRoomFieldModel());

            Position3D centerOfViewCirlce = viewerPosition.Clone();

            double radius = _viewDepth / 2.0;
            switch(viewDegree)
            {
                 case Degree.Degree_0:
                    centerOfViewCirlce.PositionX += radius;
                    break;
                case Degree.Degree_45:
                    centerOfViewCirlce.PositionX += radius * MathHelper.SinusOf45Degree;
                    centerOfViewCirlce.PositionY += radius * MathHelper.SinusOf45Degree;
                    break;
                case Degree.Degree_90:
                    centerOfViewCirlce.PositionY += radius;
                    break;
                case Degree.Degree_135:
                    centerOfViewCirlce.PositionX -= radius * MathHelper.SinusOf45Degree;
                    centerOfViewCirlce.PositionY += radius * MathHelper.SinusOf45Degree;
                    break;
                case Degree.Degree_180:
                    centerOfViewCirlce.PositionX -= radius;
                    break;
                case Degree.Degree_225:
                    centerOfViewCirlce.PositionX -= radius * MathHelper.SinusOf45Degree;
                    centerOfViewCirlce.PositionY -= radius * MathHelper.SinusOf45Degree;
                    break;
                case Degree.Degree_270:
                    centerOfViewCirlce.PositionY -= radius;
                    break;
                case Degree.Degree_315:
                    centerOfViewCirlce.PositionX += radius * MathHelper.SinusOf45Degree;
                    centerOfViewCirlce.PositionY -= radius * MathHelper.SinusOf45Degree;
                    break;
            }

            element.SetCenterPosition(centerOfViewCirlce.PositionX, centerOfViewCirlce.PositionY, centerOfViewCirlce.PositionZ);

            radius += _additionalBuffer;

            element.SetPhysicalAppearance(Shape.Circle, 1.0, radius * 2, radius * 2, _height, radius);

            return element;
        }
    }
}
