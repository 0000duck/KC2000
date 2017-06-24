using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrawableElements;
using FrameworkContracts;
using BaseTypes;
using LevelEditor.Contracts;
using IOInterface;
using Render.Contracts;

namespace LevelEditor.CommunicationElements
{
    public class EditorAnimationSprite : MarkableLoopedAnimationSprite, IEditorCommunicationElement, ISideMarker
    {
        private IAnimationLoader AnimationLoader { set; get; }

        public EditorAnimationSprite(IAnimationLoader animationLoader, ITextureChanger textureChanger, IAnimation animation, Position3D position, IDrawable sprite, IDrawable markedSprite, IDegreeCalculator degreeCalculator, double animationDuration, IWorldTranslator worldTranslator)
            : base(animation, textureChanger, position, sprite, markedSprite, degreeCalculator, animationDuration, worldTranslator)
        {
            AnimationLoader = animationLoader;
        }

        public void Update(IVisualParameters parameters, Degree degree)
        {
            IVisualParameters currenParameters = GetParameters();

            if (currenParameters.TextureFolder != parameters.TextureFolder)
            {
                Animation = AnimationLoader.LoadAnimation(parameters.TextureFolder);
            }

            if (Sprite is IVisualParameterUpdater)
                (Sprite as IVisualParameterUpdater).UpdateParameters(parameters, degree);
            if (MarkedSprite is IPhysicalParameterUpdater)
                (MarkedSprite as IPhysicalParameterUpdater).UpdateParameters(parameters, degree);

            PercentFader = new PercentFader(currenParameters.AnimationDurationPerImage);
        }

        public void MarkSide(string sideName)
        {
            if (MarkedSprite is ISideMarker)
                (MarkedSprite as ISideMarker).MarkSide(sideName);
        }
    }
}
