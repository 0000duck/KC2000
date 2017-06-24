using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using BaseTypes;

namespace DrawableElements
{
    public class SimpleDegreeCalculator : IDegreeCalculator
    {
        private IDegreeMapper DegreeMapper { set; get; }
        private IPlayerCamera Camera { set; get; }

        public SimpleDegreeCalculator(IPlayerCamera camera, IDegreeMapper degreeMapper)
        {
            DegreeMapper = degreeMapper;
            Camera = camera;
        }

        Degree IDegreeCalculator.CalculateIndividualDegree(Degree desiredDegree, double positionX, double positionZ)
        {
            return DegreeMapper.MapDegreeByCameraPerspective(Camera.CameraPerspective, desiredDegree); 
        }
    }
}
