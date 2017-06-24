using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;
using BaseTypes;
using BaseContracts;

namespace GameInteraction.Weapons
{
    public class BulletManagerDecorator : IBulletManager
    {
        private IBulletManager _bulletManager;
        private int _numberOfIgnoredBullets;
        private double _lastBulletStartTime;
        private double _minimumDurationForReset;
        private int _counter;

        public BulletManagerDecorator(IBulletManager bulletManager, int numberOfIgnoredBullets, double minimumDurationForReset)
        {
            _bulletManager = bulletManager;
            _numberOfIgnoredBullets = numberOfIgnoredBullets;
            _minimumDurationForReset = minimumDurationForReset;
            _counter = 1;
        }

        void IBulletManager.AddNewBullet(Position3D position, IWorldElement excludebleSource, VectorWithDegree directionVector, bool upsplittingAmmo, double destructionStrength, TestQuality testQuality, IListProvider<IWorldElement> listProvider)
        {
            if (TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds - _lastBulletStartTime > _minimumDurationForReset || _counter == _numberOfIgnoredBullets)
                _counter = 1;
          
            _lastBulletStartTime = TimeAndSpeedManager.TotalTimeOfCurrentLevelInSeconds;

            if (_counter == 1)
                _bulletManager.AddNewBullet(position, excludebleSource, directionVector, upsplittingAmmo, destructionStrength, testQuality, listProvider);

            _counter++;
        }
    }
}
