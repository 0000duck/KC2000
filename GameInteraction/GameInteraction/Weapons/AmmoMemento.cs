using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using IOInterface;
using GameInteractionContracts;

namespace GameInteraction.Weapons
{
    internal class AmmoMemento : IStorable
    {
        private enum Identifier
        {
            Count = 1
        }

        public int Count { get; set; }

        public void SetState(IInitInformation initInformation)
        {
            Count = initInformation.InitValues.Find(x => x.Identifier == (int)Identifier.Count).ValueAsInt;
        }

        public IInitInformation GetState()
        {
            return new InitInformation
            {
                InitValues = new List<IInitValue> 
                {
                    new InitValue 
                        { 
                            Identifier = (int)Identifier.Count,
                            Value = Count.ToString("d") 
                        }
                }
            };
        }
    }
}
