using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using IOInterface;
using GameInteraction;
using GameInteractionContracts;

namespace ElementImplementations.DoorImplementations
{
    public class SlidingDoorMemento : IStorable
    {
        private enum Identifier
        {
            Open = 1
        }

        public bool Open { get; set; }

        public IInitInformation GetState()
        {
            return new InitInformation
            {
                InitValues = new List<IInitValue> 
                {
                    new InitValue 
                        { 
                            Identifier = (int)Identifier.Open,
                            Value = Open ? "1" : "0"
                        }
                }
            };
        }

        public void SetState(IInitInformation initInformation)
        {
            int open = initInformation.InitValues.Find(x => x.Identifier == (int)Identifier.Open).ValueAsInt;
            Open = open == 1;
        }
    }
}
