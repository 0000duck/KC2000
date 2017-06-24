using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace FrameworkImplementations.Mainframe
{
    public class LevelIdSwitcher : ILevelIdSwitcher, ILevelIdProvider
    {
        private IList<int> _sortedLevelIds;
        private int _index;

        public LevelIdSwitcher(IList<int> sortedLevelIds)
        {
            _sortedLevelIds = sortedLevelIds;
        }

        void ILevelIdSwitcher.SwitchToNextLevel()
        {
            if (_index + 1 < _sortedLevelIds.Count)
                _index++;
        }

        void ILevelIdSwitcher.SetSpecificLevel(int id)
        {
            _index = 0;
            while (_sortedLevelIds.ElementAt(_index) != id)
                _index++;
        }

        int ILevelIdProvider.GetLevelId()
        {
            return _sortedLevelIds.ElementAt(_index);
        }
    }
}
