using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;

namespace GameInteractionContracts
{
    public class TargetDefinition
    {
        public Position3D TargetPosition { set; get; }

        public IAnimatable TargetElement { set; get; }

        public bool AnyTargetFound { get { return TargetElement != null || TargetPosition != null; } }

        public bool TargetIsAnElement { get { return TargetElement != null; } }

        public bool TargetIsAPosition { get { return TargetPosition != null; } }

        public bool TargetIsEnemy { set; get; }

        public bool TargetIsDangerous { set; get; }

        public bool TargetCanBeSeen { set; get; }
    }

    public interface ITargetSearcher
    {
        bool SearchIsFinished();

        TargetDefinition GetSearchResult();

        void ProgressSearch(); 
    }
}
