using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseContracts;
using CollisionDetection.Contracts;
using BaseTypes;

namespace LevelEditor.Elements
{
    public class InvisibleElement : ElementPlaceHolder, IElementGroup
    {
        public InvisibleElement(IListProvider<IWorldElement> listProvider, IComplexElementFinder complexElementFinder)
            : base(listProvider, complexElementFinder)
        {

        }

        public override void Render()
        {
        }

        private List<IGroupElement> _children = new List<IGroupElement>();

        IList<IGroupElement> IElementGroup.Children
        {
            get { return _children; }
        }

        void IElementGroup.RemoveChild(IGroupElement child)
        {
            _children.Remove(child);
        }

        void IElementGroup.AddChild(IGroupElement child)
        {
            _children.Add(child);
        }
    }
}
