using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using FrameworkContracts;
using DrawableElements;
using BaseTypes;
using Render.Contracts;

namespace OpenTKPortation.Implementations.Providers
{
    public class FloorProvider : IFloorProvider
    {
        private ITextureLoader _textureLoader;
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;

        public FloorProvider(ITextureLoader textureLoader, ITextureChanger textureChanger, IPolygonRenderer polygonRenderer)
        {
            _textureLoader = textureLoader;
            _textureChanger = textureChanger;
            _polygonRenderer = polygonRenderer;
        }

        IDrawable IFloorProvider.GetRenderedFloor(int levelId)
        {
            switch (levelId)
            {
                case 3:
                    return new Floor(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Floors\\erde2.bmp", false), _textureChanger, _polygonRenderer, 300, 300, 0, 37.5f, 37.5f);
                case 5:
                    return new Floor(_textureLoader.LoadTexture("Content\\Images\\white.bmp", false), _textureChanger, _polygonRenderer, 300, 300, -1, 1f, 1f);
                case 4:
                    return new ListRenderer(new List<IDrawable> 
                    { 
                        new Floor(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Floors\\japan floor.bmp", false), _textureChanger, _polygonRenderer,300, 117, 0, 37.5f, 18.75f),
                        new Floor(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Floors\\japan floor.bmp", false), _textureChanger, _polygonRenderer,300, 117, 0, 37.5f, 18.75f, startZ: 123)
                    });
                case 6:
                case 7:
                case 8:
                case 9:
                case 2:
                default:
                    return null;
            }
        }

        List<IWorldElement> IFloorProvider.GetCollisionElements(int levelId)
        {
            switch (levelId)
            {
                case 2:
                case 6:  
                case 3:
                    IWorldElement floor = new StandardWorldElement(new LargePositionOnRoomFieldModel());
                    floor.SetCenterPosition(150, 150, -1);
                    floor.SetPhysicalAppearance(Shape.Rectangle, 1, 300, 300, 1);
                    return new List<IWorldElement> { floor }; 
                case 4:
                    floor = new StandardWorldElement(new LargePositionOnRoomFieldModel());
                    floor.SetCenterPosition(150, 58.5, -1);
                    floor.SetPhysicalAppearance(Shape.Rectangle, 1, 300, 117, 1);
                    IWorldElement floor2 = new StandardWorldElement(new LargePositionOnRoomFieldModel());
                    floor2.SetCenterPosition(150, 181.5, -1);
                    floor2.SetPhysicalAppearance(Shape.Rectangle, 1, 300, 117, 1);
                    return new List<IWorldElement> { floor, floor2};
                case 5:
                    floor = new StandardWorldElement(new LargePositionOnRoomFieldModel());
                    floor.SetCenterPosition(150, 150, -1);
                    floor.SetPhysicalAppearance(Shape.Rectangle, 1, 300, 5, 1);
                    floor2 = new StandardWorldElement(new LargePositionOnRoomFieldModel());
                    floor2.SetCenterPosition(150, 150, -2);
                    floor2.SetPhysicalAppearance(Shape.Rectangle, 1, 300, 300, 1);
                    return new List<IWorldElement> { floor, floor2};
                case 25:
                    floor = new StandardWorldElement(new LargePositionOnRoomFieldModel());
                    floor.SetCenterPosition(150, 150, -15);
                    floor.SetPhysicalAppearance(Shape.Rectangle, 1, 300, 300, 1);
                    return new List<IWorldElement> { floor };       
                default:
                    floor = new StandardWorldElement(new LargePositionOnRoomFieldModel());
                    floor.SetCenterPosition(150, 150, -1);
                    floor.SetPhysicalAppearance(Shape.Rectangle, 1, 300, 300, 1);
                    return new List<IWorldElement> { floor };                       
            }
        }
    }
}
