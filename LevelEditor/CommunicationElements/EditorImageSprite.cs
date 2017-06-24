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
    public class EditorImageSprite : ImageSprite, IEditorCommunicationElement, ISideMarker
    {
        private ITextureLoader TextureLoader { set; get; }

        public EditorImageSprite(ITextureLoader textureLoader, ITexture texture, ITextureChanger textureChanger, Position3D position, IDrawable sprite, IDrawable markedSprite, IWorldTranslator worldTranslator)
            : base(texture, textureChanger, position, sprite, markedSprite, worldTranslator)
        {
            TextureLoader = textureLoader;
        }

        public void Update(IVisualParameters parameters, Degree degree)
        {
            IVisualParameters currenParameters = GetParameters();

            if (currenParameters.TextureFolder != parameters.TextureFolder)
            {
                Texture = TextureLoader.LoadTexture(parameters.TextureFolder, false);
            }

            if (Sprite is IVisualParameterUpdater)
                (Sprite as IVisualParameterUpdater).UpdateParameters(parameters, degree);
            if (MarkedSprite is IPhysicalParameterUpdater)
                (MarkedSprite as IPhysicalParameterUpdater).UpdateParameters(parameters, degree);
        }

        public void MarkSide(string sideName)
        {
            if (MarkedSprite is ISideMarker)
                (MarkedSprite as ISideMarker).MarkSide(sideName);
        }
    }
}
