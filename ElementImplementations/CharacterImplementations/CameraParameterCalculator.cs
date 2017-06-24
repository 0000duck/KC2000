using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElementImplementations.CharacterImplementations.DTOs;
using BaseTypes;
using IOInterface;
using GameInteractionContracts;

namespace ElementImplementations.CharacterImplementations
{
    public class CameraParameterCalculator : ICameraParameterCalculator
    {
        private double _cameraDegreeX;
        private double _cameraDegreeY;

        public CameraParameterCalculator(double cameraDegreeX)
        {
            _cameraDegreeX = cameraDegreeX;
        }

        ICameraParameters ICameraParameterCalculator.CalculateCameraParameters(Position3D footPosition, double height, double viewChangeX, double viewChangeY)
        {
            Position3D cameraPosition = footPosition.Clone();
            cameraPosition.PositionZ += height;

            _cameraDegreeX -= viewChangeX * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;

            if (_cameraDegreeX > 360)
                _cameraDegreeX -= 360;
            else if (_cameraDegreeX < 0)
                _cameraDegreeX += 360;

            _cameraDegreeY += viewChangeY * TimeAndSpeedManager.PercentTimeOfFrameOfOneSecond;

            if (_cameraDegreeY > 80)
                _cameraDegreeY = 80;
            else if (_cameraDegreeY < -80)
                _cameraDegreeY = -80;

            VectorWithDegree viewVector = new VectorWithDegree(_cameraDegreeX, _cameraDegreeY, true);

            return new CameraParameters
                {
                    CameraPosition = cameraPosition,
                    ViewVector = viewVector
                };
        }
    }
}
