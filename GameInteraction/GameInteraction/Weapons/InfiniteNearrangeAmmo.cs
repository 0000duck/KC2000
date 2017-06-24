using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using GameInteractionContracts;
using BaseContracts;

namespace GameInteraction.Weapons
{
    public class InfiniteNearrangeAmmo : StandardWorldElement, IComplexAmmo
    {
        private IDestructionRegistration _destructionRegistration;
        private double _strength;
        private IListProvider<IWorldElement> _listProvider;

        public InfiniteNearrangeAmmo(IDestructionRegistration destructionRegistration, double strength, IListProvider<IWorldElement> listProvider)
        {
            _destructionRegistration = destructionRegistration;
            _strength = strength;
            _listProvider = listProvider;
        }

        int IComplexAmmo.Count
        {
            get { return 1; }
        }

        AmmoFireResult IComplexAmmo.Fire(Position3D position, VectorWithDegree directionVector)
        {
            _destructionRegistration.AddNewDestruction(position, directionVector.Vector, _strength, _listProvider, null);
            return AmmoFireResult.SuccessfullyFired;
        }
    }
}
