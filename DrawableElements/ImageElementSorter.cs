using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;
using Render.Contracts;

namespace DrawableElements
{
    public class ImageElementSorter : IDrawable, IImageElementSorter
    {
        private Dictionary<int, IDrawableList> _imageLists = new Dictionary<int, IDrawableList>();
        private IAlphaTester _alphaTester;

        public ImageElementSorter(IAlphaTester alphaTester)
        {
            _alphaTester = alphaTester;
        }

        void IImageElementSorter.AddImageElement(IDrawable element, ITexture texture)
        {
            if (!_imageLists.Keys.Contains(texture.TextureId))
            {
                if(texture.HasAlphaChannel)
                    _imageLists.Add(texture.TextureId, new AlphaChannelListRenderer(_alphaTester, new List<IDrawable> { element }));
                else
                    _imageLists.Add(texture.TextureId, new ListRenderer(new List<IDrawable> { element }));
            }
            else
                _imageLists[texture.TextureId].Add(element);
        }

        void IDrawable.Draw()
        {
            foreach (int id in _imageLists.Keys)
            {
                _imageLists[id].Draw();
            }
        }
    }
}
