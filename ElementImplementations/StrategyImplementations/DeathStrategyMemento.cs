using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.BaseImplementations;
using IOInterface;
using GameInteraction;
using GameInteractionContracts;

namespace ElementImplementations.StrategyImplementations
{
    //public class DeathStrategyMemento : IStorable
    //{
    //    public PhysicalStatus CurrentPhysicalStatus { set; get; }

    //    public bool ElementDied { set; get; }

    //    public DeathStatus CurrentDeathStatus { get; set; }

    //    private enum Identifier
    //    {
    //        CurrentPhysicalStatus = 1,

    //        ElementDied = 2,

    //        CurrentDeathStatus = 3
    //    }

    //    public void SetState(IInitInformation initInformation)
    //    {
    //        CurrentPhysicalStatus = (PhysicalStatus)initInformation.InitValues.Find(x => x.Identifier == (int)Identifier.CurrentPhysicalStatus).ValueAsInt;
    //        ElementDied = initInformation.InitValues.Find(x => x.Identifier == (int)Identifier.ElementDied).ValueAsInt == 1;
    //        CurrentDeathStatus = (DeathStatus)initInformation.InitValues.Find(x => x.Identifier == (int)Identifier.CurrentDeathStatus).ValueAsInt;
    //    }

    //    public IInitInformation GetState()
    //    {
    //        return new InitInformation
    //        {
    //            InitValues = new List<IInitValue> 
    //            {
    //                new InitValue 
    //                { 
    //                    Identifier = (int)Identifier.CurrentPhysicalStatus,
    //                    Value = ((int)CurrentPhysicalStatus).ToString()
    //                },
    //                new InitValue 
    //                { 
    //                    Identifier = (int)Identifier.ElementDied,
    //                    Value = ElementDied ? "1" : "0"
    //                },
    //                new InitValue 
    //                { 
    //                    Identifier = (int)Identifier.CurrentDeathStatus,
    //                    Value = ((int)CurrentDeathStatus).ToString()
    //                }
    //            }
    //        };
    //    }
    //}
}
