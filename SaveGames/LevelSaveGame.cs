using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOInterface;

namespace SaveGames
{
    public class LevelSaveGame
    {
        public int LevelId { set; get; }

        public string SkillName { set; get; }

        public List<IElement> AllElements { set; get; }
    }
}
