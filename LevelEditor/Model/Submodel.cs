using Render.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Model
{
    public class Submodel
    {
        public string Texture { set; get; }

        public IEnumerable<Polygon> Polygons { set; get; }
    }
}
