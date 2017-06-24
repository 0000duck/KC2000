using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteraction.ThemeMapping;
using CollisionDetection;
using GameInteraction.BaseImplementations;
using IOInterface;
using BaseTypes;
using GameInteractionContracts;
using BaseContracts;

namespace ThemeMapping
{
    public class ListFillingFactory<T> : IElementFactory, IListProvider<T>
    {
        protected IElementFactory Factory { set; get; }

        protected List<T> List { set; get; }

        public ListFillingFactory(IElementFactory factory)
        {
            Factory = factory;
            List = new List<T>(500);
        }

        public virtual IWorldElement CreateNewElement(IElement element)
        {
            IWorldElement worldelement = Factory.CreateNewElement(element);

            if(worldelement is T)
                List.Add((T)worldelement);

            return worldelement;
        }

        public IEnumerable<T> GetList()
        {
            return List;
        }

        public virtual void DeleteElement(IWorldElement element)
        {
            if (element is T)
            {
                if (List.Contains((T)element))
                    List.Remove((T)element);
            }
            Factory.DeleteElement(element);
        }
    }
}
