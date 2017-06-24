using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace ElementImplementations.ActivationManagerImplementations
{
    public abstract class BaseActivationManager
    {
        private double LastActivationSearch { set; get; }

        private double SearchInterval { set; get; }

        public BaseActivationManager()
        {
            LastActivationSearch = 0.0;
            SearchInterval = 0.6;
        }

        protected bool SearchIsNecessary()
        {
            if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds < LastActivationSearch + SearchInterval)
                return false;

            LastActivationSearch = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;
            return true;
        }
    }
}
