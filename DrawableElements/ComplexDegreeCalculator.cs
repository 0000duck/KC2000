using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;

namespace DrawableElements
{
    public class ComplexDegreeCalculator : IDegreeCalculator
    {
        private IDegreeMapper DegreeMapper { set; get; }
        private IPlayerCamera Camera { set; get; }

        public ComplexDegreeCalculator(IPlayerCamera camera, IDegreeMapper degreeMapper)
        {
            DegreeMapper = degreeMapper;
            Camera = camera;
        }

        Degree IDegreeCalculator.CalculateIndividualDegree(Degree desiredDegree, double positionX, double positionZ)
        {
                Degree calculatedDegree = VectorToDegreeConverter.Convert(new Vector2D
                {
                    X = positionX - Camera.CameraPosition.PositionX,
                    Y = positionZ - Camera.CameraPosition.PositionZ,
                });
            
            return DegreeMapper.MapDegreeByCameraPerspective(calculatedDegree, desiredDegree); 
        }
    }
}
