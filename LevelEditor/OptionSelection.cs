using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor
{
    public class OptionSelection
    {
        public int SelectedIndex { set; get; }

        public string Header { set; get; }

        public List<string> Options { set; get; }
    }
}
