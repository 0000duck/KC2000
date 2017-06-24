using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence
{
    public class DirectionDecider : IDirectionDecider
    {
        private IStepFreeSpaceTester _stepFreeSpaceTester;

        public DirectionDecider(IStepFreeSpaceTester stepFreeSpaceTester)
        {
            _stepFreeSpaceTester = stepFreeSpaceTester;
        }

        Degree? IDirectionDecider.GetMovementDirection(int desiredNumberOfSteps, Degree orientation)
        {
            double randomValue = MathHelper.GetRandomValueInARange(4.0, false);

            if (randomValue > 5.0)
            {
                return null;
            }
            else if (randomValue > 3.0)
            {
                if (EnoughSpace(orientation, desiredNumberOfSteps))
                    return Degree.Degree_0;
                return null;
            }
            if (randomValue > 2.0)
            {
                Degree degree90 = AddDegree(orientation, Degree.Degree_90);
                if (EnoughSpace(degree90, desiredNumberOfSteps))
                    return Degree.Degree_90;

                Degree degree270 = AddDegree(orientation, Degree.Degree_270);
                if (EnoughSpace(degree270, desiredNumberOfSteps))
                    return Degree.Degree_270;
                return null;
            }
            else if (randomValue > 1.0)
            {
                if (EnoughSpace(orientation, desiredNumberOfSteps))
                    return Degree.Degree_0;
                Degree degree90 = AddDegree(orientation, Degree.Degree_90);
                if (EnoughSpace(degree90, desiredNumberOfSteps))
                    return Degree.Degree_90;
                return null;
            }
            else
            {
                Degree degree270 = AddDegree(orientation, Degree.Degree_270);
                if (EnoughSpace(degree270, desiredNumberOfSteps))
                    return Degree.Degree_270;
                if (EnoughSpace(orientation, desiredNumberOfSteps))
                    return Degree.Degree_0;
                return null;
            }
        }

        private bool EnoughSpace(Degree degree, int desiredNumberOfSteps)
        {
            return _stepFreeSpaceTester.GetNumberOfFreeSteps(degree, desiredNumberOfSteps) == desiredNumberOfSteps;
        }

        Degree AddDegree(Degree one, Degree two)
        {
            int degree = (int)one + (int)two;

            if (degree > (int)Degree.Degree_315)
                return (Degree)(degree - 8);

            return (Degree)degree;
        }
    }
}
