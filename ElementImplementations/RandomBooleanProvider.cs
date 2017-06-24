using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseTypes;

namespace ElementImplementations
{
    public class RandomBooleanProvider : IRandomBooleanProvider
    {
        private int _numberOfFalsePerTrue;
        private int _counter;
        private int _maxValue;

        public RandomBooleanProvider(int numberOfFalsePerTrue)
        {
            _numberOfFalsePerTrue = numberOfFalsePerTrue;
        }

        bool IRandomBooleanProvider.GetValue()
        {
            if (_counter == _maxValue)
            {
                _counter = 0;
                _maxValue = (int)MathHelper.GetRandomValueInARange(_numberOfFalsePerTrue, false);
                return true;
            }

            _counter++;
            return false;
        }
    }
}
