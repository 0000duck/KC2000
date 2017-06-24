using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using IOInterface;
using ArtificialIntelligence.Contracts;
using BaseTypes;
using BaseContracts;
using GameInteraction.BaseImplementations;

namespace GameInteraction.Weapons
{
    public class ComplexAmmo : StandardWorldElement, IVisualAppearance, IComplexAmmo
    {
        private IBulletManager _bulletManager;
        private IWorldElementProvider _elementProvider;
        private IListProvider<IWorldElement> _listProvider;
        private bool _upsplitting; 
        private double _strength;
        private int _count;

        public ComplexAmmo(IBulletManager bulletManager, IWorldElementProvider elementProvider, IListProvider<IWorldElement> listProvider, bool upsplitting, double strength, int count)
        {
            _bulletManager = bulletManager;
            _elementProvider = elementProvider;
            _listProvider = listProvider;
            _upsplitting = upsplitting;
            _strength = strength;
            _count = count;
        }

        AmmoFireResult IComplexAmmo.Fire(Position3D position, VectorWithDegree directionVector)
        {
            if (_count > 0)
            {
                _bulletManager.AddNewBullet(position, _elementProvider.GetElement(), directionVector, _upsplitting, _strength, TestQuality.High, _listProvider);
                _count--;
                return AmmoFireResult.SuccessfullyFired;
            }
            return AmmoFireResult.OutOfAmmo;
        }

        int IComplexAmmo.Count
        {
            get { return _count; }
        }

        ElementTheme IVisualAppearance.ElementTheme { set; get; }

        Degree IVisualAppearance.Orientation { set; get; }

        bool IVisualAppearance.IsMarked { set; get; }
    }
}
