using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using FrameworkContracts;
using DrawableElements;
using Render.Contracts;
using Render;

namespace OpenTKPortation.Implementations.Providers
{
    public class BackgroundColorProvider : IBackgroundColorProvider
    {
        private IColorProvider _colorProvider;

        public BackgroundColorProvider(IColorProvider colorProvider)
        {
            _colorProvider = colorProvider;
        }

        IBackgroundColor IBackgroundColorProvider.GetBackgroundColor(int levelId)
        {
            switch (levelId)
            {
                case 1:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 2:
                case 102:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 3:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 4:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Violet));
                case 5:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Yellow));
                case 6:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Violet));
                case 7:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Blue));
                case 8:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Cyan));
                case 9:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Black));
                case 10:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Blue));
                case 11:
                case 12:
                case 13:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 14:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightred));
                case 15:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Red));
                case 16:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Black));
                case 17:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 18:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 19:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Violet));
                case 20:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 21:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 22:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Grey_2));
                case 23:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Blue));
                case 24:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Brown));
                case 25:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Blue));
                case 26:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Brown));
                case 27:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Cyan));
                //case 28:
                //    return new BackgroundColor(_colorProvider.GetColor(C64Color.Lightblue));
                case 28:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.Red));
                default:
                    return new BackgroundColor(_colorProvider.GetColor(C64Color.White));

            }
        }
    }
}
