using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using InitializationContracts;
using SaveGames.XDocumentConverter;
using SaveGames.FileAccess;
using FrameworkContracts;

namespace SaveGames
{
    public class LevelDefinitionLoader : ILevelDefinitionLoader
    {
        private IXmlFileSerializer _fileSerializer;

        public LevelDefinitionLoader(IXmlFileSerializer fileSerializer)
        {
            _fileSerializer = fileSerializer;
        }

        public LevelSaveGame LoadLevel(int levelId, SkillLevel skillLevel)
        {
            if(!Directory.Exists("LevelData"))
                return null;
            
            string fileNameGeometry = string.Format("LevelData\\LevelElements_{0}.sav", levelId);
            string fileNameSkillDependentElements = string.Format("LevelData\\SkillDetails\\{1}\\LevelElements_{0}_{1}.sav", levelId, skillLevel.ToString());

            if (!File.Exists(fileNameGeometry))
                 return null;
         
            XDocumentToLevelStateConverter xDocumentToLevelStateConverter = new XDocumentToLevelStateConverter();

            LevelSaveGame levelSaveGame = new LevelSaveGame();
            levelSaveGame.LevelId = levelId;
            levelSaveGame.AllElements = xDocumentToLevelStateConverter.Convert(_fileSerializer.LoadFile(fileNameGeometry));
            if (File.Exists(fileNameSkillDependentElements))
                levelSaveGame.AllElements.AddRange(xDocumentToLevelStateConverter.Convert(_fileSerializer.LoadFile(fileNameSkillDependentElements)));
            
            return levelSaveGame;
        }
    }
}
