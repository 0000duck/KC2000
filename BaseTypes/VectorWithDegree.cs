using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class VectorWithDegree
    {
        public Vector3D Vector { get; private set; }

        private double? degreeXY;
        private double? degreeZ;

        public double DegreeXY 
        {
            get
            {
                if (!degreeXY.HasValue)
                    throw new NotImplementedException("The degree can't be calculated by the vector!");

                return degreeXY.Value;
            }
        }

        public double DegreeZ 
        {
            get
            {
                if (!degreeZ.HasValue)
                    throw new NotImplementedException("The degree can't be calculated by the vector!");

                return degreeZ.Value;
            }
        }

        public VectorWithDegree(Vector3D vector, bool unitLength = false)
        {
            Vector = vector;
            if (unitLength)
                Vector.CalculateUnitLength();
        }

        public VectorWithDegree(double degreeXY, double degreeZ, bool unitLength = false)
        {
            this.degreeXY = degreeXY;
            this.degreeZ = degreeZ;
            Vector = MathHelper.ConvertDegreeToVector(degreeXY, degreeZ);
            if (unitLength)
                Vector.CalculateUnitLength();
        }
    }
}
