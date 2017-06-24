using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using ArtificialIntelligence.Contracts;

namespace ArtificialIntelligence
{
    public class FootSwitcher : IFootSwitcher
    {
        private enum LeadingFoot
        {
            LeftFoot = 1,

            RightFoot = -1
        }

        private LeadingFoot CurrentLeadingFoot { set; get; }


        public FootSwitcher()
        {
            CurrentLeadingFoot = LeadingFoot.LeftFoot;
        }

        Behaviour IFootSwitcher.GetLeadingFoot(double percentOfAnimation)
        {
            switch (CurrentLeadingFoot)
            {
                case LeadingFoot.LeftFoot:
                    return Behaviour.StepWithLeftFoot;
                case LeadingFoot.RightFoot:
                    return Behaviour.StepWithRightFoot;
            }
            return Behaviour.StepWithLeftFoot;
        }

        void IFootSwitcher.SwitchFoot()
        {
            CurrentLeadingFoot = (LeadingFoot)(-(int)CurrentLeadingFoot);
        }
    }
}
