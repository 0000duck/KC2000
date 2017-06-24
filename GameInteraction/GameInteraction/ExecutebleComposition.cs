using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using GameInteractionContracts;
using BaseContracts;

namespace GameInteraction
{
    public class ExecutebleComposition : IExecuteble
    {
        private IEnumerable<IExecuteble> _executebles;

        public ExecutebleComposition(IEnumerable<IExecuteble> executebles)
        {  
            _executebles = executebles;
        }

        void IExecuteble.ExecuteLogic()
        {
            foreach (IExecuteble executeble in _executebles)
            {
                executeble.ExecuteLogic();
            }
        }
    }
}
