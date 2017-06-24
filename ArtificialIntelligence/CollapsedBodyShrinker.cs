using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseTypes;
using ArtificialIntelligence.Contracts;
using GameInteractionContracts;
using IOImplementation;
using IOInterface;

namespace ArtificialIntelligence
{
    public class CollapsedBodyShrinker : ICollapseObserver
    {
        private IWorldElementProvider _characterProvider;
        private double _height;
        private bool _shrinked;

        public CollapsedBodyShrinker(IWorldElementProvider characterProvider, double height)
        {
            _characterProvider = characterProvider;
            _height = height;
        }

        void ICollapseObserver.CharacterHasCollapsed()
        {
            if (_shrinked)
                return;

            IWorldElement character = _characterProvider.GetElement();

            if (character == null)
                return;

            character.SetPhysicalAppearance(character.Shape, character.Weight, character.LengthX, character.LengthY, _height, character.Radius);
            _shrinked = true;
        }
    }
}
