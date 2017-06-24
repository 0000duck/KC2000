using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialIntelligence.Contracts;
using BaseTypes;

namespace ArtificialIntelligence.PathTesting
{
    public class StepFreeSpaceTester : IStepFreeSpaceTester
    {
        private IFreeSpaceTester _freeSpaceTester;
        private IWorldElementProvider _characterProvider;
        private double _stepLength;

        public StepFreeSpaceTester(IFreeSpaceTester freeSpaceTester, IWorldElementProvider characterProvider, double stepLength)
        {
            _freeSpaceTester = freeSpaceTester;
            _characterProvider = characterProvider;
            _stepLength = stepLength;
        }

        int IStepFreeSpaceTester.GetNumberOfFreeSteps(Degree degree, int numberOfDesiredSteps)
        {
            IWorldElement character = _characterProvider.GetElement();

            Position3D position = character.Position.Clone();

            // a little buffer to avoid collision with floor plate
            position.PositionZ += 0.1;

            Vector2D vector = VectorCreator.CreateVector(1, degree);

            Vector3D directionVector = new Vector3D();
            directionVector.X= vector.X;
            directionVector.Y = vector.Y;

            return _freeSpaceTester.GetNumberOfFreeUnits(position, directionVector, _stepLength / 2.0, character.Height, numberOfDesiredSteps);
        }
    }
}
