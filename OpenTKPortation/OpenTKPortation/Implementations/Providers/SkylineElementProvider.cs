using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using FrameworkContracts;
using DrawableElements;
using Render.Contracts;

namespace OpenTKPortation.Implementations.Providers
{
    public class SkylineElementProvider : ISkylineElementProvider
    {
        private ITextureLoader _textureLoader;
        private ITextureChanger _textureChanger;
        private IPolygonRenderer _polygonRenderer;
        private ILightSwitch _lightSwitch;
        private IAnimationLoader _animationLoader;
        private ITextureTranslator _textureTranslator;

        public SkylineElementProvider(ITextureLoader textureLoader, ITextureChanger textureChanger, ITextureTranslator textureTranslator, IPolygonRenderer polygonRenderer, ILightSwitch lightSwitch, IAnimationLoader animationLoader)
        {
            _textureLoader = textureLoader;
            _textureChanger = textureChanger;
            _textureTranslator = textureTranslator;
            _polygonRenderer = polygonRenderer;
            _lightSwitch = lightSwitch;
            _animationLoader = animationLoader;
        }
        IDrawable ISkylineElementProvider.GetSkylineElement(int levelId)
        {
            switch (levelId)
            {
                case 1:
                    return new ListRenderer(new List<IDrawable> 
                    { 
                     new LightlessAnimationRenderer(_animationLoader.LoadAnimation("Content\\Animations\\Horizont1"), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -100, numberOfUnits:6), _lightSwitch, 0.9),
                      new LightlessAnimationRenderer(_animationLoader.LoadAnimation("Content\\Animations\\Horizont2"), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -100, numberOfUnits: 6, startDegree: 30), _lightSwitch, 0.9)
                    });
                case 2:
                case 102:
                    return new ListRenderer(new List<IDrawable> 
                    { 
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke1.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: 40, numberOfUnits: 7, distance: 360), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke2.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -40, numberOfUnits: 4, startDegree: 40, distance: 365),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\gebirge.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons(),_lightSwitch)
               
                    });
                case 3:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\gebirge.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons(),_lightSwitch);
                case 4:
                    return new ListRenderer(new List<IDrawable> 
                    {
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\japangebirge1.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -20, numberOfUnits:6), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\japangebirge2.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -20, numberOfUnits:6, startDegree:30), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke orange.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: 25, numberOfUnits: 5, distance: 370f), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke orange 2.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: 5, numberOfUnits: 3, distance: 380f, startDegree: 24), _lightSwitch)
                    });
                case 5:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\schneegebirge.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons(), _lightSwitch);
                case 6:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -10, height: 94), _lightSwitch);
                case 7:
                    return new LightlessAnimationRenderer(_animationLoader.LoadAnimation("Content\\Animations\\SkylineOnWater"), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -100), _lightSwitch, 0.8);
                case 8:
                    return new ListRenderer(new List<IDrawable> 
                    {
                         new LightlessAnimationRenderer(_animationLoader.LoadAnimation("Content\\Animations\\SkylineWaterMorning"), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -100), _lightSwitch, 0.8)
                    });
                case 9:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skylinenight.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -8, height: 94), _lightSwitch);

                case 13:
                    return new ListRenderer(new List<IDrawable> 
                    { 
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke1.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: 40, numberOfUnits: 8, distance: 355), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke2.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -40, numberOfUnits: 4, startDegree: 35, distance: 355),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -10, height: 94, numberOfUnits:1, startDegree:0),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -15, height: 94, numberOfUnits:1, startDegree:-30),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -15, height: 94, numberOfUnits:1, startDegree:30),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -20, height: 94, numberOfUnits:1, startDegree:-60),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -20, height: 94, numberOfUnits:1, startDegree:60),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -25, height: 94, numberOfUnits:1, startDegree:-90),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -25, height: 94, numberOfUnits:1, startDegree:90),_lightSwitch),
                    });
                case 12:
                    return new ListRenderer(new List<IDrawable> 
                    { 
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke1.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: 40, numberOfUnits: 8, distance: 355), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke2.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -40, numberOfUnits: 4, startDegree: 35, distance: 355),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -15, height: 94, numberOfUnits:1, startDegree:30),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -20, height: 94, numberOfUnits:1, startDegree:0),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -20, height: 94, numberOfUnits:1, startDegree:60),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -25, height: 94, numberOfUnits:1, startDegree:-30),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -25, height: 94, numberOfUnits:1, startDegree:90),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -30, height: 94, numberOfUnits:1, startDegree:-60),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -30, height: 94, numberOfUnits:1, startDegree:120),_lightSwitch),
                    });
                case 11:
                    return new ListRenderer(new List<IDrawable> 
                    { 
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke1.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: 40, numberOfUnits: 8, distance: 355), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke2.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -40, numberOfUnits: 4, startDegree: 35, distance: 355),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -15, height: 94, numberOfUnits:1, startDegree:210),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -20, height: 94, numberOfUnits:1, startDegree:180),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -20, height: 94, numberOfUnits:1, startDegree:240),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -25, height: 94, numberOfUnits:1, startDegree:150),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -25, height: 94, numberOfUnits:1, startDegree:270),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -30, height: 94, numberOfUnits:1, startDegree:120),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\skyline far.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -30, height: 94, numberOfUnits:1, startDegree:300),_lightSwitch),
                    });
                case 10:
                case 17:
                    return null;
                case 14:
                    return new ListRenderer(new List<IDrawable> 
                    {
                     new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\schneegebirge2.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(), _lightSwitch)
                    ,new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\sunset2.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, distance:370, centerY:30, startDegree:100, height: 94, length:376), _lightSwitch)
                    });
                case 23:
                    return new ListRenderer(new List<IDrawable> 
                    {
                     new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\sunsetsky.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:90, distance:11, height:8, centerY:-3, length:400), _lightSwitch),
                     new TextureTranslationDecorator(new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline2.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:90, distance:10.5f, height:16, centerY:-7, length:400, adaptTextureSize: true), _lightSwitch), _textureTranslator,35, TextureCoordinateDirection.NegativeX),
                    new TextureTranslationDecorator(new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:90, distance:10f, height:16, centerY:-6.5, length:400, adaptTextureSize: true), _lightSwitch), _textureTranslator,20, TextureCoordinateDirection.NegativeX),
                new TextureTranslationDecorator(new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:90, distance:9.5f, height:16, centerY:-6, length:400, adaptTextureSize: true), _lightSwitch), _textureTranslator,10, TextureCoordinateDirection.NegativeX),
                new TextureTranslationDecorator(new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:90, distance:9, height:16, centerY:-5.5, length:400, adaptTextureSize: true), _lightSwitch), _textureTranslator,5, TextureCoordinateDirection.NegativeX),
                
                new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\sunsetsky.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:270, distance:31, height:8, centerY:-3, length:400), _lightSwitch),
                     new TextureTranslationDecorator(new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline2.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:270, distance:30.5f, height:16, centerY:-7, length:400, adaptTextureSize: true), _lightSwitch), _textureTranslator,35, TextureCoordinateDirection.PositiveX),
                    new TextureTranslationDecorator(new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:270, distance:30, height:16, centerY:-6.5, length:400, adaptTextureSize: true), _lightSwitch), _textureTranslator,20, TextureCoordinateDirection.PositiveX),
                new TextureTranslationDecorator(new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:270, distance:29.5f, height:16, centerY:-6, length:400, adaptTextureSize: true), _lightSwitch), _textureTranslator,10, TextureCoordinateDirection.PositiveX),
                new TextureTranslationDecorator(new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:270, distance:29, height:16, centerY:-5.5, length:400, adaptTextureSize: true), _lightSwitch), _textureTranslator,5, TextureCoordinateDirection.PositiveX),
                  
                  new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\sunsetsky.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:0, distance:200, height:8, centerY:-3, length:400), _lightSwitch),
                    new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\sunsetsky.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, startDegree:180, distance:200, height:8, centerY:-3, length:400), _lightSwitch), 
                    });
                case 15:
                    return new ListRenderer(new List<IDrawable> 
                    {
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\riversun.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -115, startDegree: 270, numberOfUnits: 1, distance:400, height:240, length:240), _lightSwitch),
                    new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\Images\\red.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -96, startDegree: 90, numberOfUnits: 1, distance:200, height:94, length:220), _lightSwitch),
                    
                     new LightlessAnimationRenderer(_animationLoader.LoadAnimation("Content\\Animations\\SunsetWater"), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -96, startDegree: 270, numberOfUnits: 1, distance:300, height:94), _lightSwitch, 0.8),
                    });
                case 16:
                    return new ListRenderer(new List<IDrawable> 
                    {
                     new ImageRectangle(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\riverbg.png", false), _textureChanger,new PolygonDrawer(_polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(height: 94, centerY: -5, distance: 320))),
                    new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\Images\\mond.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, distance:370, centerY:90, startDegree:90, height: 130,length:130), _lightSwitch),
                    new LightlessAnimationRenderer(_animationLoader.LoadAnimation("Content\\Animations\\Moon"), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(numberOfUnits:1, distance:370, centerY:-220, startDegree:90, height: 150,length:150), _lightSwitch, 1)
                    });
                case 18:
                    return new ListRenderer(new List<IDrawable> 
                    {
                     new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\jungle2.png", false), _textureChanger,_polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(height: 94, centerY: -5), _lightSwitch),
                     new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke1.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: 35, numberOfUnits: 3, distance: 365), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke2.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -25, numberOfUnits: 5, startDegree: 45, distance: 360),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke4.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: 75, numberOfUnits: 4, distance: 370, height:94, startDegree: 20), _lightSwitch),
                    });
                case 19:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\gebirgedunkel.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(), _lightSwitch);
                case 20:
                    return new LightlessAnimationRenderer(_animationLoader.LoadAnimation("Content\\Animations\\BavariaMountains"), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -100), _lightSwitch, 1);
                case 22:
                    return new ListRenderer(new List<IDrawable> 
                    {
                     new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\schneegebirge3.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -120), _lightSwitch)
                    });
                case 24:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline3.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -25), _lightSwitch);
                case 25:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\sunsetskytokyo.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -32), _lightSwitch);
                case 26:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline3.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -65), _lightSwitch);
                case 27:
                    return new ListRenderer(new List<IDrawable> 
                    {
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline3.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -85), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke3.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -40, numberOfUnits: 6, startDegree: 30, distance:375),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolkebunt.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -25, numberOfUnits: 6, startDegree: 0, distance:390),_lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolkebunt2.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons(centerY: 50, numberOfUnits: 10, distance:360),_lightSwitch)
                    });
                case 28:
                    return new ListRenderer(new List<IDrawable> 
                    {
                         new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline3.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -95), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\riversun.bmp", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -115, numberOfUnits: 1, distance:400, height:240, length:240), _lightSwitch),
                            new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke brown.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: 35, numberOfUnits: 10, distance: 370f), _lightSwitch),
                        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke brown2.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -30, numberOfUnits: 8, distance: 380f, startDegree: 24), _lightSwitch)
                    });
                //case 28:
                //    return new ListRenderer(new List<IDrawable> 
                //    {
                //        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\tokyoskyline3.png", false), _textureChanger, _polygonRenderer, new SkyLineElementPolygonBuilder().CreatePolygons(centerY: -95), _lightSwitch),
                //        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke1.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: 25, numberOfUnits: 3, distance: 365), _lightSwitch),
                //        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke2.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: -35, numberOfUnits: 5, startDegree: 45, distance: 360),_lightSwitch),
                //        new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\EnvironmentThemes\\Skies\\wolke4.png", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons( centerY: 65, numberOfUnits: 4, distance: 370, height:94, startDegree: 20), _lightSwitch),
                //    });
                default:
                    return new LightlessImageRenderer(_textureLoader.LoadTexture("Content\\Images\\white.bmp", false), _textureChanger, _polygonRenderer,new SkyLineElementPolygonBuilder().CreatePolygons(), _lightSwitch);
            }
        }
    }
}
