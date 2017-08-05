using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InitializationContracts;
using SaveGames.FileAccess;
using SaveGames.XDocumentConverter;
using SaveGames;
using FrameworkContracts;
using IOInterface;

namespace LevelEditor
{
    public class LevelSerializer : IAutoSaveGameSerializer
    {
        private IXmlFileSerializer _fileSerializer;
        private ILevelElementSplitter _levelElementSplitter;

        public LevelSerializer(IXmlFileSerializer fileSerializer, ILevelElementSplitter levelElementSplitter)
        {
            _fileSerializer = fileSerializer;
            _levelElementSplitter = levelElementSplitter;
        }

        public void SaveLevelDataTemporary(LevelSaveGame levelSaveGame)
        {
            List<IElement> geometry = _levelElementSplitter.GetGeometry(levelSaveGame.AllElements);
            List<IElement> skillDependentElements = _levelElementSplitter.GetSkillDependentElements(levelSaveGame.AllElements);
            
            _fileSerializer.SaveFile(string.Format("LevelData\\LevelElements_{0}.sav", levelSaveGame.LevelId),
                new LevelStateToXDocumentConverter().Convert(geometry));

            _fileSerializer.SaveFile(string.Format("LevelData\\SkillDetails\\{1}\\LevelElements_{0}_{1}.sav", levelSaveGame.LevelId, levelSaveGame.SkillName),
                new LevelStateToXDocumentConverter().Convert(skillDependentElements));

            ModelExporter.Export(geometry);
        }
    }
}
