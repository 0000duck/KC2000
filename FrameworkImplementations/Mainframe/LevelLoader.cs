using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using Render.Contracts;
using FrameworkContracts;
using GameInteractionContracts;
using BaseContracts;
using BaseTypes;

namespace FrameworkImplementations.Mainframe
{
    public class LevelLoader : ILevelLoader, IBackgroundColor, ILevelRenderLayerProvider, IExecuteble, IPercentProvider
    {
        private IInitializer _initializer;
        private LevelUnit _levelUnit;
        private ILevelLoadObserver _levelLoadObserver;
        private ILevelIdProvider _levelIdProvider;
        private int _elementLoadIndex;
        private IContentDisposer _contentDisposer;
        private IExecuteble _resourcePreloader;
        private ISkillLevelProvider _skillLevelProvider;

        public LevelLoader(IInitializer initializer, ILevelLoadObserver levelLoadObserver, ILevelIdProvider levelIdProvider,
            IContentDisposer contentDisposer, IExecuteble resourcePreloader, ISkillLevelProvider skillLevelProvider)
        {
            _initializer = initializer;
            _levelLoadObserver = levelLoadObserver;
            _levelIdProvider = levelIdProvider;
            _contentDisposer = contentDisposer;
            _resourcePreloader = resourcePreloader;
            _skillLevelProvider = skillLevelProvider;
        }

        void IBackgroundColor.SetColor()
        {
            _levelUnit.Background.SetColor();
        }

        IDrawable ILevelRenderLayerProvider.Get3DWorld()
        {
            return _levelUnit.World3D;
        }

        IDrawable ILevelRenderLayerProvider.Get2DSurface()
        {
            return _levelUnit.InfoSurface2D;
        }

        void IExecuteble.ExecuteLogic()
        {
            _levelUnit.GameContent.ExecuteLogic();
        }

        void ILevelLoader.LoadLevel()
        {
            _levelLoadObserver.LevelBeginsToLoad();
            _elementLoadIndex = 0;
            int nextLevelId = _levelIdProvider.GetLevelId();
            SkillLevel skillLevel = _skillLevelProvider.GetSkillLevel();

            if (_levelUnit != null && _levelUnit.Id != nextLevelId)
            {
                _contentDisposer.DisposeTextures();
            }
            _contentDisposer.DisposeSounds();

            _resourcePreloader.ExecuteLogic();

            _levelUnit = _initializer.InitializeLevel(nextLevelId, skillLevel);
        }

        double IPercentProvider.GetPercent()
        {
            if (_elementLoadIndex >= _levelUnit.Elements.Count)
            {
                _levelLoadObserver.LevelIsLoaded();
                return 1.0;
            }

            int numberOfElementsToLoad = (int)(_levelUnit.Elements.Count / 20.0);
            if (numberOfElementsToLoad == 0)
                numberOfElementsToLoad = _levelUnit.Elements.Count;

            for (int index = _elementLoadIndex; index < _elementLoadIndex + numberOfElementsToLoad; index++)
            {
                if(index >= _levelUnit.Elements.Count)
                {
                    _elementLoadIndex = _levelUnit.Elements.Count;
                    return 1.0;
                }

                _levelUnit.ElementCreator.GetNewElement(_levelUnit.Elements.ElementAt(index));
            }

            _elementLoadIndex += numberOfElementsToLoad;

            return ((double)_elementLoadIndex) / _levelUnit.Elements.Count;
        }
    }
}
