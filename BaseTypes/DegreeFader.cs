using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes
{
    public class DegreeFader
    {
        private Degree StartDegree { set; get; }
        private Degree EndDegree { set; get; }
        private int DegreeDelta { set; get; }

        public int StartFading(Degree startDegree, Degree endDegree)
        {
            StartDegree = startDegree;
            EndDegree = endDegree;

            if (StartDegree == EndDegree)
            {
                DegreeDelta = 1;
                return 0;
            }

            int deltaOne;
            int deltaTwo;
            int deltaOneMinus;
            int deltaTwoMinus;

            if (StartDegree > endDegree)
            {
                deltaOne = StartDegree - endDegree;

                deltaTwo = (int)endDegree + 8 - (int)StartDegree;

                deltaOneMinus = -1;
                deltaTwoMinus = 1;
            }
            else
            {
                deltaOne = endDegree - StartDegree;

                deltaTwo = (int)StartDegree + 8 - (int)endDegree;

                deltaOneMinus = 1;
                deltaTwoMinus = -1;
            }

            if (deltaOne < deltaTwo)
            {
                DegreeDelta = deltaOneMinus * (deltaOne + 1);
            }
            else
            {
                DegreeDelta = deltaTwoMinus * (deltaTwo + 1);
            }

            return DegreeDelta < 0 ? DegreeDelta + 1 : DegreeDelta - 1;
        }

        public void StartFadingByDelta(Degree startDegree, int degreeDelta)
        {
            StartDegree = startDegree;

            DegreeDelta = degreeDelta;

            EndDegree = StartDegree + DegreeDelta;

            if (EndDegree > Degree.Degree_315)
                EndDegree -= 8;
            if (EndDegree < Degree.Degree_0)
                EndDegree += 8;

            if (DegreeDelta > 0)
                DegreeDelta += 1;
            else
                DegreeDelta -= 1;
        }

        public Degree GetInterpolatedDegree(double percent)
        {
            if (percent >= 1.0)
                return EndDegree;

            int result = ((int)StartDegree + (int)(DegreeDelta * percent));

            if (result < 1)
                return (Degree)result + 8;

            if (result > 8)
                return (Degree)result - 8;

            return (Degree)result;
        }
    }
}
